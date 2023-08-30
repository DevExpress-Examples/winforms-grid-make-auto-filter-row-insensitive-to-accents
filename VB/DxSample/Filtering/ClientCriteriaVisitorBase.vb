Imports DevExpress.Data.Filtering

Namespace DxSample.Filtering

    Public Class ClientCriteriaVisitorBase
        Implements IClientCriteriaVisitor(Of CriteriaOperator)

        Protected Sub New()
        End Sub

        Protected Function AcceptOperator(ByVal theOperator As CriteriaOperator) As CriteriaOperator
            If ReferenceEquals(Nothing, theOperator) Then Return Nothing
            Return theOperator.Accept(Me)
        End Function

        Protected Function VisitOperands(ByVal operands As CriteriaOperatorCollection) As CriteriaOperatorCollection
            Dim isModified As Boolean = False
            Dim result As CriteriaOperatorCollection = New CriteriaOperatorCollection(operands.Count)
            For Each operand As CriteriaOperator In operands
                Dim acceptedOperand As CriteriaOperator = AcceptOperator(operand)
                result.Add(acceptedOperand)
                If Not ReferenceEquals(operand, acceptedOperand) Then isModified = True
            Next

            Return If(isModified, result, operands)
        End Function

        Protected Overridable Function VisitJoin(ByVal theOperand As JoinOperand) As CriteriaOperator
            Dim aggregatedExpression As CriteriaOperator = AcceptOperator(theOperand.AggregatedExpression)
            Dim condition As CriteriaOperator = AcceptOperator(theOperand.Condition)
            If ReferenceEquals(theOperand.AggregatedExpression, aggregatedExpression) AndAlso ReferenceEquals(theOperand.Condition, condition) Then Return theOperand
            Return New JoinOperand(theOperand.JoinTypeName, condition, theOperand.AggregateType, aggregatedExpression)
        End Function

        Protected Overridable Function VisitProperty(ByVal theOperand As OperandProperty) As CriteriaOperator
            Return theOperand
        End Function

        Protected Overridable Function VisitAggregate(ByVal theOperand As AggregateOperand) As CriteriaOperator
            Dim aggregatedExpression As CriteriaOperator = AcceptOperator(theOperand.AggregatedExpression)
            Dim condition As CriteriaOperator = AcceptOperator(theOperand.Condition)
            If ReferenceEquals(theOperand.AggregatedExpression, aggregatedExpression) AndAlso ReferenceEquals(theOperand.Condition, condition) Then Return theOperand
            Return New AggregateOperand(theOperand.CollectionProperty, aggregatedExpression, theOperand.AggregateType, condition)
        End Function

        Protected Overridable Function VisitFunction(ByVal theOperator As FunctionOperator) As CriteriaOperator
            Dim operands As CriteriaOperatorCollection = VisitOperands(theOperator.Operands)
            If ReferenceEquals(theOperator.Operands, operands) Then Return theOperator
            Return New FunctionOperator(theOperator.OperatorType, operands)
        End Function

        Protected Overridable Function VisitValue(ByVal theOperand As OperandValue) As CriteriaOperator
            Return theOperand
        End Function

        Protected Overridable Function VisitGroup(ByVal theOperator As GroupOperator) As CriteriaOperator
            Dim operands As CriteriaOperatorCollection = VisitOperands(theOperator.Operands)
            If ReferenceEquals(theOperator.Operands, operands) Then Return theOperator
            Return New GroupOperator(theOperator.OperatorType, operands)
        End Function

        Protected Overridable Function VisitIn(ByVal theOperator As InOperator) As CriteriaOperator
            Dim leftOperand As CriteriaOperator = AcceptOperator(theOperator.LeftOperand)
            Dim operands As CriteriaOperatorCollection = VisitOperands(theOperator.Operands)
            If ReferenceEquals(theOperator.LeftOperand, leftOperand) AndAlso ReferenceEquals(theOperator.Operands, operands) Then Return theOperator
            Return New InOperator(leftOperand, operands)
        End Function

        Protected Overridable Function VisitUnary(ByVal theOperator As UnaryOperator) As CriteriaOperator
            Dim operand As CriteriaOperator = AcceptOperator(theOperator.Operand)
            If ReferenceEquals(theOperator.Operand, operand) Then Return theOperator
            Return New UnaryOperator(theOperator.OperatorType, operand)
        End Function

        Protected Overridable Function VisitBinary(ByVal theOperator As BinaryOperator) As CriteriaOperator
            Dim leftOperand As CriteriaOperator = AcceptOperator(theOperator.LeftOperand)
            Dim rightOperand As CriteriaOperator = AcceptOperator(theOperator.RightOperand)
            If ReferenceEquals(theOperator.LeftOperand, leftOperand) AndAlso ReferenceEquals(theOperator.RightOperand, rightOperand) Then Return theOperator
            Return New BinaryOperator(leftOperand, rightOperand, theOperator.OperatorType)
        End Function

        Protected Overridable Function VisitBetween(ByVal theOperator As BetweenOperator) As CriteriaOperator
            Dim beginExpression As CriteriaOperator = AcceptOperator(theOperator.BeginExpression)
            Dim endExpression As CriteriaOperator = AcceptOperator(theOperator.EndExpression)
            Dim testExpression As CriteriaOperator = AcceptOperator(theOperator.TestExpression)
            If ReferenceEquals(theOperator.BeginExpression, beginExpression) AndAlso ReferenceEquals(theOperator.EndExpression, endExpression) AndAlso ReferenceEquals(theOperator.TestExpression, testExpression) Then Return theOperator
            Return New BetweenOperator(testExpression, beginExpression, endExpression)
        End Function

'#Region "IClientCriteriaVisitor"
        Private Function IClientCriteriaVisitor_Visit(ByVal theOperand As JoinOperand) As CriteriaOperator Implements IClientCriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitJoin(theOperand)
        End Function

        Private Function IClientCriteriaVisitor_Visit1(ByVal theOperand As OperandProperty) As CriteriaOperator Implements IClientCriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitProperty(theOperand)
        End Function

        Private Function IClientCriteriaVisitor_Visit2(ByVal theOperand As AggregateOperand) As CriteriaOperator Implements IClientCriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitAggregate(theOperand)
        End Function

'#End Region
'#Region "ICriteriaVisitor"
        Private Function ICriteriaVisitor_Visit(ByVal theOperator As FunctionOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitFunction(theOperator)
        End Function

        Private Function ICriteriaVisitor_Visit1(ByVal theOperand As OperandValue) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitValue(theOperand)
        End Function

        Private Function ICriteriaVisitor_Visit2(ByVal theOperator As GroupOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitGroup(theOperator)
        End Function

        Private Function ICriteriaVisitor_Visit3(ByVal theOperator As InOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitIn(theOperator)
        End Function

        Private Function ICriteriaVisitor_Visit4(ByVal theOperator As UnaryOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitUnary(theOperator)
        End Function

        Private Function ICriteriaVisitor_Visit5(ByVal theOperator As BinaryOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitBinary(theOperator)
        End Function

        Private Function ICriteriaVisitor_Visit6(ByVal theOperator As BetweenOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return VisitBetween(theOperator)
        End Function
'#End Region
    End Class
End Namespace
