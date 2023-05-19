﻿using DevExpress.Data.Filtering;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DxSample.Filtering;
using System;
using System.Windows.Forms;

namespace DxSample {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SkinName = "Lilian";
            CriteriaOperator.RegisterCustomFunction(new RemoveDiacriticsFunction());
            Application.Run(new MainForm());
        }
    }
}