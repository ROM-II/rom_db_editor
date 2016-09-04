using System;
using System.Linq;
using System.Windows.Forms;
using Runes.Net.Shared;
using RunesDataBase.Forms;

namespace RunesDataBase
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var now = DateTime.Now;
            var form = new MainForm
            {
                Log = new Logger($"romdb_{now:ddMMyy_hhmmss}.log",
                    !(args.Contains("/v") || args.Contains("/V")))
            };
            Application.Run(form);
        }
    }
}
