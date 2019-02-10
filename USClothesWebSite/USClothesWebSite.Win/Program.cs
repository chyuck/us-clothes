using System;
using System.Threading;
using System.Windows.Forms;
using USClothesWebSite.Win.Forms;

namespace USClothesWebSite.Win
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;

            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var form = new ExceptionForm(e.Exception);
            form.ShowDialog();
        }
    }
}
