Imports DevExpress.Data.Filtering

Namespace DxSample.Filtering
    Public Class ClientCriteriaVisitorBase
        Implements IClientCriteriaVisitor(Of CriteriaOperator)

        Protected Sub New()
        End Sub

        Protected Function AcceptOperator(ByVal theOperator As CriteriaOperator) As CriteriaOperator
            If Object.ReferenceEquals(Nothing, theOperator) Then
                Return Nothing
            End If
            Return theOperator.Accept(Of CriteriaOperator)(Me)
        End Function

        Protected Function VisitOperands(ByVal operands As CriteriaOperatorCollection) As CriteriaOperatorCollection
            Dim isModified As Boolean = False
            Dim result As New CriteriaOperatorCollection(operands.Count)
            For Each operand As CriteriaOperator In operands
                Dim acceptedOperand As CriteriaOperator = Me.AcceptOperator(operand)
                result.Add(acceptedOperand)
                If Not Object.ReferenceEquals(operand, acceptedOperand) Then
                    isModified = True
                End If
            Next operand
            Return If(isModified, result, operands)
        End Function

        Protected Overridable Function VisitJoin(ByVal theOperand As JoinOperand) As CriteriaOperator
            Dim aggregatedExpression As CriteriaOperator = Me.AcceptOperator(theOperand.AggregatedExpression)
            Dim condition As CriteriaOperator = Me.AcceptOperator(theOperand.Condition)
            If Object.ReferenceEquals(theOperand.AggregatedExpression, aggregatedExpression) AndAlso Object.ReferenceEquals(theOperand.Condition, condition) Then
                Return theOperand
            End If
            Return New JoinOperand(theOperand.JoinTypeName, condition, theOperand.AggregateType, aggregatedExpression)
        End Function

        Protected Overridable Function VisitProperty(ByVal theOperand As OperandProperty) As CriteriaOperator
            Return theOperand
        End Function

        Protected Overridable Function VisitAggregate(ByVal theOperand As AggregateOperand) As CriteriaOperator
            Dim aggregatedExpression As CriteriaOperator = Me.AcceptOperator(theOperand.AggregatedExpression)
            Dim condition As CriteriaOperator = Me.AcceptOperator(theOperand.Condition)
            If Object.ReferenceEquals(theOperand.AggregatedExpression, aggregatedExpression) AndAlso Object.ReferenceEquals(theOperand.Condition, condition) Then
                Return theOperand
            End If
            Return New AggregateOperand(theOperand.CollectionProperty, aggregatedExpression, theOperand.AggregateType, condition)
        End Function

        Protected Overridable Function VisitFunction(ByVal theOperator As FunctionOperator) As CriteriaOperator
            Dim operands As CriteriaOperatorCollection = Me.VisitOperands(theOperator.Operands)
            If Object.ReferenceEquals(theOperator.Operands, operands) Then
                Return theOperator
            End If
            Return New FunctionOperator(theOperator.OperatorType, operands)
        End Function

        Protected Overridable Function VisitValue(ByVal theOperand As OperandValue) As CriteriaOperator
            Return theOperand
        End Function

        Protected Overridable Function VisitGroup(ByVal theOperator As GroupOperator) As CriteriaOperator
            Dim operands As CriteriaOperatorCollection = Me.VisitOperands(theOperator.Operands)
            If Object.ReferenceEquals(theOperator.Operands, operands) Then
                Return theOperator
            End If
            Return New GroupOperator(theOperator.OperatorType, operands)
        End Function

        Protected Overridable Function VisitIn(ByVal theOperator As InOperator) As CriteriaOperator
            Dim leftOperand As CriteriaOperator = Me.AcceptOperator(theOperator.LeftOperand)
            Dim operands As CriteriaOperatorCollection = Me.VisitOperands(theOperator.Operands)
            If Object.ReferenceEquals(theOperator.LeftOperand, leftOperand) AndAlso Object.ReferenceEquals(theOperator.Operands, operands) Then
                Return theOperator
            End If
            Return New InOperator(leftOperand, operands)
        End Function

        Protected Overridable Function VisitUnary(ByVal theOperator As UnaryOperator) As CriteriaOperator
            Dim operand As CriteriaOperator = Me.AcceptOperator(theOperator.Operand)
            If Object.ReferenceEquals(theOperator.Operand, operand) Then
                Return theOperator
            End If
            Return New UnaryOperator(theOperator.OperatorType, operand)
        End Function

        Protected Overridable Function VisitBinary(ByVal theOperator As BinaryOperator) As CriteriaOperator
            Dim leftOperand As CriteriaOperator = Me.AcceptOperator(theOperator.LeftOperand)
            Dim rightOperand As CriteriaOperator = Me.AcceptOperator(theOperator.RightOperand)
            If Object.ReferenceEquals(theOperator.LeftOperand, leftOperand) AndAlso Object.ReferenceEquals(theOperator.RightOperand, rightOperand) Then
                Return theOperator
            End If
            Return New BinaryOperator(leftOperand, rightOperand, theOperator.OperatorType)
        End Function

        Protected Overridable Function VisitBetween(ByVal theOperator As BetweenOperator) As CriteriaOperator
            Dim beginExpression As CriteriaOperator = Me.AcceptOperator(theOperator.BeginExpression)
            Dim endExpression As CriteriaOperator = Me.AcceptOperator(theOperator.EndExpression)
            Dim testExpression As CriteriaOperator = Me.AcceptOperator(theOperator.TestExpression)
            If Object.ReferenceEquals(theOperator.BeginExpression, beginExpression) AndAlso Object.ReferenceEquals(theOperator.EndExpression, endExpression) AndAlso Object.ReferenceEquals(theOperator.TestExpression, testExpression) Then
                Return theOperator
            End If
            Return New BetweenOperator(testExpression, beginExpression, endExpression)
        End Function

        #Region "IClientCriteriaVisitor"
        Private Function IClientCriteriaVisitorGeneric_Visit(ByVal theOperand As JoinOperand) As CriteriaOperator Implements IClientCriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitJoin(theOperand)
        End Function

        Private Function IClientCriteriaVisitorGeneric_Visit(ByVal theOperand As OperandProperty) As CriteriaOperator Implements IClientCriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitProperty(theOperand)
        End Function

        Private Function IClientCriteriaVisitorGeneric_Visit(ByVal theOperand As AggregateOperand) As CriteriaOperator Implements IClientCriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitAggregate(theOperand)
        End Function
        #End Region
        #Region "ICriteriaVisitor"
        Private Function ICriteriaVisitorGeneric_Visit(ByVal theOperator As FunctionOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitFunction(theOperator)
        End Function

        Private Function ICriteriaVisitorGeneric_Visit(ByVal theOperand As OperandValue) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitValue(theOperand)
        End Function

        Private Function ICriteriaVisitorGeneric_Visit(ByVal theOperator As GroupOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitGroup(theOperator)
        End Function

        Private Function ICriteriaVisitorGeneric_Visit(ByVal theOperator As InOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitIn(theOperator)
        End Function

        Private Function ICriteriaVisitorGeneric_Visit(ByVal theOperator As UnaryOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitUnary(theOperator)
        End Function

        Private Function ICriteriaVisitorGeneric_Visit(ByVal theOperator As BinaryOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitBinary(theOperator)
        End Function

        Private Function ICriteriaVisitorGeneric_Visit(ByVal theOperator As BetweenOperator) As CriteriaOperator Implements ICriteriaVisitor(Of CriteriaOperator).Visit
            Return Me.VisitBetween(theOperator)
        End Function
        #End Region
    End Class
End Namespace
