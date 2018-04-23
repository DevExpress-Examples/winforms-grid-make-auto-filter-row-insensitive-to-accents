Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace CustomAutoFilterRowFiltering
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			myGridView1.OptionsView.ShowAutoFilterRow = True
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
			Me.ordersTableAdapter.Fill(Me.northwindDataSet.Orders)


		End Sub
	End Class
End Namespace
