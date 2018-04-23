using System;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using System.Text;
using System.Globalization;
using System.ComponentModel;


namespace DXSample {
    [ToolboxItemAttribute(true)]
    public class MyGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            return CreateView("MyGridView");
        }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridViewInfoRegistrator());
        }
    }
    public class MyGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "MyGridView"; } }
        public override BaseView CreateView(GridControl grid) { return new MyGridView(grid as GridControl); }
    }
    public class MyGridView : GridView
    {
        public MyGridView() : this(null) { }
        public MyGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) { filteredColumns = new Dictionary<GridColumn, ColumnFilterInfo>(); }

        protected override string ViewName { get { return "MyGridView"; } }

        Dictionary<GridColumn,ColumnFilterInfo> filteredColumns = null;
        protected override DevExpress.Data.Filtering.CriteriaOperator CreateAutoFilterCriterion(DevExpress.XtraGrid.Columns.GridColumn column, DevExpress.XtraGrid.Columns.AutoFilterCondition condition, object _value, string strVal)
        {

            CriteriaOperator op = base.CreateAutoFilterCriterion(column, condition, _value, strVal);
            if (strVal.Length > 0)
            {
                if (!filteredColumns.ContainsKey(column))
                    filteredColumns.Add(column, new ColumnFilterInfo(ColumnFilterType.AutoFilter, _value, op, string.Empty));
                else
                    filteredColumns[column] = new ColumnFilterInfo(ColumnFilterType.AutoFilter, _value, op, string.Empty);
                return op;
            }
            return op;
        }


 
        public static string RemoveDiacritics(string src, bool compatNorm)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in src.Normalize(compatNorm ? NormalizationForm.FormKD : NormalizationForm.FormD))
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
 

   
        enum FilterResult{ NotProcessed = -1, RowNotExists = 0, RowExists};
        
        protected override int RaiseCustomRowFilter(int listSourceRow, bool fit)
        {
            int result = base.RaiseCustomRowFilter(listSourceRow,fit);
            bool IsCustomRowFilterEventHandled = result != -1;
            if (IsCustomRowFilterEventHandled) return result;

            string filterString = string.Empty;
            DevExpress.XtraGrid.Columns.AutoFilterCondition operandType = AutoFilterCondition.Default;
            GridColumn filteredColumn = null;

            FilterResult filterResult = FilterResult.RowExists;
            foreach (KeyValuePair<GridColumn, ColumnFilterInfo> filterPair in filteredColumns)
            {
                ColumnFilterInfo filterInfo = filterPair.Value;
                if (filterInfo.Type != ColumnFilterType.AutoFilter)
                    return (int)FilterResult.NotProcessed;
                filteredColumn = filterPair.Key;
                if (filteredColumn.ColumnType != typeof(string))
                {
                    filterResult = FilterResult.NotProcessed;
                    continue;
                }

                operandType = filteredColumn.OptionsFilter.AutoFilterCondition;
                filterString = filterInfo.Value.ToString();

                string value = this.GetRowCellDisplayText(listSourceRow, filteredColumn);
                if (value == string.Empty)
                {
                    filterResult = FilterResult.NotProcessed;
                    continue;
                }
                string processedString = RemoveDiacritics(value, true).ToLower();
                string filter = RemoveDiacritics(filterString, true).ToLower();
                if (operandType == AutoFilterCondition.Like || operandType == AutoFilterCondition.Default)
                {
                    if (!processedString.StartsWith(filter))
                    {
                        filterResult = FilterResult.RowNotExists;
                    }
                }
                if (operandType == AutoFilterCondition.Contains)
                {
                    if (!processedString.Contains(filter))
                    {
                        filterResult = FilterResult.RowNotExists;
                    }
                }
                if (operandType == AutoFilterCondition.Equals)
                {
                    if (!processedString.Equals(filter))
                    {
                        filterResult = FilterResult.RowNotExists;
                    }
                }

            }

            return (int)filterResult;
        
        }

        protected override void RaiseColumnFilterChanged()
        {
            base.RaiseColumnFilterChanged();
            List<GridColumn> columnsToRemove = new List<GridColumn>();
            foreach (KeyValuePair<GridColumn, ColumnFilterInfo> filterPair in filteredColumns)
            {
                GridColumn column = filterPair.Key;
                if (column.FilterInfo.FilterString == string.Empty)
                {
                    columnsToRemove.Add(column);
                }
            }

            for (int i = 0; i < columnsToRemove.Count; i++)
            {
                if (filteredColumns.ContainsKey(columnsToRemove[i]))
                    filteredColumns.Remove(columnsToRemove[i]);
            }
            columnsToRemove.Clear();
            this.RefreshData();
        } 
 

          
    }
}