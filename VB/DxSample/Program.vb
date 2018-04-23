Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.Data.Filtering
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.UserSkins
Imports DxSample.Filtering

Namespace DxSample
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            BonusSkins.Register()
            SkinManager.EnableFormSkins()
            UserLookAndFeel.Default.SkinName = "Lilian"
            CriteriaOperator.RegisterCustomFunction(New RemoveDiacriticsFunction())
            Application.Run(New MainForm())
        End Sub
    End Class
End Namespace
