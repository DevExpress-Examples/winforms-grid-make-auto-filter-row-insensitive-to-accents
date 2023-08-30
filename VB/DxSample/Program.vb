Imports System
Imports System.Windows.Forms
Imports DevExpress.Data.Filtering
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.UserSkins
Imports DxSample.Filtering

Namespace DxSample

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call BonusSkins.Register()
            Call SkinManager.EnableFormSkins()
            UserLookAndFeel.Default.SkinName = "Lilian"
            Call CriteriaOperator.RegisterCustomFunction(New RemoveDiacriticsFunction())
            Call Application.Run(New MainForm())
        End Sub
    End Module
End Namespace
