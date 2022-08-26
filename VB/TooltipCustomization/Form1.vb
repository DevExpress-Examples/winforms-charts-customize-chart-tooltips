Imports DevExpress.XtraCharts
Imports System
Imports System.Windows.Forms
Imports DevExpress.Utils

Namespace TooltipCustomization

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create an empty chart.
            Dim chartControl As ChartControl = New ChartControl()
            ' Add the chart to the form.
            chartControl.Dock = DockStyle.Fill
            Me.Controls.Add(chartControl)
            ' Create a series and add points to it.
            Dim series1 As Series = New Series("Series 1", ViewType.Bar)
            series1.Points.Add(New SeriesPoint("A", New Double() {4}))
            series1.Points.Add(New SeriesPoint("B", New Double() {2}))
            series1.Points.Add(New SeriesPoint("C", New Double() {17}))
            series1.Points.Add(New SeriesPoint("D", New Double() {4}))
            series1.Points.Add(New SeriesPoint("E", New Double() {17}))
            series1.Points.Add(New SeriesPoint("F", New Double() {12}))
            series1.Points.Add(New SeriesPoint("G", New Double() {15}))
            ' Add the series to the chart.
            chartControl.Series.Add(series1)
            ' Disable a crosshair cursor.
            chartControl.CrosshairEnabled = DefaultBoolean.False
            ' Enable chart tooltips. 
            chartControl.ToolTipEnabled = DefaultBoolean.True
            ' Show a tooltip's beak
            Dim controller As ToolTipController = New ToolTipController()
            chartControl.ToolTipController = controller
            controller.ShowBeak = True
            ' Change the default tooltip mouse position to relative position.
            Dim relativePosition As ToolTipRelativePosition = New ToolTipRelativePosition()
            chartControl.ToolTipOptions.ToolTipPosition = relativePosition
            ' Specify the tooltip relative position offsets.  
            relativePosition.OffsetX = 2
            relativePosition.OffsetY = 2
            ' Specify the tooltip point pattern.
            series1.ToolTipPointPattern = "Bar Series: {A}:{V}"
        End Sub
    End Class
End Namespace
