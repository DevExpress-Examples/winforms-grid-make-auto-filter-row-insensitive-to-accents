Imports DevExpress.Data.Filtering

Namespace DxSample.Filtering
    Public Class GridFilterSubstitutor
        Inherits ClientCriteriaVisitorBase

        Private Shared Function WrapIntoCustomFunction(ByVal param As CriteriaOperator) As CriteriaOperator
            Return New FunctionOperator(FunctionOperatorType.Custom, New ConstantValue("RemoveDiacritics"), CType(param, CriteriaOperator))
        End Function

        Public Shared Function Substitute(ByVal source As CriteriaOperator) As CriteriaOperator
            Return (New GridFilterSubstitutor()).AcceptOperator(source)
        End Function

        Protected Overrides Function VisitFunction(ByVal theOperator As FunctionOperator) As CriteriaOperator
            If theOperator.OperatorType = FunctionOperatorType.StartsWith OrElse theOperator.OperatorType = FunctionOperatorType.EndsWith OrElse theOperator.OperatorType = FunctionOperatorType.Contains Then
                Return New FunctionOperator(theOperator.OperatorType, GridFilterSubstitutor.WrapIntoCustomFunction(theOperator.Operands(0)), GridFilterSubstitutor.WrapIntoCustomFunction(theOperator.Operands(1)))
            End If
            Return MyBase.VisitFunction(theOperator)
        End Function
    End Class
End Namespace
