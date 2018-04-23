Imports System
Imports System.Globalization
Imports System.Text
Imports DevExpress.Data.Filtering

Namespace DxSample.Filtering
    Public NotInheritable Class RemoveDiacriticsFunction
        Implements ICustomFunctionOperator

        Private Function ICustomFunctionOperator_Evaluate(ParamArray ByVal operands() As Object) As Object Implements ICustomFunctionOperator.Evaluate
            Dim src As String = DirectCast(operands(0), String)
            If src Is Nothing Then
                Return String.Empty
            End If

            Dim sb As New StringBuilder()
            For Each c As Char In src.Normalize(NormalizationForm.FormKD)
                Select Case CharUnicodeInfo.GetUnicodeCategory(c)
                    Case UnicodeCategory.NonSpacingMark, UnicodeCategory.SpacingCombiningMark, UnicodeCategory.EnclosingMark
                        'do nothing
                    Case Else
                        sb.Append(c)
                End Select
            Next c

            Return sb.ToString()
        End Function

        Private ReadOnly Property ICustomFunctionOperator_Name() As String Implements ICustomFunctionOperator.Name
            Get
                Return "RemoveDiacritics"
            End Get
        End Property

        Private Function ICustomFunctionOperator_ResultType(ParamArray ByVal operands() As Type) As Type Implements ICustomFunctionOperator.ResultType
            Return GetType(String)
        End Function
    End Class
End Namespace
