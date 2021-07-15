Imports DevExpress.XtraCharts
Imports System
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports System.Collections.Generic
Imports System.Data

Namespace TooltipCustomization
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub
		' Create a data source.  
		Public Class TestChartData
			Public Property Argument() As String
			Public Property Value() As Double
			Public Property Comment() As String
			Public Sub New(ByVal arguments As String, ByVal value As Double, ByVal comment As String)
				Argument = arguments
				Me.Value = value
				Me.Comment = comment
			End Sub

		End Class
		Private Function CreateChartData() As List(Of TestChartData)
			Dim list = New List(Of TestChartData)()
			list.Add(New TestChartData("A", 4, "comment for A"))
			list.Add(New TestChartData("B", 2, "comment for B"))
			list.Add(New TestChartData("C", 17, "comment for C"))
			list.Add(New TestChartData("D", 4, "comment for D"))
			list.Add(New TestChartData("E", 17, "comment for E"))
			list.Add(New TestChartData("F", 12, "comment for F"))
			list.Add(New TestChartData("G", 15, "comment for G"))
			Return list
		End Function

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			' Create an empty chart.
			Dim chartControl As New ChartControl()

			' Add the chart to the form.
			chartControl.Dock = DockStyle.Fill
			Me.Controls.Add(chartControl)

			' Create a series and add points to it.
			Dim boundSeries As New Series("Bound Series", ViewType.Line)
			' Assign the created data source to the series.
			boundSeries.DataSource = CreateChartData()
			boundSeries.ArgumentScaleType = ScaleType.Auto
			boundSeries.ArgumentDataMember = "Argument"
			boundSeries.ValueScaleType = ScaleType.Numerical
			boundSeries.ValueDataMembers.AddRange(New String() { "Value" })

			Dim unboundSeries As New Series("Unbound Series", ViewType.Line)
			unboundSeries.Points.Add(New SeriesPoint("A", New Double() { 9 }))
			unboundSeries.Points.Add(New SeriesPoint("B", New Double() { 7 }))
			unboundSeries.Points.Add(New SeriesPoint("C", New Double() { 23 }))
			unboundSeries.Points.Add(New SeriesPoint("D", New Double() { 9 }))
			unboundSeries.Points.Add(New SeriesPoint("E", New Double() { 23 }))
			unboundSeries.Points.Add(New SeriesPoint("F", New Double() { 17 }))
			unboundSeries.Points.Add(New SeriesPoint("G", New Double() { 20 }))

			Dim unboundSeriesWithTag As New Series("Unbound Series with Tag", ViewType.Line)
			unboundSeriesWithTag.Points.Add(New SeriesPoint("A", 2) With {
				.Tag = New With {Key .Test = "TestValue"}
			})
			unboundSeriesWithTag.Points.Add(New SeriesPoint("B", 0) With {
				.Tag = New With {Key .Test = "TestValue"}
			})
			unboundSeriesWithTag.Points.Add(New SeriesPoint("C", 15) With {
				.Tag = New With {Key .Test = "TestValue"}
			})
			unboundSeriesWithTag.Points.Add(New SeriesPoint("D", 2) With {
				.Tag = New With {Key .Test = "TestValue"}
			})
			unboundSeriesWithTag.Points.Add(New SeriesPoint("E", 15) With {
				.Tag = New With {Key .Test = "TestValue"}
			})
			unboundSeriesWithTag.Points.Add(New SeriesPoint("F", 10) With {
				.Tag = New With {Key .Test = "TestValue"}
			})
			unboundSeriesWithTag.Points.Add(New SeriesPoint("G", 13) With {
				.Tag = New With {Key .Test = "TestValue"}
			})

			' Add the series to the chart.
			chartControl.Series.AddRange(unboundSeries, unboundSeriesWithTag, boundSeries)
			' Enable data point markers.
			CType(unboundSeries.View, LineSeriesView).MarkerVisibility = DefaultBoolean.True
			CType(unboundSeriesWithTag.View, LineSeriesView).MarkerVisibility = DefaultBoolean.True
			CType(boundSeries.View, LineSeriesView).MarkerVisibility = DefaultBoolean.True
			' Disable a crosshair cursor.
			chartControl.CrosshairEnabled = DefaultBoolean.False

			' Enable chart tooltips. 
			chartControl.ToolTipEnabled = DefaultBoolean.True

			' Show a tooltip's beak.
			Dim controller As New ToolTipController()
			chartControl.ToolTipController = controller
			controller.ShowBeak = True

			' Change the default tooltip mouse position to relative position.
			Dim relativePosition As New ToolTipRelativePosition()
			chartControl.ToolTipOptions.ToolTipPosition = relativePosition

			' Specify the tooltip relative position offsets.  
			relativePosition.OffsetX = 2
			relativePosition.OffsetY = 2

			' Specify the tooltip point pattern.
			unboundSeries.ToolTipPointPattern = "Line Series: {A}:{V}"
			unboundSeriesWithTag.ToolTipPointPattern = "{A}: {V} ({Test})"
			boundSeries.ToolTipPointPattern = "{A}: {V} ({Comment})"
		End Sub
	End Class
End Namespace
