Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraGrid.Columns
Imports System.Text
Imports System.Globalization
Imports System.ComponentModel


Namespace DXSample
	<ToolboxItemAttribute(True)> _
	Public Class MyGridControl
		Inherits GridControl
		Protected Overrides Function CreateDefaultView() As BaseView
			Return CreateView("MyGridView")
		End Function
		Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
			MyBase.RegisterAvailableViewsCore(collection)
			collection.Add(New MyGridViewInfoRegistrator())
		End Sub
	End Class
	Public Class MyGridViewInfoRegistrator
		Inherits GridInfoRegistrator
		Public Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property
		Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
			Return New MyGridView(TryCast(grid, GridControl))
		End Function
	End Class
	Public Class MyGridView
		Inherits GridView
		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
		filteredColumns = New Dictionary(Of GridColumn, ColumnFilterInfo)()
		End Sub

		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property

		Private filteredColumns As Dictionary(Of GridColumn,ColumnFilterInfo) = Nothing
		Protected Overrides Function CreateAutoFilterCriterion(ByVal column As DevExpress.XtraGrid.Columns.GridColumn, ByVal condition As DevExpress.XtraGrid.Columns.AutoFilterCondition, ByVal _value As Object, ByVal strVal As String) As DevExpress.Data.Filtering.CriteriaOperator

			Dim op As CriteriaOperator = MyBase.CreateAutoFilterCriterion(column, condition, _value, strVal)
			If strVal.Length > 0 Then
				If (Not filteredColumns.ContainsKey(column)) Then
					filteredColumns.Add(column, New ColumnFilterInfo(ColumnFilterType.AutoFilter, _value, op, String.Empty))
				Else
					filteredColumns(column) = New ColumnFilterInfo(ColumnFilterType.AutoFilter, _value, op, String.Empty)
				End If
				Return op
			End If
			Return op
		End Function



		Public Shared Function RemoveDiacritics(ByVal src As String, ByVal compatNorm As Boolean) As String
			Dim sb As New StringBuilder()
			For Each c As Char In src.Normalize(If(compatNorm, NormalizationForm.FormKD, NormalizationForm.FormD))
				Select Case CharUnicodeInfo.GetUnicodeCategory(c)
					Case UnicodeCategory.NonSpacingMark, UnicodeCategory.SpacingCombiningMark, UnicodeCategory.EnclosingMark
						'do nothing
					Case Else
						sb.Append(c)
				End Select
			Next c

			Return sb.ToString()
		End Function



		Private Enum FilterResult
			NotProcessed = -1
			RowNotExists = 0
			RowExists
		End Enum
		Protected Overrides Function RaiseCustomRowFilter(ByVal listSourceRow As Integer) As Integer
			Dim result As Integer = MyBase.RaiseCustomRowFilter(listSourceRow)
			Dim IsCustomRowFilterEventHandled As Boolean = result <> -1
			If IsCustomRowFilterEventHandled Then
				Return result
			End If

			Dim filterString As String = String.Empty
			Dim operandType As DevExpress.XtraGrid.Columns.AutoFilterCondition = AutoFilterCondition.Default
			Dim filteredColumn As GridColumn = Nothing

			Dim filterResult As FilterResult = FilterResult.RowExists
			For Each filterPair As KeyValuePair(Of GridColumn, ColumnFilterInfo) In filteredColumns
				Dim filterInfo As ColumnFilterInfo = filterPair.Value
				If filterInfo.Type <> ColumnFilterType.AutoFilter Then
					Return CInt(Fix(FilterResult.NotProcessed))
				End If
				filteredColumn = filterPair.Key
				If filteredColumn.ColumnType IsNot GetType(String) Then
					filterResult = FilterResult.NotProcessed
					Continue For
				End If

				operandType = filteredColumn.OptionsFilter.AutoFilterCondition
				filterString = filterInfo.Value.ToString()

				Dim value As String = Me.GetRowCellDisplayText(listSourceRow, filteredColumn)
				If value = String.Empty Then
					filterResult = FilterResult.NotProcessed
					Continue For
				End If
				Dim processedString As String = RemoveDiacritics(value, True).ToLower()
				Dim filter As String = RemoveDiacritics(filterString, True).ToLower()
                If operandType = AutoFilterCondition.Like OrElse operandType = AutoFilterCondition.Default Then
                    If (Not processedString.StartsWith(filter)) Then
                        filterResult = filterResult.RowNotExists
                    End If
                End If
                If operandType = AutoFilterCondition.Contains Then
                    If (Not processedString.Contains(filter)) Then
                        filterResult = filterResult.RowNotExists
                    End If
                End If
                If operandType = AutoFilterCondition.Equals Then
                    If (Not processedString.Equals(filter)) Then
                        filterResult = filterResult.RowNotExists
                    End If
                End If

			Next filterPair

			Return CInt(Fix(filterResult))

		End Function

		Protected Overrides Sub RaiseColumnFilterChanged()
			MyBase.RaiseColumnFilterChanged()
			Dim columnsToRemove As New List(Of GridColumn)()
			For Each filterPair As KeyValuePair(Of GridColumn, ColumnFilterInfo) In filteredColumns
				Dim column As GridColumn = filterPair.Key
				If column.FilterInfo.FilterString = String.Empty Then
					columnsToRemove.Add(column)
				End If
			Next filterPair

			For i As Integer = 0 To columnsToRemove.Count - 1
				If filteredColumns.ContainsKey(columnsToRemove(i)) Then
					filteredColumns.Remove(columnsToRemove(i))
				End If
			Next i
			columnsToRemove.Clear()
			Me.RefreshData()
		End Sub



	End Class
End Namespace