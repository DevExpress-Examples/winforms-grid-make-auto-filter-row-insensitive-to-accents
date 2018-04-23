using DevExpress.Data.Filtering;

namespace DxSample.Filtering {
    public class GridFilterSubstitutor :ClientCriteriaVisitorBase {
        private static CriteriaOperator WrapIntoCustomFunction(CriteriaOperator param) {
            return new FunctionOperator(FunctionOperatorType.Custom, 
                new ConstantValue("RemoveDiacritics"), (CriteriaOperator)param);
        }

        public static CriteriaOperator Substitute(CriteriaOperator source) {
            return new GridFilterSubstitutor().AcceptOperator(source);
        }

        protected override CriteriaOperator VisitFunction(FunctionOperator theOperator) {
            if (theOperator.OperatorType == FunctionOperatorType.StartsWith ||
                theOperator.OperatorType == FunctionOperatorType.EndsWith ||
                theOperator.OperatorType == FunctionOperatorType.Contains)
                return new FunctionOperator(theOperator.OperatorType,
                    GridFilterSubstitutor.WrapIntoCustomFunction(theOperator.Operands[0]),
                    GridFilterSubstitutor.WrapIntoCustomFunction(theOperator.Operands[1]));
            return base.VisitFunction(theOperator);
        }
    }
}
