﻿using Cerin_Ingenieros.Consultas;
using Cerin_Ingenieros.Login;
using System;
using System.Windows.Forms;

namespace Cerin_Ingenieros
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new preLogin());
        }
    }
}
