Imports DevExpress.Data.Filtering
Imports DevExpress.Utils.Extensions
Imports System
Imports System.Globalization
Imports System.Linq
Imports System.Text

Namespace DxSample.Filtering

    Public NotInheritable Class RemoveDiacriticsFunction
        Implements ICustomFunctionOperator

        Public Function Evaluate(ParamArray operands As Object()) As Object Implements ICustomFunctionOperator.Evaluate
            Dim src = CStr(operands(0))
            If Equals(src, Nothing) Then Return String.Empty
            Dim sb = New StringBuilder()
            src.Normalize(NormalizationForm.FormKD).Where(Function(c) Not IsDiacritic(c)).ForEach(Sub(c) sb.Append(c))
            Return sb.ToString()
        End Function

        Private Function IsDiacritic(ByVal symbol As Char) As Boolean
            Dim category = CharUnicodeInfo.GetUnicodeCategory(symbol)
            Return category = UnicodeCategory.NonSpacingMark OrElse category = UnicodeCategory.SpacingCombiningMark OrElse category = UnicodeCategory.EnclosingMark
        End Function

        Public ReadOnly Property Name As String Implements ICustomFunctionOperator.Name
            Get
                Return "RemoveDiacritics"
            End Get
        End Property

        Public Function ResultType(ParamArray operands As Type()) As Type Implements ICustomFunctionOperator.ResultType
            Return GetType(String)
        End Function
    End Class
End Namespace
