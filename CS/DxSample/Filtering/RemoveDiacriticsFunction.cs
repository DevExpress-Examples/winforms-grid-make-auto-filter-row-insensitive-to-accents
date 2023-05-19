using DevExpress.Data.Filtering;
using DevExpress.Utils.Extensions;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DxSample.Filtering {
    public sealed class RemoveDiacriticsFunction : ICustomFunctionOperator {
        public object Evaluate(params object[] operands) {
            var src = (string)operands[0];
            if (src == null)
                return string.Empty;

            var sb = new StringBuilder();

            src.Normalize(NormalizationForm.FormKD)
                .Where(c => !IsDiacritic(c))
                .ForEach(c => sb.Append(c));

            return sb.ToString();
        }

        private bool IsDiacritic(char symbol) {
            var category = CharUnicodeInfo.GetUnicodeCategory(symbol);

            return category == UnicodeCategory.NonSpacingMark ||
                   category == UnicodeCategory.SpacingCombiningMark ||
                   category == UnicodeCategory.EnclosingMark;
        }

        public string Name => "RemoveDiacritics";

        public Type ResultType(params Type[] operands) => typeof(string);
    }
}