Namespace CustomAutoFilterRowFiltering
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.myGridControl1 = New DXSample.MyGridControl()
            Me.ordersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.northwindDataSet = New CustomAutoFilterRowFiltering.NorthwindDataSet()
            Me.myGridView1 = New DXSample.MyGridView()
            Me.colOrderID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colCustomerID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colEmployeeID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colOrderDate = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colRequiredDate = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colShippedDate = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colShipVia = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colFreight = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colShipName = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colShipAddress = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colShipCity = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colShipRegion = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colShipPostalCode = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colShipCountry = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.ordersTableAdapter = New CustomAutoFilterRowFiltering.NorthwindDataSetTableAdapters.OrdersTableAdapter()
            DirectCast(Me.myGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.ordersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.northwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.myGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' myGridControl1
            ' 
            Me.myGridControl1.DataSource = Me.ordersBindingSource
            Me.myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.myGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.myGridControl1.MainView = Me.myGridView1
            Me.myGridControl1.Name = "myGridControl1"
            Me.myGridControl1.Size = New System.Drawing.Size(986, 379)
            Me.myGridControl1.TabIndex = 0
            Me.myGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.myGridView1})
            ' 
            ' ordersBindingSource
            ' 
            Me.ordersBindingSource.DataMember = "Orders"
            Me.ordersBindingSource.DataSource = Me.northwindDataSet
            ' 
            ' northwindDataSet
            ' 
            Me.northwindDataSet.DataSetName = "NorthwindDataSet"
            Me.northwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' myGridView1
            ' 
            Me.myGridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colOrderID, Me.colCustomerID, Me.colEmployeeID, Me.colOrderDate, Me.colRequiredDate, Me.colShippedDate, Me.colShipVia, Me.colFreight, Me.colShipName, Me.colShipAddress, Me.colShipCity, Me.colShipRegion, Me.colShipPostalCode, Me.colShipCountry})
            Me.myGridView1.GridControl = Me.myGridControl1
            Me.myGridView1.Name = "myGridView1"
            ' 
            ' colOrderID
            ' 
            Me.colOrderID.FieldName = "OrderID"
            Me.colOrderID.Name = "colOrderID"
            Me.colOrderID.OptionsColumn.ReadOnly = True
            Me.colOrderID.Visible = True
            Me.colOrderID.VisibleIndex = 0
            ' 
            ' colCustomerID
            ' 
            Me.colCustomerID.FieldName = "CustomerID"
            Me.colCustomerID.Name = "colCustomerID"
            Me.colCustomerID.Visible = True
            Me.colCustomerID.VisibleIndex = 1
            ' 
            ' colEmployeeID
            ' 
            Me.colEmployeeID.FieldName = "EmployeeID"
            Me.colEmployeeID.Name = "colEmployeeID"
            Me.colEmployeeID.Visible = True
            Me.colEmployeeID.VisibleIndex = 2
            ' 
            ' colOrderDate
            ' 
            Me.colOrderDate.FieldName = "OrderDate"
            Me.colOrderDate.Name = "colOrderDate"
            Me.colOrderDate.Visible = True
            Me.colOrderDate.VisibleIndex = 3
            ' 
            ' colRequiredDate
            ' 
            Me.colRequiredDate.FieldName = "RequiredDate"
            Me.colRequiredDate.Name = "colRequiredDate"
            Me.colRequiredDate.Visible = True
            Me.colRequiredDate.VisibleIndex = 4
            ' 
            ' colShippedDate
            ' 
            Me.colShippedDate.FieldName = "ShippedDate"
            Me.colShippedDate.Name = "colShippedDate"
            Me.colShippedDate.Visible = True
            Me.colShippedDate.VisibleIndex = 5
            ' 
            ' colShipVia
            ' 
            Me.colShipVia.FieldName = "ShipVia"
            Me.colShipVia.Name = "colShipVia"
            Me.colShipVia.Visible = True
            Me.colShipVia.VisibleIndex = 6
            ' 
            ' colFreight
            ' 
            Me.colFreight.FieldName = "Freight"
            Me.colFreight.Name = "colFreight"
            Me.colFreight.Visible = True
            Me.colFreight.VisibleIndex = 7
            ' 
            ' colShipName
            ' 
            Me.colShipName.FieldName = "ShipName"
            Me.colShipName.Name = "colShipName"
            Me.colShipName.Visible = True
            Me.colShipName.VisibleIndex = 8
            ' 
            ' colShipAddress
            ' 
            Me.colShipAddress.FieldName = "ShipAddress"
            Me.colShipAddress.Name = "colShipAddress"
            Me.colShipAddress.Visible = True
            Me.colShipAddress.VisibleIndex = 9
            ' 
            ' colShipCity
            ' 
            Me.colShipCity.FieldName = "ShipCity"
            Me.colShipCity.Name = "colShipCity"
            Me.colShipCity.Visible = True
            Me.colShipCity.VisibleIndex = 10
            ' 
            ' colShipRegion
            ' 
            Me.colShipRegion.FieldName = "ShipRegion"
            Me.colShipRegion.Name = "colShipRegion"
            Me.colShipRegion.Visible = True
            Me.colShipRegion.VisibleIndex = 11
            ' 
            ' colShipPostalCode
            ' 
            Me.colShipPostalCode.FieldName = "ShipPostalCode"
            Me.colShipPostalCode.Name = "colShipPostalCode"
            Me.colShipPostalCode.Visible = True
            Me.colShipPostalCode.VisibleIndex = 12
            ' 
            ' colShipCountry
            ' 
            Me.colShipCountry.FieldName = "ShipCountry"
            Me.colShipCountry.Name = "colShipCountry"
            Me.colShipCountry.Visible = True
            Me.colShipCountry.VisibleIndex = 13
            ' 
            ' ordersTableAdapter
            ' 
            Me.ordersTableAdapter.ClearBeforeFill = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(986, 379)
            Me.Controls.Add(Me.myGridControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.myGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.ordersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.northwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.myGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private myGridControl1 As DXSample.MyGridControl
        Private myGridView1 As DXSample.MyGridView
        Private northwindDataSet As NorthwindDataSet
        Private ordersBindingSource As System.Windows.Forms.BindingSource
        Private ordersTableAdapter As NorthwindDataSetTableAdapters.OrdersTableAdapter
        Private colOrderID As DevExpress.XtraGrid.Columns.GridColumn
        Private colCustomerID As DevExpress.XtraGrid.Columns.GridColumn
        Private colEmployeeID As DevExpress.XtraGrid.Columns.GridColumn
        Private colOrderDate As DevExpress.XtraGrid.Columns.GridColumn
        Private colRequiredDate As DevExpress.XtraGrid.Columns.GridColumn
        Private colShippedDate As DevExpress.XtraGrid.Columns.GridColumn
        Private colShipVia As DevExpress.XtraGrid.Columns.GridColumn
        Private colFreight As DevExpress.XtraGrid.Columns.GridColumn
        Private colShipName As DevExpress.XtraGrid.Columns.GridColumn
        Private colShipAddress As DevExpress.XtraGrid.Columns.GridColumn
        Private colShipCity As DevExpress.XtraGrid.Columns.GridColumn
        Private colShipRegion As DevExpress.XtraGrid.Columns.GridColumn
        Private colShipPostalCode As DevExpress.XtraGrid.Columns.GridColumn
        Private colShipCountry As DevExpress.XtraGrid.Columns.GridColumn

    End Class
End Namespace

