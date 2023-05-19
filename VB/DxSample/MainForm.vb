Imports System
Imports System.Data
Imports System.Linq
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DxSample.Filtering

Namespace DxSample

    Public Partial Class MainForm
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim ds As DataSet = New DataSet()
            ds.ReadXml("nwind.xml")
            Dim dt As DataTable = ds.Tables("Customers")
            Dim customers = From r In dt.Rows.Cast(Of DataRow)() Let required = New String() {"ANTON", "BERGS", "BLONP", "BOLID", "COMMI", "FOLKO", "GALED", "GODOS", "HILAA"} Where required.Contains(CStr(r("CustomerID"))) Select New With {.CompanyName = CStr(r("CompanyName")), .ContactName = CStr(r("ContactName")), .ContactTitle = CStr(r("ContactTitle"))}
            GridControl.DataSource = customers.ToList()
        End Sub

        Private Sub GridView_SubstituteFilter(ByVal sender As Object, ByVal e As SubstituteFilterEventArgs)
            e.Filter = GridFilterSubstitutor.Substitute(e.Filter)
        End Sub
    End Class
End Namespace
