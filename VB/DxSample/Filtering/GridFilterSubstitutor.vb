Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Filtering.Helpers

Namespace DxSample.Filtering

    Public Class GridFilterSubstitutor
        Inherits ClientCriteriaLazyPatcherBase.AggregatesCommonProcessingBase

        Private Shared Function WrapIntoCustomFunction(ByVal param As CriteriaOperator) As CriteriaOperator
            Return New FunctionOperator(FunctionOperatorType.Custom, New ConstantValue("RemoveDiacritics"), param)
        End Function

        Public Shared Function Substitute(ByVal source As CriteriaOperator) As CriteriaOperator
            Return New GridFilterSubstitutor().Process(source)
        End Function

        Public Overrides Function Visit(ByVal theOperator As FunctionOperator) As CriteriaOperator
            If theOperator.OperatorType = FunctionOperatorType.StartsWith OrElse theOperator.OperatorType = FunctionOperatorType.EndsWith OrElse theOperator.OperatorType = FunctionOperatorType.Contains Then Return New FunctionOperator(theOperator.OperatorType, WrapIntoCustomFunction(theOperator.Operands(0)), WrapIntoCustomFunction(theOperator.Operands(1)))
            Return MyBase.Visit(theOperator)
        End Function
    End Class
End Namespace
