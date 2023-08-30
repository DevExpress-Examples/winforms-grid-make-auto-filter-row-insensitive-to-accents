Imports System
Imports System.Globalization
Imports System.Text
Imports DevExpress.Data.Filtering

Namespace DxSample.Filtering

    Public NotInheritable Class RemoveDiacriticsFunction
        Implements ICustomFunctionOperator

        Private Function Evaluate(ParamArray operands As Object()) As Object Implements ICustomFunctionOperator.Evaluate
            Dim src As String = CStr(operands(0))
            If Equals(src, Nothing) Then Return String.Empty
            Dim sb As StringBuilder = New StringBuilder()
            For Each c As Char In src.Normalize(NormalizationForm.FormKD)
                Select Case CharUnicodeInfo.GetUnicodeCategory(c)
                    'do nothing
                    Case UnicodeCategory.NonSpacingMark, UnicodeCategory.SpacingCombiningMark, UnicodeCategory.EnclosingMark
                    Case Else
                        sb.Append(c)
                End Select
            Next

            Return sb.ToString()
        End Function

        Private ReadOnly Property Name As String Implements ICustomFunctionOperator.Name
            Get
                Return "RemoveDiacritics"
            End Get
        End Property

        Private Function ResultType(ParamArray operands As Type()) As Type Implements ICustomFunctionOperator.ResultType
            Return GetType(String)
        End Function
    End Class
End Namespace
