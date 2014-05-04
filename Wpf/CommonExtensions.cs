
namespace Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Collections;

    public static class CommonExtensions
    {
        /// <summary>
        /// Foreach Extension Method for IEnumerable.
        /// </summary>
        /// <typeparam name="T">Type of the Objects in the Enumeration.</typeparam>
        /// <param name="lst">Enumeration</param>
        /// <param name="action">Action to perform on each element.</param>
        public static void ForEach<T>(this IEnumerable lst, Action<T> action)
        {
            if (lst == null) { throw new ArgumentNullException("lst"); }
            if (action == null) { throw new ArgumentNullException("action"); }

            foreach (T obj in lst)
            {
                action(obj);
            }
        }

        /// <summary>
        /// Foreach Extension Method for IEnumerable. This Extension does not check if the Enumeration Entry is NULL!
        /// </summary>
        /// <typeparam name="T">Type of the Objects in the Enumeration.</typeparam>
        /// <param name="lst">Enumeration</param>
        /// <param name="action">Action to perform on each element.</param>
        public static void ForEach<T>(this IEnumerable<T> lst, Action<T> action)
        {
            if (lst == null) { throw new ArgumentNullException("lst"); }
            if (action == null) { throw new ArgumentNullException("action"); }

            foreach (T obj in lst)
            {
                action(obj);
            }
        }

        /// <summary>
        /// Foreach Extension Method for IList&lt;>. This Extension does not check if the Enumeration Entry is NULL!
        /// </summary>
        /// <typeparam name="T">Type of the Objects in the Enumeration.</typeparam>
        /// <param name="lst">Enumeration</param>
        /// <param name="action">Action to perform on each element.</param>
        public static void ForEach<T>(this IList<T> lst, Action<T> action)
        {
            if (lst == null) { throw new ArgumentNullException("lst"); }
            if (action == null) { throw new ArgumentNullException("action"); }

            foreach (T obj in lst)
            {
                action(obj);
            }
        }
        /// <summary>
        /// Foreach Extension Method for IQueryable&lt;>. This Extension does not check if the query results contain NULLs!
        /// </summary>
        /// <typeparam name="T">Type of the Objects in the IQueryable.</typeparam>
        /// <param name="lst">IQueryable</param>
        /// <param name="action">Action to perform on each element.</param>
        public static void ForEach<T>(this IQueryable<T> lst, Action<T> action)
        {
            if (lst == null) { throw new ArgumentNullException("lst"); }
            if (action == null) { throw new ArgumentNullException("action"); }

            foreach (T i in lst)
            {
                action(i);
            }
        }

        public static void Add(this ICollection col, object val, bool unique)
        {
            if (col == null) throw new ArgumentNullException("col");

            Type collectionType = col.GetType();
            Type collectionItemType = collectionType.FindElementTypes().Single(t => t != typeof(object));

            if (unique)
            {
                MethodInfo contains = collectionType.FindMethod("Contains", new Type[] { collectionItemType });
                if (contains == null) throw new ArgumentException("Cound not find \"Contains\" method of the given Collection");
                bool result = (bool)contains.Invoke(col, new object[] { val });
                if (result) return;
            }

            MethodInfo add = collectionType.FindMethod("Add", new Type[] { collectionItemType });
            if (add == null) throw new ArgumentException("Cound not find \"Add\" method of the given Collection");
            add.Invoke(col, new object[] { val });
        }

        public static void Remove(this ICollection col, object val)
        {
            if (col == null) throw new ArgumentNullException("col");

            Type collectionType = col.GetType();
            Type collectionItemType = collectionType.FindElementTypes().Single(t => t != typeof(object));

            MethodInfo remove = collectionType.FindMethod("Remove", new Type[] { collectionItemType });
            if (remove == null) throw new ArgumentException("Cound not find \"Remove\" method of the given Collection");
            remove.Invoke(col, new object[] { val });
        }

        /// <summary>
        /// Finds all implemented IEnumerables, IQueryables and IOrderedQueryables of the given Type
        /// </summary>
        public static IQueryable<Type> FindSequences(this Type seqType)
        {
            if (seqType == null || seqType == typeof(object) || seqType == typeof(string))
                return new Type[] { }.AsQueryable();

            if (seqType.IsArray || seqType == typeof(IEnumerable))
                return new Type[] { typeof(IEnumerable) }.AsQueryable();

            if (seqType.IsArray || seqType == typeof(IQueryable))
                return new Type[] { typeof(IQueryable) }.AsQueryable();

            if (seqType.IsArray || seqType == typeof(IOrderedQueryable))
                return new Type[] { typeof(IOrderedQueryable) }.AsQueryable();

            if (seqType.IsGenericType && seqType.GetGenericArguments().Length == 1 && seqType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return new Type[] { seqType, typeof(IEnumerable) }.AsQueryable();
            }

            if (seqType.IsGenericType && seqType.GetGenericArguments().Length == 1 && seqType.GetGenericTypeDefinition() == typeof(IQueryable<>))
            {
                return new Type[] { seqType, typeof(IQueryable) }.AsQueryable();
            }

            if (seqType.IsGenericType && seqType.GetGenericArguments().Length == 1 && seqType.GetGenericTypeDefinition() == typeof(IOrderedQueryable<>))
            {
                return new Type[] { seqType, typeof(IOrderedQueryable) }.AsQueryable();
            }

            var result = new List<Type>();

            foreach (var iface in (seqType.GetInterfaces() ?? new Type[] { }))
            {
                result.AddRange(FindSequences(iface));
            }

            return FindSequences(seqType.BaseType).Union(result);
        }

        /// <summary>
        /// Finds all element types provided by a specified sequence type.
        /// "Element types" are T for IEnumerable&lt;T&gt; and object for IEnumerable.
        /// </summary>
        public static IQueryable<Type> FindElementTypes(this Type seqType)
        {
            return seqType.FindSequences().Select(t => t.IsGenericType ? t.GetGenericArguments().Single() : typeof(object));
        }

        /// <summary>
        /// Calls a public method on the given object. Uses Reflection.
        /// </summary>
        /// <typeparam name="TReturn">expected return type</typeparam>
        /// <param name="obj">the object on which to call the method</param>
        /// <param name="methodName">which method to call</param>
        /// <returns>the return value of the method</returns>
        /// <exception cref="ArgumentOutOfRangeException">if the method is not found</exception>
        public static TReturn CallMethod<TReturn>(this object obj, string methodName)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            Type t = obj.GetType();
            MethodInfo mi = null;
            while (mi == null && t != null)
            {
                mi = t.GetMethod(methodName, new Type[] { });
                t = t.BaseType;
            }
            if (mi == null) throw new ArgumentOutOfRangeException("methodName", string.Format("Method {0} was not found in Type {1}", methodName, obj.GetType().FullName));
            return (TReturn)mi.Invoke(obj, new object[] { });
        }

        /// <summary>
        /// Finds a Method with the given method parameter.
        /// </summary>
        /// <param name="type">Type to search in</param>
        /// <param name="methodName">Methodname to search for</param>
        /// <param name="parameterTypes">parameter types to match</param>
        /// <returns>MethodInfo or null if the method was not found</returns>
        public static MethodInfo FindMethod(this Type type, string methodName, Type[] parameterTypes)
        {
            if (type == null) { throw new ArgumentNullException("type"); }

            if (parameterTypes == null)
            {
                MethodInfo mi = type.GetMethod(methodName);
                if (mi != null) return mi;
            }
            else
            {
                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo mi in methods)
                {
                    if (mi.Name == methodName)
                    {
                        ParameterInfo[] parameters = mi.GetParameters();
                        if (parameters.Length == parameterTypes.Length)
                        {
                            bool paramSame = true;
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                if (parameters[i].ParameterType != parameterTypes[i])
                                {
                                    paramSame = false;
                                    break;
                                }
                            }

                            if (paramSame) return mi;
                        }
                    }
                }
            }

            // Look in Basetypes
            if (type.BaseType != null)
            {
                MethodInfo mi = type.BaseType.FindMethod(methodName, parameterTypes);
                if (mi != null) return mi;
            }

            // Look in Interfaces
            foreach (Type i in type.GetInterfaces())
            {
                MethodInfo mi = i.FindMethod(methodName, parameterTypes);
                if (mi != null) return mi;
            }

            return null;
        }

        /// <summary>
        /// Finds a Method with the given method parameter.
        /// </summary>
        /// <param name="type">Type to search in</param>
        /// <param name="methodName">Methodname to search for</param>
        /// <param name="typeArguments">type arguments to match</param>
        /// <param name="parameterTypes">parameter types to match</param>
        /// <returns>MethodInfo or null if the method was not found</returns>
        public static MethodInfo FindGenericMethod(this Type type, string methodName, Type[] typeArguments, Type[] parameterTypes)
        {
            return type.FindGenericMethod(false, methodName, typeArguments, parameterTypes);
        }

        /// <summary>
        /// Finds a Method with the given method parameter.
        /// </summary>
        /// <param name="type">Type to search in</param>
        /// <param name="isPrivate">whether or not the method is private</param>
        /// <param name="methodName">Methodname to search for</param>
        /// <param name="typeArguments">type arguments to match</param>
        /// <param name="parameterTypes">parameter types to match</param>
        /// <returns>MethodInfo or null if the method was not found</returns>
        public static MethodInfo FindGenericMethod(this Type type, bool isPrivate, string methodName, Type[] typeArguments, Type[] parameterTypes)
        {
            if (type == null) { throw new ArgumentNullException("type"); }

            if (parameterTypes == null)
            {
                MethodInfo mi = isPrivate
                    ? type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.NonPublic)
                    : type.GetMethod(methodName);

                if (mi != null)
                {
                    return mi.MakeGenericMethod(typeArguments);
                }
            }
            else
            {
                MethodInfo[] methods = isPrivate
                    ? type.GetMethods(BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.NonPublic)
                    : type.GetMethods();

                foreach (MethodInfo method in methods)
                {
                    if (method.Name == methodName && method.GetGenericArguments().Length == typeArguments.Length)
                    {
                        MethodInfo mi = method.MakeGenericMethod(typeArguments);
                        ParameterInfo[] parameters = mi.GetParameters();

                        if (parameters.Length == parameterTypes.Length)
                        {
                            bool paramSame = true;
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                if (parameters[i].ParameterType != parameterTypes[i])
                                {
                                    paramSame = false;
                                    break;
                                }
                            }

                            if (paramSame) return mi;
                        }
                    }
                }
            }

            // Look in Basetypes
            if (type.BaseType != null)
            {
                MethodInfo mi = type.BaseType.FindGenericMethod(isPrivate, methodName, typeArguments, parameterTypes);
                if (mi != null) return mi;
            }

            // Look in Interfaces
            foreach (Type i in type.GetInterfaces())
            {
                MethodInfo mi = i.FindGenericMethod(isPrivate, methodName, typeArguments, parameterTypes);
                if (mi != null) return mi;
            }

            return null;
        }
    }
}
