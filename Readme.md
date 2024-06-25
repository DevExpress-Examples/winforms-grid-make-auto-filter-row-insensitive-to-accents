<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128630351/18.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5021)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - How to make the Auto Filter Row insensitive to accents

This example demonstrates how to create a [custom function](https://docs.devexpress.com/WindowsForms/9947/common-features/expressions/implementing-custom-functions) that removes diacritic symbols from the specified string. The [GridView.SubstituteFilter](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnView.SubstituteFilter) event is handled to inject the custom function into the grid's active filter.

> **Note**
>
> The `SubstituteFilter` event is available in v15.1+. For older versions, create a custom grid control and customize the auto-filter row's behavior. You should override the `GridView.RaiseCustomRowFilter` method to normalize the cell text and filter string using the standard `String.Normalize` method. The cell value is processed based on the comparison operator type specified by the [OptionsColumnFilter.AutoFilterCondition](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Columns.OptionsColumnFilter.AutoFilterCondition) property.


## Files to Review

* [GridFilterSubstitutor.cs](./CS/DxSample/Filtering/GridFilterSubstitutor.cs) (VB: [GridFilterSubstitutor.vb](./VB/DxSample/Filtering/GridFilterSubstitutor.vb))
* [RemoveDiacriticsFunction.cs](./CS/DxSample/Filtering/RemoveDiacriticsFunction.cs) (VB: [RemoveDiacriticsFunction.vb](./VB/DxSample/Filtering/RemoveDiacriticsFunction.vb))
* [MainForm.cs](./CS/DxSample/MainForm.cs) (VB: [MainForm.vb](./VB/DxSample/MainForm.vb))
* [Program.cs](./CS/DxSample/Program.cs) (VB: [Program.vb](./VB/DxSample/Program.vb))
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-make-auto-filter-row-insensitive-to-accents&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-make-auto-filter-row-insensitive-to-accents&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
