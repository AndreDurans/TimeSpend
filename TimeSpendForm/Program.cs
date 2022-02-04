using System.Reflection;
using TimeSpendForm.Forms;

namespace TimeSpendForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!File.Exists(@$"{folder}\Personalkey.txt"))
                Application.Run(new frmGetPersonalKey());
            else
                Application.Run(new frmMain(new frmGetPersonalKey()));
        }
    }
}