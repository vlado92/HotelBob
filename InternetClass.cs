using System;
using System.IO;
using System.IO.Compression;
using System.Net.Mail;
using System.Net;

namespace HotelBob
{
    class InternetClass
    {		
        string _sender = "";
        string _password = "";

        static string ftpurl = "ftp://files.000webhost.com/public_html/BobDatabase.sdf";
        static string ftpusername = "hotelbob";
        static string ftppassword = "23091992";
        
        public InternetClass(string sender, string password)
        {
            _sender = sender;
            _password = password;
        }  
  
        public void SendMail(string recipient, string subject, string message)
        {
  /*         SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
  
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials = 
                new System.Net.NetworkCredential(_sender, _password);
            client.EnableSsl = true;
            client.Credentials = credentials;
  
            try
            {
                Attachment at = new Attachment(DoIt());
                at.ContentType = new System.Net.Mime.ContentType("application/x-rar-compressed");
                var mail = new MailMessage(_sender.Trim(), recipient.Trim());
                mail.Subject = subject;
                mail.Body = message;
                mail.Attachments.Add(at);
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }*/
            /*
            
} 
             */
            // 
        }

        private static Boolean CheckConnection()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("208.69.34.231"), 1000);

            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean Upload()
        {
            if (CheckConnection())
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(ftpusername, ftppassword);
                    try
                    {
                        System.Data.SqlServerCe.SqlCeCommand comm = 
                            new System.Data.SqlServerCe.SqlCeCommand("INSERT INTO Uploads(date) VALUES ('" + PrijavaGosta.datumVrijeme(DateTime.Now) + "');", DatabaseClass.getConnection());
                        if(DatabaseClass.getConnection().State == System.Data.ConnectionState.Closed)
                        {
                            DatabaseClass.getConnection().Open();
                            comm.ExecuteNonQuery();

                            DatabaseClass.getConnection().Close();
                            File.Copy(DatabaseClass.basePath, "C:\\Hotel\\BobDatabase1.sdf", true);
             
                            client.UploadFile(ftpurl, "STOR", "C:\\Hotel\\BobDatabase1.sdf");
                            File.Delete("C:\\Hotel\\BobDatabase1.sdf");
                            Console.WriteLine("Upload File Complete");
                            return true;
                        }
                        return false;
                    }
                    catch
                    {
                        Console.WriteLine("GRESKA");
                        return false;
                    }
                }
            else
                return false;
        }

        public static Boolean Download()
        {
            if (CheckConnection())
            {
                System.Net.WebClient Client = new System.Net.WebClient();
                try
                {
                    Client.DownloadFile("https://hotelbob.000webhostapp.com/BobDatabase.sdf", @"C:\Hotel\BobDatabase.sdf");
                    Console.WriteLine("Download Comlpete");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
              return false;
        }

        string DoIt()
        {
            string sFileToZip = @"D:\\Hotel\\BobDatabase.sdf";
            string sZipFile = @"D:\\Hotel\\text1.zip";

            using (FileStream __fStream = File.Open(sZipFile, FileMode.Create))
            {
                GZipStream obj = new GZipStream(__fStream, CompressionMode.Compress);

                byte[] bt = File.ReadAllBytes(sFileToZip);
                obj.Write(bt, 0, bt.Length);

                obj.Close();
                obj.Dispose();
                return sZipFile;
            }
        }   
    }
}


