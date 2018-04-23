using System;
using System.Globalization;
using System.Text;
using DevExpress.Data.Filtering;

namespace DxSample.Filtering {
    public sealed class RemoveDiacriticsFunction : ICustomFunctionOperator {
        object ICustomFunctionOperator.Evaluate(params object[] operands) {
            string src = (string)operands[0];
            if (src == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (char c in src.Normalize(NormalizationForm.FormKD))
                switch (CharUnicodeInfo.GetUnicodeCategory(c))
                {
                    case UnicodeCategory.NonSpacingMark:
                    case UnicodeCategory.SpacingCombiningMark:
                    case UnicodeCategory.EnclosingMark:
                        //do nothing
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            
            return sb.ToString();
        }

        string ICustomFunctionOperator.Name {
            get { return "RemoveDiacritics"; }
        }

        Type ICustomFunctionOperator.ResultType(params Type[] operands) {
            return typeof(string);
        }
    }
}
