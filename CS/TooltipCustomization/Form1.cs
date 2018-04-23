using DevExpress.XtraCharts;
using System;
using System.Windows.Forms;
using DevExpress.Utils;

namespace TooltipCustomization {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create an empty chart.
            ChartControl chartControl = new ChartControl();

            // Add the chart to the form.
            chartControl.Dock = DockStyle.Fill;
            this.Controls.Add(chartControl);

            // Create a series and add points to it.
            Series series1 = new Series("Series 1", ViewType.Bar);
            series1.Points.Add(new SeriesPoint("A", new double[] { 4 }));
            series1.Points.Add(new SeriesPoint("B", new double[] { 2 }));
            series1.Points.Add(new SeriesPoint("C", new double[] { 17 }));
            series1.Points.Add(new SeriesPoint("D", new double[] { 4 }));
            series1.Points.Add(new SeriesPoint("E", new double[] { 17 }));
            series1.Points.Add(new SeriesPoint("F", new double[] { 12 }));
            series1.Points.Add(new SeriesPoint("G", new double[] { 15 }));

            // Add the series to the chart.
            chartControl.Series.Add(series1);

            // Disable a crosshair cursor.
            chartControl.CrosshairEnabled = DefaultBoolean.False;

            // Enable chart tooltips. 
            chartControl.ToolTipEnabled = DefaultBoolean.True;

            // Show a tooltip's beak
            ToolTipController controller = new ToolTipController();
            chartControl.ToolTipController = controller;
            controller.ShowBeak = true;

            // Change the default tooltip mouse position to relative position.
            ToolTipRelativePosition relativePosition = new ToolTipRelativePosition();
            chartControl.ToolTipOptions.ToolTipPosition = relativePosition;

            // Specify the tooltip relative position offsets.  
            relativePosition.OffsetX = 2;
            relativePosition.OffsetY = 2;

            // Specify the tooltip point pattern.
            series1.ToolTipPointPattern = "Bar Series: {A}:{V}";
        }
    }
}
