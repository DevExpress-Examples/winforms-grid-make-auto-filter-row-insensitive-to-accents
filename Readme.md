<!-- default file list -->
*Files to look at*:

* [ClientCriteriaVisitorBase.cs](./CS/DxSample/Filtering/ClientCriteriaVisitorBase.cs) (VB: [ClientCriteriaVisitorBase.vb](./VB/DxSample/Filtering/ClientCriteriaVisitorBase.vb))
* [GridFilterSubstitutor.cs](./CS/DxSample/Filtering/GridFilterSubstitutor.cs) (VB: [GridFilterSubstitutor.vb](./VB/DxSample/Filtering/GridFilterSubstitutor.vb))
* [RemoveDiacriticsFunction.cs](./CS/DxSample/Filtering/RemoveDiacriticsFunction.cs) (VB: [RemoveDiacriticsFunction.vb](./VB/DxSample/Filtering/RemoveDiacriticsFunction.vb))
* [MainForm.cs](./CS/DxSample/MainForm.cs) (VB: [MainForm.vb](./VB/DxSample/MainForm.vb))
* [Program.cs](./CS/DxSample/Program.cs) (VB: [Program.vb](./VB/DxSample/Program.vb))
<!-- default file list end -->
# How to make the auto filter row's filter accent insensitive


<p>This example demonstrates how to create a <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument9947">custom function</a> that removes all diacritic symbols from the specified string value. Using the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_SubstituteFiltertopic">GridView.SubstituteFilter</a> event, this function can be injected into the active grid filter.<br><br>The SubstituteFilter event was added in version <strong>2015 vol 1</strong>. To accomplish this task in older version, create a custom grid and customize the mechanism of filtering data via the auto filter row. For this, the GridView.RaiseCustomRowFilter method can be overridden. In this method, the cell text and filter string should be normalized via the standard String.Normalize method and then the cell value is processed based on the comparison operator type returned via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridColumnsOptionsColumnFilter_AutoFilterConditiontopic"><u>OptionsColumnFilter.AutoFilterCondition</u></a> property.<br><br><strong></p>



