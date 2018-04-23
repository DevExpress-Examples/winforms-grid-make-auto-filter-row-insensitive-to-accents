Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DxSample.Filtering

Namespace DxSample
    Partial Public Class MainForm
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim ds As New DataSet()
            ds.ReadXml("nwind.xml")
            Dim dt As DataTable = ds.Tables("Customers")
            Dim customers = From r In dt.Rows.Cast(Of DataRow)() _
                Let required = New String() { "ANTON", "BERGS", "BLONP", "BOLID", "COMMI", "FOLKO", "GALED", "GODOS", "HILAA" } _
                Where required.Contains(CStr(r("CustomerID"))) _
                Select New With { _
                    Key .CompanyName = CStr(r("CompanyName")), _
                    Key .ContactName = CStr(r("ContactName")), _
                    Key .ContactTitle = CStr(r("ContactTitle")) _
                }
            Me.GridControl.DataSource = customers.ToList()
        End Sub

        Private Sub GridView_SubstituteFilter(ByVal sender As Object, ByVal e As SubstituteFilterEventArgs) Handles GridView.SubstituteFilter
            e.Filter = GridFilterSubstitutor.Substitute(e.Filter)
        End Sub
    End Class
End Namespace
