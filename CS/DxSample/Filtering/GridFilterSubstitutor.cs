using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;

namespace DxSample.Filtering {
    public class GridFilterSubstitutor : ClientCriteriaLazyPatcherBase.AggregatesCommonProcessingBase
    {
        private static CriteriaOperator WrapIntoCustomFunction(CriteriaOperator param) {
            return new FunctionOperator(FunctionOperatorType.Custom, 
                new ConstantValue("RemoveDiacritics"), (CriteriaOperator)param);
        }

        public static CriteriaOperator Substitute(CriteriaOperator source) {
            return new GridFilterSubstitutor().Process(source);
        }

        public override CriteriaOperator Visit(FunctionOperator theOperator) {
            if (theOperator.OperatorType == FunctionOperatorType.StartsWith ||
                theOperator.OperatorType == FunctionOperatorType.EndsWith ||
                theOperator.OperatorType == FunctionOperatorType.Contains)
                return new FunctionOperator(theOperator.OperatorType,
                    WrapIntoCustomFunction(theOperator.Operands[0]),
                    WrapIntoCustomFunction(theOperator.Operands[1]));
            return base.Visit(theOperator);
        }
    }
}
