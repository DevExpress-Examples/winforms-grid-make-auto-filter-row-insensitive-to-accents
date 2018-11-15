<!-- default file list -->
*Files to look at*:

* [Custom Grid.cs](./CS/CustomAutoFilterRowFiltering/Custom Grid.cs) (VB: [Custom Grid.vb](./VB/CustomAutoFilterRowFiltering/Custom Grid.vb))
* **[Form1.cs](./CS/CustomAutoFilterRowFiltering/Form1.cs)**
<!-- default file list end -->
# How to make the auto filter row's filter accent insensitive


<p>This example demonstrates how to create a <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument9947">custom function</a> that removes all diacritic symbols from the specified string value. Using the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_SubstituteFiltertopic">GridView.SubstituteFilter</a> event, this function can be injected into the active grid filter.<br><br>The SubstituteFilter event was added in version 2015 vol 1. To accomplish this task in older version, create a custom grid and customize the mechanism of filtering data via the auto filter row. For this, the GridView.RaiseCustomRowFilter method can be overridden. In this method, the cell text and filter string should be normalized via the standard String.Normalize method and then the cell value is processed based on the comparison operator type returned via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridColumnsOptionsColumnFilter_AutoFilterConditiontopic"><u>OptionsColumnFilter.AutoFilterCondition</u></a> property.<br><br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T385990">How to make the Grid's filter to be a case- and accent-insensitive in Server Mode</a></p>

<br/>


