using System.Text;
using System;
using GWI.Models.Curriculos;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWI.Services.DinkToPdf.Helper
{
    public class Helper
    {
        public static string ToHtmlFile(PessoasCurriculos data)
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "HtmlTemplates", "template.html");
            string tempHtml = File.ReadAllText(templatePath);
            StringBuilder stringData = new StringBuilder(String.Empty);
            //for (int i = 0; i < data.Count; i++)
            //{
            //    stringData.Append($"<tr><td>{i + 1}</td>");               
            //    stringData.Append($"<td>{data[i].Id}</td>");
            //    stringData.Append($"<td>{data[i].Name}</td>");
            //    stringData.Append($"<td>{data[i].Age}</td>");
            //    stringData.Append($"<td>{data[i].DoB.ToString("dd/MM/yyyy")}</td></tr>");

                
            //}
            stringData.Append($"<h1>Gabriel Fecchio Paravani Larocca</h1>");
            return tempHtml.Replace("{data}", stringData.ToString());
        }
    }
}