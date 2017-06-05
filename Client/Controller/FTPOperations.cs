using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Client.Controller
{
    public class FTPOperations
    {
        public static void createFolder(int conferenceID)
        {
            string folderName = conferenceID.ToString();
            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp://issftp.ddns.net/"+folderName+"/");
                req.Method = WebRequestMethods.Ftp.ListDirectory;
                req.Credentials = new NetworkCredential("IssUser", "password");

                using (FtpWebResponse response = (FtpWebResponse)req.GetResponse())
                {
                    // Folder already exists
                    //Console.WriteLine("L am gasit");
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        // Folder not found, create it
                        //Console.WriteLine("Nu l am gasit");
                        WebRequest request = WebRequest.Create("ftp://issftp.ddns.net/" + folderName + "/");
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        request.Credentials = new NetworkCredential("IssUser", "password");
                        using (var resp = (FtpWebResponse)request.GetResponse())
                        {
                            Console.WriteLine(resp.StatusCode);
                        }
                    }
                }
            }


        }
        public static void createFile(int conferenceID, string filepath) //it will update if exists
        {
            string folderName = conferenceID.ToString();
            string temp = filepath;
            temp = temp + "/";
            string filename = temp.Split('/').Last();
            Console.WriteLine(filename);
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("IssUser", "password");
                client.UploadFile("ftp://issftp.ddns.net/newfoldertest3/" + filename, "STOR", filepath);
            }
        }
    }
}
