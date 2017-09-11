using System;

namespace HotelBob
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            string path = System.Windows.Forms.Application.ExecutablePath.Substring(0, System.Windows.Forms.Application.ExecutablePath.LastIndexOf('\\') + 1);
            DatabaseClass.setConnString(path);
            Console.WriteLine(path);
            System.Windows.Forms.Application.Run(new Startni());
            
        }
        public static bool Upload()
        {
            bool proslo = InternetClass.Upload();

            Console.WriteLine(proslo);
            return proslo;
        }

        public static void Locate(System.Windows.Forms.Form formToLocate, System.Windows.Forms.Form formToReference)
        {
            formToLocate.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
           formToLocate.Location = new System.Drawing.Point(formToReference.Location.X + formToReference.Size.Width / 2 - formToLocate.Size.Width / 2,
                             formToReference.Location.Y + formToReference.Size.Height / 2 - formToLocate.Size.Height / 2);
        }
    }
}
