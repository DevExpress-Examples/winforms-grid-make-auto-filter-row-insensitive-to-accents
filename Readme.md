<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128630351/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5021)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
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



<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-make-auto-filter-row-insensitive-to-accents&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-make-auto-filter-row-insensitive-to-accents&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
