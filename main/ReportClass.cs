using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EgidaBackup
{
    public class ReportClass
    {
        MemoryStream _Stream;

        public ReportClass(string Name)
        {
            _Stream = new MemoryStream();
            Write("<html><head><title>"+Name+"</title></head><body><h1>"+Name+"</h1>");
        }

        ~ReportClass()
        {
            _Stream.Dispose();
        }

        public void Write(string Text)
        {
            byte[] bufer = Encoding.UTF8.GetBytes(Text);
            _Stream.Write(bufer, 0, bufer.Length);
        }

        //html

        public void WriteH1(string Text)
        {
            Write("<h1>"+Text+"</h1>");
        }

        public void WriteH2(string Text)
        {
            Write("<h2>" + Text + "</h2>");
        }

        public void WriteH3(string Text)
        {
            Write("<h3>" + Text + "</h3>");
        }

        public void WriteP(string Text)
        {
            Write("<p>" + Text + "</p>");
        }

        public void WriteLine(string Text)
        {
            Write(Text + "<br>");
        }

        public void WriteTableHeader(string[] Header)
        {
            Write("<table cellpadding=0 cellspacing=0 border=1 width=100%><tr>");
            foreach (string H in Header)
            {
                Write("<th>"+H+"</th>");
            }
            Write("</tr>");
        }

        public void WriteTableRow(string[] Row)
        {
            Write("<tr>");
            foreach (string R in Row)
                Write("<td>"+R+"</td>");
            Write("</tr>");
        }

        public void WriteTableFooter()
        {
            Write("</table>");
        }

        public void WriteEnd()
        {
            Write("</body></html>");
        }

        // \html

        public void Save(string Filename)
        {
            FileStream F = new FileStream(Filename, FileMode.Create, FileAccess.Write);
            _Stream.WriteTo(F);
            F.Close();
            F.Dispose();
        }
    }
}
