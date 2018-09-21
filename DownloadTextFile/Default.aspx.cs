using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DownloadTextFile
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ProcessDownload(object sender, EventArgs e)
        {
            string sText ="..............................";
            Download(GenerateMemoryStreamFromString(sText),"xyz.txt");
        }

        public static MemoryStream GenerateMemoryStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static void Download(MemoryStream MyStream,string fileName)
        {
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;

            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            //string fileExtension = "txt";

            response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));

            MyStream.WriteTo(response.OutputStream);

            response.Flush();
            response.End();
        }

    }
}