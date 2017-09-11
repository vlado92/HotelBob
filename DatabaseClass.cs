using System.Security.AccessControl;
using System.Windows.Forms;

namespace HotelBob
{
    class DatabaseClass
    {
        static string connString;
        private static System.Data.SqlServerCe.SqlCeConnection conn = new System.Data.SqlServerCe.SqlCeConnection(connString);
        private static System.Data.SqlServerCe.SqlCeCommand command = new System.Data.SqlServerCe.SqlCeCommand("", conn);
        public static string basePath;
        static Startni eventHandler;

        public static void setHandler(Startni form)
        {
            eventHandler = form;
        }
        public static void setConnString(string path)
        {
            basePath = "C:\\Hotel\\BobDatabase.sdf";
            connString = @"Data Source=" + basePath;
            conn.ConnectionString = connString; 
        }

        public static System.Data.SqlServerCe.SqlCeConnection getConnection()
        {
            return conn;
        }
/*      
        public static string getConnString()
        {
            return connString;
        }
*/
        public static void CheckDatabase()
        {
            if (System.IO.File.Exists("D:\\Hotel\\text1.zip"))
                System.IO.File.Delete("D:\\Hotel\\text1.zip");
            if (!System.IO.Directory.Exists(basePath.Substring(0, basePath.LastIndexOf("\\"))))
                System.IO.Directory.CreateDirectory(basePath.Substring(0, basePath.LastIndexOf("\\")));

            if (!System.IO.File.Exists(basePath))
            {
                if (!InternetClass.Download())
                {
                    bool downloaded = false;
                    DialogResult result = MessageBox.Show("Nije moguće povetati se na internet da se nabavi najažurnija baza podataka.\nDa li želite da pokušate opet?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    while (result == DialogResult.Yes && !downloaded)
                    {
                        downloaded = InternetClass.Download();
                        if (!downloaded)
                            result = result = MessageBox.Show("Nije moguće povetati se na internet da se nabavi najažurnija baza podataka.\nDa li želite da pokušate opet?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    }
                    if (!downloaded)
                    {
                        GenerateDatabase();
                        FillDatabase();
                    }
                }
            }
            conn.Close();
            conn.Open();
            command.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Uploads';";
            System.Data.SqlServerCe.SqlCeDataReader read = command.ExecuteReader();
            read.Read();
            if (read.GetInt32(0) == 0)
            {
                command.CommandText = "CREATE TABLE Uploads ("
                                    + "ID int NOT NULL PRIMARY KEY  IDENTITY(0,1) ,"
                                    + "date datetime NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Uploads(date) VALUES ('" + PrijavaGosta.datumVrijeme(System.DateTime.Now) + "');";
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        private static void GenerateDatabase()
        {
            System.Data.SqlServerCe.SqlCeEngine en = new System.Data.SqlServerCe.SqlCeEngine(connString);
            
            en.CreateDatabase();
            try
            {
                conn.Open();
                command.CommandText = "CREATE TABLE Drzava ("
                                    + "ID int NOT NULL PRIMARY KEY  IDENTITY(0,1) ,"
                                    + "Naziv nvarchar(255) NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Uploads ("
                                    + "ID int NOT NULL PRIMARY KEY  IDENTITY(0,1) ,"
                                    + "date datetime NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Gost("
                    + "JMBG nvarchar(13) PRIMARY KEY NOT NULL,"
                    + "BLK nvarchar(20) NOT NULL, "
                    + "Ime nvarchar(30) NOT NULL, "
                    + "Prezime nvarchar(30) NOT NULL, "
                    + "Drzavljanstvo int NOT NULL," 
                    + "FOREIGN KEY(Drzavljanstvo) REFERENCES Drzava(ID));";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Kvarovi ("
                                    + " Id_kvara INT NOT NULL PRIMARY KEY  IDENTITY(0,1) , "
                                    + " Naziv    nvarchar(30) NOT NULL, "
                                    + " Cijena   int NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Vrsta ("
                                    + "ID INT NOT NULL PRIMARY KEY  IDENTITY(0,1) , "
                                    + "naziv   nvarchar(255) NOT NULL, "
                                    + "cijena   int NOT NULL, "
                                    + "broj_kreveta int NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Sobe ("
                                    + "Sifra  nvarchar(4) NOT NULL, "
                                    + "Vrsta  int NOT NULL, "
                                    + "Stanje int, popunjenost int, "
                                    + "PRIMARY KEY (Sifra), "
                                    + "FOREIGN KEY(Vrsta) REFERENCES Vrsta(ID));";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Rezervacija ("
                                    + "id      INT NOT NULL PRIMARY KEY  IDENTITY(0,1) , "
                                    + "Soba_id    nvarchar(4) NOT NULL,"
                                    + "Prijava datetime NOT NULL, "
                                    + "Odjava  datetime , "
                                    + "ime    nvarchar(50) NOT NULL,"
                                    + "status    int NOT NULL,"
                                    + "placeno    int NOT NULL,"
                                    + "FOREIGN KEY(Soba_id) REFERENCES Sobe(Sifra));";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Izvjestaj ("
                                    + "id      INT NOT NULL PRIMARY KEY  IDENTITY(0,1) , "
                                    + "brojSobe    nvarchar(4) NOT NULL,"
                                    + "datumPrijave datetime NOT NULL, "
                                    + "datumOdjave  datetime , "
                                    + "drzava int, vrstaSobe int, paket int);";
                command.ExecuteNonQuery();


                command.CommandText = "CREATE TABLE Pansion ("
                                    + "ID     INT NOT NULL PRIMARY KEY  IDENTITY(0,1) , "
                                    + "Naziv  nvarchar(20) NOT NULL, "
                                    + "Cijena int NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Sobe_Gost ("
                                    + "SobeSifra nvarchar(4) NOT NULL, "
                                    + "GostJMBG  nvarchar(13) NOT NULL, "
                                    + "Prijava   datetime NOT NULL, "
                                    + "Odjava    datetime, "
                                    + "Veseraj   int NOT NULL, "
                                    + "Boravisna int NOT NULL, "
                                    + " Vrsta_pansiona int NOT NULL, "
                                    + " popust nvarchar(5) NOT NULL,"
                                    + " dodatniCeh nvarchar(10) NOT NULL, paket int,"
                                    + "PRIMARY KEY (SobeSifra, GostJMBG), "
                                    + "FOREIGN KEY(SobeSifra) REFERENCES Sobe(Sifra),"
                                    + "FOREIGN KEY(GostJMBG) REFERENCES Gost(JMBG),"
                                    + "FOREIGN KEY(Vrsta_pansiona) REFERENCES Pansion(ID));";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Vrsta_Kvarovi ("
                                    + "VrstaID         int NOT NULL,"
                                    + "KvaroviId_kvara int NOT NULL, "
                                    + "PRIMARY KEY (VrstaID, KvaroviId_kvara), "
                                    + "FOREIGN KEY(VrstaID) REFERENCES Vrsta(ID), "
                                    + "FOREIGN KEY(KvaroviId_kvara) REFERENCES Kvarovi(Id_kvara));";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Reminders ("
                                    + " ID INT NOT NULL PRIMARY KEY  IDENTITY(0,1),"
                                    + "JMBG    nvarchar(13) NOT NULL, "
                                    + "Soba    nvarchar(4) NOT NULL, "
                                    + "Vrijeme datetime NOT NULL, "
                                    + "Tekst   nvarchar(255), Uradjen int);";
                command.ExecuteNonQuery();

                conn.Close();
            }
            catch (System.Data.SqlServerCe.SqlCeException)
            {
                DialogResult button = MessageBox.Show(eventHandler, "Nije moguće uspostaviti konekciju sa bazom. Želite da nastavite?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (button == System.Windows.Forms.DialogResult.No)
                    eventHandler.Dispose();
            }
        }
        public static System.DateTime LastUpload()
        {
            conn.Close();
            conn.Open();
            System.Data.SqlServerCe.SqlCeDataReader reader = new System.Data.SqlServerCe.SqlCeCommand("SELECT MAX(date) FROM uploads;", conn).ExecuteReader();
            reader.Read();
            System.DateTime upload = reader.GetDateTime(0);
            conn.Close();
            return upload;
        }
        private static void FillDatabase()
        {
            conn.Open();
            command.CommandText = "INSERT INTO Uploads(date) VALUES ('" + PrijavaGosta.datumVrijeme(System.DateTime.Now) + "');";
            command.ExecuteNonQuery();

            command.CommandText = "SELECT COUNT(*) FROM Vrsta;";
            System.Data.SqlServerCe.SqlCeDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) == 0)
            {
                command.CommandText = "INSERT INTO Vrsta(naziv, cijena, broj_kreveta) VALUES"
                                   + "('Jednokrevetna', 35, 1);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Vrsta(naziv, cijena, broj_kreveta) VALUES"
                                    + "('Dvokrevetna', 65, 2);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Vrsta(naziv, cijena, broj_kreveta) VALUES"
                                    + "('Trokrevetna', 90, 3);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Vrsta(naziv, cijena, broj_kreveta) VALUES"
                                    + "('Četverokrevetna', 120, 4);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Vrsta(naziv, cijena, broj_kreveta) VALUES"
                                    + "('Lux soba', 100, 1);";
                command.ExecuteNonQuery();
            }

            command.CommandText = "SELECT COUNT(*) FROM Sobe;";
            reader = command.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) == 0)
            {
                string[] name = new string[2];
                TabControl tc = eventHandler.tabControl1;

                foreach (TabPage tp in ((TabControl)tc).Controls)
                    foreach (Button b in ((TabPage)tp).Controls)
                    {
                        name = b.Name.Split('_');
                        command.CommandText = "INSERT INTO Sobe(sifra, vrsta, stanje, popunjenost) VALUES"
                            + "('" + name[0] + "', " + (System.Int32.Parse(name[1])) + ", 0, 0);";
                        command.ExecuteNonQuery();
                    }
            }

            command.CommandText = "SELECT COUNT(*) FROM Drzava;";
            reader = command.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) == 0)
                for (int i = 0; i < Drzave.drzave.Length; i++)
                {
                    command.CommandText = "INSERT INTO Drzava(naziv) VALUES"
                        + "('" + Drzave.drzave[i] + "');";
                    command.ExecuteNonQuery();
                }
            command.CommandText = "SELECT COUNT(*) FROM Pansion;";
            reader = command.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) == 0)
            {
                command.CommandText = "INSERT INTO Pansion(naziv, cijena) VALUES"
                                   + "('Polu pansion', 15);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Pansion(naziv, cijena) VALUES"
                                   + "('Pun pansion', 30);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Pansion(naziv, cijena) VALUES"
                                   + "('Dnevni boravak', 45);";
                command.ExecuteNonQuery();
            }
            command.CommandText = "SELECT COUNT(*) FROM kvarovi;";
            reader = command.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) == 0)
            {
                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                   + "('Krevet', 300);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                   + "('Sto', 300);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                   + "('Noćni ormarić', 150);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                   + "('Lampa', 50);";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                    + "('TV', 300);";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                    + "('Daljinski', 20);";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                    + "('Klima', 300);";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                    + "('Stolica', 50);";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                    + "('Ogledalo', 50);";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                    + "('Čaša', 10);";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Kvarovi(naziv, cijena) VALUES"
                                    + "('Pepeljara', 10);";                
                command.ExecuteNonQuery();
            }

            conn.Close();
        }

        public static bool GrantAccess()
        {
            string fullPath = connString.Substring(12);
            if (!hasWriteAccessToFolder(fullPath))
            {
                try
                {
                    System.IO.DirectoryInfo dInfo = new System.IO.DirectoryInfo(fullPath);
                    DirectorySecurity dSecurity = dInfo.GetAccessControl();
                    dSecurity.AddAccessRule(new FileSystemAccessRule(new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                    dInfo.SetAccessControl(dSecurity);
                    return true;
                }
                catch (System.Exception ee)
                {
                    MessageBox.Show("Problem sa bazom podataka. " + ee.ToString());
                    return false;
                }
            }
            else
                return true;

        }
        public static bool hasWriteAccessToFolder(string folderPath)
        {
            try
            {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                System.Security.AccessControl.DirectorySecurity ds = System.IO.Directory.GetAccessControl(folderPath);
                return true;
            }
            catch (System.UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
