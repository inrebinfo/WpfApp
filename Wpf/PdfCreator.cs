using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.fonts;
using System.IO;

namespace Wpf
{
    public class PdfCreator
    {
        public void WritePDF(InvoiceObject obj)
        {
            string path = @"rechnung_"+obj.ID+".pdf";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            FileStream stream = new FileStream(path, FileMode.Create);

            double netto = 0;
            double brutto = 0;

            using (Document document = new Document(iTextSharp.text.PageSize.A4))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();


                Font font = new Font(Font.FontFamily.TIMES_ROMAN, 10f);

                Paragraph pKundenID = new Paragraph("Kundennummer: " + obj.FK_Kontakt, font);
                document.Add(pKundenID);

                Paragraph pErstellDatum = new Paragraph("Erstellt am: " + obj.ErstellungsDatum, font);
                document.Add(pErstellDatum);

                Paragraph pFaelligDatum = new Paragraph("Fällig am: " + obj.FaelligkeitsDatum, font);
                document.Add(pFaelligDatum);
                
                Paragraph pKommentar = new Paragraph("Kommentar: " + obj.Kommentar, font);
                document.Add(pKommentar);

                Paragraph pNachricht = new Paragraph("Nachricht: " + obj.Nachricht, font);
                document.Add(pNachricht);

                Paragraph pRechNr = new Paragraph("Rechnungsnummer: " + obj.ID, font);
                document.Add(pRechNr);

                document.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(4);

                table.AddCell(new PdfPCell(new Phrase("Menge", font)));
                table.AddCell(new PdfPCell(new Phrase("Stückpreis", font)));
                table.AddCell(new PdfPCell(new Phrase("UST", font)));
                table.AddCell(new PdfPCell(new Phrase("Netto ges.", font)));
                
                foreach (InvoiceLineObject line in obj.InvoiceLines)
                {
                    double ges = Convert.ToDouble(line.Stkpreis) * Convert.ToDouble(line.Menge);

                    netto += ges;
                    brutto += ges*(1+(Convert.ToDouble(line.UST)/100));

                    table.AddCell(new PdfPCell(new Phrase(line.Menge, font)));
                    table.AddCell(new PdfPCell(new Phrase(line.Stkpreis+"€", font)));
                    table.AddCell(new PdfPCell(new Phrase(line.UST+"%", font)));
                    table.AddCell(new PdfPCell(new Phrase(ges.ToString()+"€", font)));
                }

                document.Add(table);

                document.Add(Chunk.NEWLINE);

                Paragraph pFullNetto = new Paragraph("Summe netto: " + netto, font);
                document.Add(pFullNetto);

                Paragraph pFullBrutto = new Paragraph("Summe brutto: " + brutto, font);
                document.Add(pFullBrutto);
            }

            System.Diagnostics.Process.Start(path);
        }
    }
}
