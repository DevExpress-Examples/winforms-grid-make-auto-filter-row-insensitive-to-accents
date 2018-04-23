using DevExpress.Data.Filtering;

namespace DxSample.Filtering {
    public class ClientCriteriaVisitorBase : IClientCriteriaVisitor<CriteriaOperator> {
        protected ClientCriteriaVisitorBase() { }

        protected CriteriaOperator AcceptOperator(CriteriaOperator theOperator) {
            if (object.ReferenceEquals(null, theOperator)) return null;
            return theOperator.Accept<CriteriaOperator>(this);
        }

        protected CriteriaOperatorCollection VisitOperands(CriteriaOperatorCollection operands) {
            bool isModified = false;
            CriteriaOperatorCollection result = new CriteriaOperatorCollection(operands.Count);
            foreach (CriteriaOperator operand in operands) {
                CriteriaOperator acceptedOperand = this.AcceptOperator(operand);
                result.Add(acceptedOperand);
                if (!object.ReferenceEquals(operand, acceptedOperand))
                    isModified = true;
            }
            return isModified ? result : operands;
        }

        protected virtual CriteriaOperator VisitJoin(JoinOperand theOperand) {
            CriteriaOperator aggregatedExpression = this.AcceptOperator(theOperand.AggregatedExpression);
            CriteriaOperator condition = this.AcceptOperator(theOperand.Condition);
            if (object.ReferenceEquals(theOperand.AggregatedExpression, aggregatedExpression) &&
                object.ReferenceEquals(theOperand.Condition, condition))
                return theOperand;
            return new JoinOperand(theOperand.JoinTypeName, condition, theOperand.AggregateType, aggregatedExpression);
        }

        protected virtual CriteriaOperator VisitProperty(OperandProperty theOperand) {
            return theOperand;
        }

        protected virtual CriteriaOperator VisitAggregate(AggregateOperand theOperand) {
            CriteriaOperator aggregatedExpression = this.AcceptOperator(theOperand.AggregatedExpression);
            CriteriaOperator condition = this.AcceptOperator(theOperand.Condition);
            if (object.ReferenceEquals(theOperand.AggregatedExpression, aggregatedExpression) &&
                object.ReferenceEquals(theOperand.Condition, condition))
                return theOperand;
            return new AggregateOperand(theOperand.CollectionProperty, aggregatedExpression, theOperand.AggregateType, condition);
        }

        protected virtual CriteriaOperator VisitFunction(FunctionOperator theOperator) {
            CriteriaOperatorCollection operands = this.VisitOperands(theOperator.Operands);
            if (object.ReferenceEquals(theOperator.Operands, operands))
                return theOperator;
            return new FunctionOperator(theOperator.OperatorType, operands);
        }

        protected virtual CriteriaOperator VisitValue(OperandValue theOperand) {
            return theOperand;
        }

        protected virtual CriteriaOperator VisitGroup(GroupOperator theOperator) {
            CriteriaOperatorCollection operands = this.VisitOperands(theOperator.Operands);
            if (object.ReferenceEquals(theOperator.Operands, operands))
                return theOperator;
            return new GroupOperator(theOperator.OperatorType, operands);
        }

        protected virtual CriteriaOperator VisitIn(InOperator theOperator) {
            CriteriaOperator leftOperand = this.AcceptOperator(theOperator.LeftOperand);
            CriteriaOperatorCollection operands = this.VisitOperands(theOperator.Operands);
            if (object.ReferenceEquals(theOperator.LeftOperand, leftOperand) &&
                object.ReferenceEquals(theOperator.Operands, operands))
                return theOperator;
            return new InOperator(leftOperand, operands);
        }

        protected virtual CriteriaOperator VisitUnary(UnaryOperator theOperator) {
            CriteriaOperator operand = this.AcceptOperator(theOperator.Operand);
            if (object.ReferenceEquals(theOperator.Operand, operand))
                return theOperator;
            return new UnaryOperator(theOperator.OperatorType, operand);
        }

        protected virtual CriteriaOperator VisitBinary(BinaryOperator theOperator) {
            CriteriaOperator leftOperand = this.AcceptOperator(theOperator.LeftOperand);
            CriteriaOperator rightOperand = this.AcceptOperator(theOperator.RightOperand);
            if (object.ReferenceEquals(theOperator.LeftOperand, leftOperand) &&
                object.ReferenceEquals(theOperator.RightOperand, rightOperand))
                return theOperator;
            return new BinaryOperator(leftOperand, rightOperand, theOperator.OperatorType);
        }

        protected virtual CriteriaOperator VisitBetween(BetweenOperator theOperator) {
            CriteriaOperator beginExpression = this.AcceptOperator(theOperator.BeginExpression);
            CriteriaOperator endExpression = this.AcceptOperator(theOperator.EndExpression);
            CriteriaOperator testExpression = this.AcceptOperator(theOperator.TestExpression);
            if (object.ReferenceEquals(theOperator.BeginExpression, beginExpression) &&
                object.ReferenceEquals(theOperator.EndExpression, endExpression) &&
                object.ReferenceEquals(theOperator.TestExpression, testExpression))
                return theOperator;
            return new BetweenOperator(testExpression, beginExpression, endExpression);
        }

        #region IClientCriteriaVisitor
        CriteriaOperator IClientCriteriaVisitor<CriteriaOperator>.Visit(JoinOperand theOperand) {
            return this.VisitJoin(theOperand);
        }

        CriteriaOperator IClientCriteriaVisitor<CriteriaOperator>.Visit(OperandProperty theOperand) {
            return this.VisitProperty(theOperand);
        }

        CriteriaOperator IClientCriteriaVisitor<CriteriaOperator>.Visit(AggregateOperand theOperand) {
            return this.VisitAggregate(theOperand);
        }
        #endregion
        #region ICriteriaVisitor
        CriteriaOperator ICriteriaVisitor<CriteriaOperator>.Visit(FunctionOperator theOperator) {
            return this.VisitFunction(theOperator);
        }

        CriteriaOperator ICriteriaVisitor<CriteriaOperator>.Visit(OperandValue theOperand) {
            return this.VisitValue(theOperand);
        }

        CriteriaOperator ICriteriaVisitor<CriteriaOperator>.Visit(GroupOperator theOperator) {
            return this.VisitGroup(theOperator);
        }

        CriteriaOperator ICriteriaVisitor<CriteriaOperator>.Visit(InOperator theOperator) {
            return this.VisitIn(theOperator);
        }

        CriteriaOperator ICriteriaVisitor<CriteriaOperator>.Visit(UnaryOperator theOperator) {
            return this.VisitUnary(theOperator);
        }

        CriteriaOperator ICriteriaVisitor<CriteriaOperator>.Visit(BinaryOperator theOperator) {
            return this.VisitBinary(theOperator);
        }

        CriteriaOperator ICriteriaVisitor<CriteriaOperator>.Visit(BetweenOperator theOperator) {
            return this.VisitBetween(theOperator);
        }
        #endregion
    }
}
