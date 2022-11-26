using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeSolverApp
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.Run((Form)new Form1());
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("An unhandled exception '" + ex.Message + "Error");
            }
        }
    }
}
