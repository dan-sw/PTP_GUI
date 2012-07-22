using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SpPerfChart
{
    /// <summary>
    /// Scale mode for value aspect ratio
    /// </summary>
    public enum ScaleMode
    {
        /// <summary>
        /// Absolute Scale Mode: Values from 0 to 100 are accepted and displayed
        /// </summary>
        Absolute,
        /// <summary>
        /// Relative Scale Mode: All values are allowed and displayed in a proper relation
        /// </summary>
        Relative,
        /// <summary>
        /// Magnitude Scale Mode: Display range is logarithmic, adjusts based on dataset
        /// </summary>
        Magnitude
    }

    /// <summary>
    /// Chart Refresh Mode Timer Control Mode
    /// </summary>
    public enum TimerMode
    {
        /// <summary>
        /// Chart is refreshed when a value is added.  This is the only mode that supports
        /// two datasets.
        /// </summary>
        Disabled,
        /// <summary>
        /// Chart is refreshed every <c>TimerInterval</c> milliseconds, adding all values
        /// in the queue to the chart. If there are no values in the queue, a 0 (zero) is added
        /// </summary>
        Simple,
        /// <summary>
        /// Chart is refreshed every <c>TimerInterval</c> milliseconds, adding an average of
        /// all values in the queue to the chart. If there are no values in the queue,
        /// 0 (zero) is added
        /// </summary>
        SynchronizedAverage,
        /// <summary>
        /// Chart is refreshed every <c>TimerInterval</c> milliseconds, adding the sum of
        /// all values in the queue to the chart. If there are no values in the queue,
        /// 0 (zero) is added
        /// </summary>
        SynchronizedSum
    }

    public partial class SpPerfChart : UserControl
    {
        #region *** Constants ***

        // Keep only a maximum MAX_VALUE_COUNT amount of values; This will allow
        private const int MAX_VALUE_COUNT = 512;
        // Draw a background grid with a fixed line spacing
        // MikeA: Had to fix the container's Height, to get Ten vertical segments.
        //    (Could have adjusted it in here with flex GRID_SPACING, but GUI looks best
        //     with fixed horiz grid.)
        private const int GRID_X_SPACING = 16;
        private decimal grid_Y_spacing = 16m;

        #endregion


        #region *** Member Variables ***

        // TimerMode.Disabled charts may display two datasets
        private bool twoDatasets = false;
        // Amount of currently visible values (calculated from control width and value spacing)
        private int visibleValues = 0;
        // Horizontal value space in Pixels
        private int valueSpacing = 5;
        // The currently highest displayed value, required for Relative Scale Mode
        private decimal currentMaxValue = 0;
        // The current vertical scale
        private decimal currentVerticalScaler;
        // The current order and scale, required for Magnitude Scale Mode
        private int currentOrderOfMagnitude = 0;
        //private decimal currentMagnitudeScaler = 1.0m;
        private readonly string[] MagnitudeY = { "X 1", "X 10", "X 100", "X 1000", "X 10 000", "X 100 000", "X 1 000 000", "X 10 000 000", "X 100 000 000", "X 1 000 000 000" };
        // See how MagnitudeScaler is set in OrderOfMagnitude and used 
        // (indirectly) in CalcVerticalPosition.  It is Height/MaxValueMapping:
        private readonly decimal[] MagnitudeScaler = { 10m, 100m, 1000m, 10000m, 100000m, 1000000m, 10000000m, 100000000m, 1000000000m, 10000000000m };

        // Offset value for the scrolling grid
        private int gridScrollOffset = 0;
        // The current average value
        private decimal averageValue = 0;
        // Border Style
        private Border3DStyle b3dstyle = Border3DStyle.Sunken;
        // Border-adjusted surface rectangle
        private Rectangle surfaceRectangle;
        // Scale mode for value aspect ratio
        private ScaleMode scaleMode = ScaleMode.Absolute;       
        // Timer Mode
        private TimerMode timerMode;
        // List of stored values
        private List<decimal> drawValues = new List<decimal>(MAX_VALUE_COUNT);
        private List<decimal> drawValuesB = new List<decimal>(MAX_VALUE_COUNT);
        // Value queue for Timer Modes
        private Queue<decimal> waitingValues = new Queue<decimal>();
        // Style and Design
        private PerfChartStyle perfChartStyle;
        private bool hideBorder;

        #endregion

        #region *** Constructors ***
        public SpPerfChart()
        {
            InitializeComponent();
            // Initialize Variables
            perfChartStyle = new PerfChartStyle();

            // Set Optimized Double Buffer to reduce flickering
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Redraw when resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.Font = SystemInformation.MenuFont;

            // Adjust drawing surface for Border
            // Draw the background Gradient rectangle
            calculateSurfaceRectangle();
        }

        #endregion

        #region *** Properties ***

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance"), Description("Appearance and Style")]
        public PerfChartStyle PerfChartStyle
        {
            get { return perfChartStyle; }
            set { perfChartStyle = value; }
        }


        [DefaultValue(typeof(Border3DStyle), "Sunken"), Description("BorderStyle"), Category("Appearance")]
        new public Border3DStyle BorderStyle
        {
            get
            {
                return b3dstyle;
            }
            set
            {
                b3dstyle = value;
                Invalidate();
            }
        }

        public bool HideBorder {
            get
            {
                return hideBorder;
            }
            set
            {
                hideBorder = value; 
                calculateSurfaceRectangle();
            } 
        }

        public ScaleMode ScaleMode
        {
            get { return scaleMode; }
            set { scaleMode = value; }
        }       

        public string MagnitudeLabel
        {
            get { return MagnitudeY[currentOrderOfMagnitude]; }
        }

        [DefaultValue(typeof(bool), "false"), Description("When ScaleMode is Absolute, will draw scale on left side of chart"), Category("Misc")]
        public bool ShowAbsoluteScale { get; set; }

        [DefaultValue(typeof(string[]), ""), Description("When ScaleMode is Absolute, optional labels to draw on left side of chart"), Category("Misc")]
        public string[] AbsoluteScaleLabels { get; set; }

        public decimal Grid_Y_Spacing { get { return grid_Y_spacing; } }

        // Mike: No reason for this to be a property; it's managed automatically right now;
        // but I suppose someday could be managed programmatically
        public int OrderOfMagnitude
        {
            get { return currentOrderOfMagnitude; }
            set
            {
                if (value < 0 || value >= MagnitudeY.Length)
                {
                    return;
                }
                currentOrderOfMagnitude = value;
            }
        }

        // NOTE: Only available when ScaleMode is Magnitude or Relative
        public decimal MaxValue
        {
            get { return currentMaxValue; }
        }


        public TimerMode TimerMode
        {
            get { return timerMode; }
            set
            {
                if (value == TimerMode.Disabled)
                {
                    // Stop and append only when changed
                    if (timerMode != TimerMode.Disabled)
                    {
                        timerMode = value;

                        tmrRefresh.Stop();
                        // If there are any values in the queue, append them
                        ChartAppendFromQueue();
                    }
                }
                else
                {
                    timerMode = value;
                    tmrRefresh.Start();
                }
            }
        }

        public int TimerInterval
        {
            get { return tmrRefresh.Interval; }
            set
            {
                if (value < 15)
                    throw new ArgumentOutOfRangeException("TimerInterval", value, "The Timer interval must be greater then 15");
                else
                    tmrRefresh.Interval = value;
            }
        }

        public bool DualGraph
        {
            get { return twoDatasets; }
            set
            {
                if (value == true && timerMode != TimerMode.Disabled)
                {
                    // Force it.  Or, could Throw invalidParameter exception...
                    timerMode = TimerMode.Disabled;
                }
                twoDatasets = value;
            }
        }
        #endregion


        #region *** Public Methods ***

        /// <summary>
        /// Clears the whole chart
        /// </summary>
        public void Clear()
        {
            drawValues.Clear();
            drawValuesB.Clear();
            Invalidate();
        }


        /// <summary>
        /// Adds a value to the Chart Line
        /// </summary>
        /// <param name="value">progress value</param>
        public void AddValue(decimal value)
        {
            if (twoDatasets)
                throw new InvalidOperationException("A DualGraph chart requires two data points. Use method AddValues(a, b) instead of AddValue(a)");
            AddValues(value, Decimal.Zero);
        }

        /// <summary>
        /// Adds a pair of values to the Chart, one for each dataset
        /// </summary>
        /// <param name="value">progress valueA</param>
        /// <param name="value">progress valueB</param>
        public void AddValues(decimal valueA, decimal valueB)
        {
            if (scaleMode == ScaleMode.Absolute)
            {
                    // Clip at 100
                    valueA = Math.Min(valueA, 100m);
                    valueB = Math.Min(valueB, 100m);
               
            }

            switch (timerMode)
            {
                case TimerMode.Disabled:
                    ChartAppend(valueA, valueB);
                    Invalidate();
                    break;
                case TimerMode.Simple:
                case TimerMode.SynchronizedAverage:
                case TimerMode.SynchronizedSum:
                    // For all Timer Modes, the Values are stored in the Queue
                    AddValueToQueue(valueA);
                    break;
                default:
                    throw new Exception(String.Format("Unsupported TimerMode: {0}", timerMode));
            }
        }

        #endregion


        #region *** Private Methods: Common ***

        private void calculateSurfaceRectangle() 
        {
            surfaceRectangle = new Rectangle(0, 0, this.Width, this.Height);

            if (!hideBorder)
            {
                surfaceRectangle.Inflate(-1 * SystemInformation.Border3DSize.Width, -1 * SystemInformation.Border3DSize.Height);
            }

        }

        /// <summary>
        /// Add value to the queue for a timed refresh
        /// </summary>
        /// <param name="value"></param>
        /// TODO: MikeA: Maintain a different property, SampleInterval,
        /// which indicates how many samples are expected to be gathered
        /// between update intervals.  During ChartAppendFromQueue, handle
        /// missing/extra samples; during ChartAppend, consider this amount
        /// in calc of gridScrollOffset
        /// NOTE: MikeA: Did not add support for multiple datasets to any
        /// timermode except Disabled... which doesn't use the Queue 
        private void AddValueToQueue(decimal value)
        {
            waitingValues.Enqueue(value);
        }


        /// <summary>
        /// Appends value <paramref name="value"/> to the chart (without redrawing)
        /// </summary>
        /// <param name="value">performance value</param>
/*        private void ChartAppend(decimal value)
        {
            // Insert at first position; Negative values are flatten to 0 (zero)
            drawValues.Insert(0, Math.Max(value, 0));
            // Remove last item if maximum value count is reached
            if (drawValues.Count > MAX_VALUE_COUNT)
                drawValues.RemoveAt(MAX_VALUE_COUNT);
            advanceScroll();
        }
*/        
        private void ChartAppend(decimal valueA, decimal valueB)
        {
            // Insert at first position; Negative values are flatten to 0 (zero)
            drawValues.Insert(0, Math.Max(valueA, 0));
            // Remove last item if maximum value count is reached
            if (drawValues.Count > MAX_VALUE_COUNT)
            {
                drawValues.RemoveAt(MAX_VALUE_COUNT);
            }
            if ( twoDatasets )
            {
                drawValuesB.Insert(0, Math.Max(valueB, 0));
                if (drawValuesB.Count > MAX_VALUE_COUNT)
                {
                    drawValuesB.RemoveAt(MAX_VALUE_COUNT);
                }
            }
            advanceScroll();
        }
        private void advanceScroll()
        {
            // Calculate horizontal grid offset for "scrolling" effect
            gridScrollOffset += valueSpacing;
            if (gridScrollOffset > GRID_X_SPACING)
                gridScrollOffset = gridScrollOffset % GRID_X_SPACING;
        }


        /// <summary>
        /// Appends Values from queue
        /// </summary>
        private void ChartAppendFromQueue()
        {
            // Proceed only if there are values at all
            if (waitingValues.Count > 0)
            {
                if (timerMode == TimerMode.Simple)
                {
                    while (waitingValues.Count > 0)
                        ChartAppend(waitingValues.Dequeue(), Decimal.MaxValue );
                }
                else if (timerMode == TimerMode.SynchronizedAverage ||
                         timerMode == TimerMode.SynchronizedSum)
                {
                    // appendValue variable is used for calculating the average or sum value
                    decimal appendValue = Decimal.Zero;
                    int valueCount = waitingValues.Count;

                    while (waitingValues.Count > 0)
                        appendValue += waitingValues.Dequeue();

                    // Calculate Average value in SynchronizedAverage Mode
                    if (timerMode == TimerMode.SynchronizedAverage)
                        appendValue = appendValue / (decimal)valueCount;

                    // Finally append the value
                    ChartAppend(appendValue, Decimal.MaxValue);
                }
            }
            else
            {
                // Always add 0 (Zero) if there are no values in the queue
                ChartAppend(Decimal.Zero, Decimal.MaxValue);
            }

            // Refresh the Chart
            Invalidate();
        }

        /// MikeA Added:
        /// Considers the maxValue in dataset, computes its order of magnitude
        /// and sets the currentScaler accordingly.
        /// Not fully functional, but targeted to the value ranges I expect
        /// for DAN.
        /// 
        private void adjustOrderOfMagnitude(Decimal maxValue)
        {
            if (maxValue <= 10)
            {
                // unit
                OrderOfMagnitude = 0;
            }
            else if (maxValue <= 100)
            {
                // Deci
                OrderOfMagnitude = 1;
            }
            else if (maxValue <= 1000)
            {
                // Centi
                OrderOfMagnitude = 2;
            }
            else if (maxValue <= 10000)
            {
                // Kilo
                OrderOfMagnitude = 3;
            }
            else if (maxValue <= 100000)
            {
                // Ten thousand
                OrderOfMagnitude = 4;
            }
            else if (maxValue <= 1000000)
            {
                // Hundred thousand
                OrderOfMagnitude = 5;
            }
            else if (maxValue <= 10000000)
            {
                // Mega
                OrderOfMagnitude = 6;
            }
            else if (maxValue <= 100000000)
            {
                // Ten Million
                OrderOfMagnitude = 7;
            }
            else if (maxValue <= 100000000)
            {
                // Hundred Million (one Gig highest value)
                OrderOfMagnitude = 8;
            }
            else
            {
                // Ten Gig (One billion per grid square)
                OrderOfMagnitude = 9;
            }
        }

        /// <summary>
        /// Calculates the vertical scale to be used for drawing the dataset.
        /// Should be called whenever chart is resized, or ScaleMode changes,
        /// or (if ScaleMode == ScaleMode.Magnitude) whenever currentMagnitudeScaler
        /// changes.
        ///    The point is to only do this division once per paint (originally,
        /// this calc was performed for each point displayed.)
        ///    Another change: the scaler is now needed for DrawBackgroundAndGrid,
        /// so this is called by the OnPaint method and contains calls to find
        /// max value, which previously was in method DrawChart
        /// </summary>
        private void calculateVerticalScaler()
        {

            visibleValues = Math.Min(surfaceRectangle.Width / valueSpacing, drawValues.Count);
            // Sanity (and bug) check:
            if (twoDatasets && drawValuesB.Count < visibleValues)
            {
                Console.WriteLine("BUG: Unexpected: datasets not equal length: {0} and {0}", drawValues.Count, drawValuesB.Count);
                visibleValues = Math.Min(visibleValues, drawValuesB.Count);
            }

            if (scaleMode == ScaleMode.Absolute)
            {
                currentVerticalScaler = (surfaceRectangle.Height - 1) / 100m;
                grid_Y_spacing = (surfaceRectangle.Height - 1) / 10m;
            }
            else if (scaleMode == ScaleMode.Relative)
            {
                // Adjusting the scaler so that the highest value plots at 90%, not 100% (as previous):
                currentMaxValue = GetHighestValueForRelativeMode();
                //currentVerticalScaler = (currentMaxValue > 0) ? (surfaceRectangle.Height / currentMaxValue) : 1m;
                currentVerticalScaler = (currentMaxValue > 0) ? ((surfaceRectangle.Height * 0.9m) / currentMaxValue) : 1m;
                grid_Y_spacing = (decimal) GRID_X_SPACING; // 16, square
            }
            else if (scaleMode == ScaleMode.Magnitude)
            {
                currentMaxValue = GetHighestValueForRelativeMode();
                adjustOrderOfMagnitude(currentMaxValue);
                //float denominator = (float) MagnitudeScaler[currentOrderOfMagnitude];
                //float numerator = (float)(surfaceRectangle.Height - 1);
                //float temp = numerator / denominator;
                //currentVerticalScaler = (decimal)temp;
                currentVerticalScaler = (surfaceRectangle.Height -1) / MagnitudeScaler[currentOrderOfMagnitude];
                grid_Y_spacing = (surfaceRectangle.Height - 1) / 10m;
            }

                // FYI, I've adjusted the Height == 160, to produce 10 horiz lines, each one
                // (based on GRID_SPACING == 16) is GRID_SPACING bits high.  
                // To scale the value to be in (0..160), scale factor will be
                // Height / maxValue.
                // To convert, say 200 to the second line from bottom when magnitude
                // is 2 ("X 100")  multiply that by 160/1000
                // decimal d = this.Height;
                // currentMagnitudeScaler = d / MagnitudeScaler[value];
                // Experiment MikeA:
                // Consider the border size
           //     decimal d = this.Height - (HideBorder ? 0 : SystemInformation.Border3DSize.Height * 2);
           //     currentMagnitudeScaler = d / MagnitudeScaler[currentOrderOfMagnitude];
          
            
        }

        
        /// <summary>
        /// Calculates the vertical Position of a value in relation the chart size,
        /// Scale Mode and, if ScaleMode is Relative, to the current maximum value
        /// </summary>
        /// <param name="value">performance value</param>
        /// <returns>vertical Point position in Pixels</returns>
        private int CalcVerticalPosition(decimal value)
        {
            decimal scaledValue = value * currentVerticalScaler;
            long rv2 = Convert.ToInt64(Math.Round(scaledValue));
            int rv = 0;
            if (rv2 < int.MaxValue)
            {
                rv = (int) rv2;
            }
            else
            {
                Console.WriteLine("Overflow calc vertical position, value {0}, scale {1}", value, currentVerticalScaler);
                return 0;
            }
            rv = (surfaceRectangle.Bottom - 1) - rv;
            return rv;
        }


        /// <summary>
        /// Returns the currently highest (displayed) value, for Relative ScaleMode
        /// </summary>
        /// <returns></returns>
        private decimal GetHighestValueForRelativeMode()
        {
            decimal maxValue = 0;

            for (int i = 0; i < visibleValues; i++)
            {
                // Set if higher then previous max value
                if (drawValues[i] > maxValue)
                    maxValue = drawValues[i];
            }
            if (twoDatasets)
            {
                // Note that setting of visibleValues considers
                // the size of both drawValues and drawValuesB, so
                // this won't OutOfBounds:
                for (int i = 0; i < visibleValues; i++)
                {
                    // Set if higher then previous max value
                    if (drawValuesB[i] > maxValue)
                        maxValue = drawValuesB[i];
                }
            }

            return maxValue;
        }

        #endregion


        #region *** Private Methods: Drawing ***

        /// <summary>
        /// Draws the chart (w/o background or grid, but with border) to the Graphics canvas
        /// </summary>
        /// <param name="g">Graphics</param>
        private void DrawChart(Graphics g)
        {
            // A little help, debugging a specific instance:
            /*
              if (this.Name == "spPerfChartRSSI")
            {
                Console.WriteLine("Break");
            }
             *
             */

            // Note: Constraint on AddValue guarantees that drawValues and drawValuesB are same length.
            //    (if not, protect GetHighestValueForRelativeMode from out-of-bounds exception)
            /*
             * Moved to calcVerticalScaler, because it's needed by DrawBackgroundAndGrid
             * before this method is called.
             * 
            visibleValues = Math.Min(surfaceRectangle.Width / valueSpacing, drawValues.Count);
            // Sanity (and bug) check:
            if (twoDatasets && drawValuesB.Count < visibleValues)
            {
                Console.WriteLine("BUG: Unexpected: datasets not equal length: {0} and {0}", drawValues.Count, drawValuesB.Count);
                visibleValues = Math.Min(visibleValues, drawValuesB.Count);
            }
             */

            /*
             * Moved to calcVerticalScaler, because it's needed by DrawBackgroundAndGrid
             * before this method is called.
             * 
            if (scaleMode == ScaleMode.Relative)
            {
                currentMaxValue = GetHighestValueForRelativeMode();
            }
            else if (scaleMode == ScaleMode.Magnitude)
            {
                // Set, for property MaxValue:
                currentMaxValue = GetHighestValueForRelativeMode();
                adjustOrderOfMagnitude(currentMaxValue);
            }
             * */

            // Only draw average line when possible (visibleValues) and needed (style setting)
            if (visibleValues > 0 && perfChartStyle.ShowAverageLine)
            {
                averageValue = 0;
                DrawAverageLine(g);
            }

            // Dirty little "trick": initialize the first previous Point outside the bounds
            Point previousPoint = new Point(surfaceRectangle.Width + valueSpacing, surfaceRectangle.Height);
            Point previousPointB = new Point(surfaceRectangle.Width + valueSpacing, surfaceRectangle.Height);
            Point currentPoint = new Point();
            Point currentPointB = new Point();

            // Connect all visible values with lines
            for (int i = 0; i < visibleValues; i++)
            {
                currentPoint.X = previousPoint.X - valueSpacing;
                currentPoint.Y = CalcVerticalPosition(drawValues[i]);

                // Actually draw the line
                g.DrawLine(perfChartStyle.ChartLinePen.Pen, previousPoint, currentPoint);

                previousPoint = currentPoint;
                if (twoDatasets)
                {
                    currentPointB.X = previousPointB.X - valueSpacing;
                    currentPointB.Y = CalcVerticalPosition(drawValuesB[i]);

                    // Actually draw the line
                    g.DrawLine(perfChartStyle.ChartLinePenB.Pen, previousPointB, currentPointB);

                    previousPointB = currentPointB;
                }
            }

            // Draw current relative maximum value stirng
            if (scaleMode == ScaleMode.Relative)
            {
                SolidBrush sb = new SolidBrush(perfChartStyle.AvgLinePen.Color);
                g.DrawString(currentMaxValue.ToString("n2"), this.Font, sb, 4.0f, 2.0f);
            }
            else if (scaleMode == ScaleMode.Magnitude)
            {
                SolidBrush sb = new SolidBrush(perfChartStyle.AvgLinePen.Color);
                g.DrawString(MagnitudeLabel, this.Font, sb, 4.0f, 2.0f);
            }
            else if (scaleMode == ScaleMode.Absolute && ShowAbsoluteScale)
            {
                // To see a different color, I'm using AverageLinePen.Color, which is not currently
                // used in this application, otherwise.
                SolidBrush sb = new SolidBrush(perfChartStyle.AvgLinePen.Color);
                // TODO: Refactor these into a single, more generic technique:
                if (AbsoluteScaleLabels == null || AbsoluteScaleLabels.Length == 0)
                {
                    // use default numbering
                    g.DrawString("100", this.Font, sb, 4.0f, 0.0f);
                    float y = (float)(2 * grid_Y_spacing);
                    g.DrawString("80", this.Font, sb, 4.0f, (float)surfaceRectangle.Top + y);
                    y = (float)(4 * grid_Y_spacing);
                    g.DrawString("60", this.Font, sb, 4.0f, (float)surfaceRectangle.Top + y);
                    y = (float)(6 * grid_Y_spacing);
                    g.DrawString("40", this.Font, sb, 4.0f, (float)surfaceRectangle.Top + y);
                    y = (float)(8 * grid_Y_spacing);
                    g.DrawString("20", this.Font, sb, 4.0f, (float)surfaceRectangle.Top + y);
                }
                else
                {
                    float y = 0.0f;
                    float deltaY = (float) surfaceRectangle.Height / (float)AbsoluteScaleLabels.Length;
                    foreach (string s in AbsoluteScaleLabels)
                    {
                        g.DrawString(s, this.Font, sb, 4.0f, (float)surfaceRectangle.Top + y);
                        y += deltaY;
                    }
                }
            }

            // Draw Border on top
            // MikeA: Experiment:
            if (!HideBorder)
            {
                ControlPaint.DrawBorder3D(g, 0, 0, Width, Height, b3dstyle);
            }
        }


        private void DrawAverageLine(Graphics g)
        {
            for (int i = 0; i < visibleValues; i++)
                averageValue += drawValues[i];

            averageValue = averageValue / visibleValues;

            int verticalPosition = CalcVerticalPosition(averageValue);
            g.DrawLine(perfChartStyle.AvgLinePen.Pen, surfaceRectangle.Left, verticalPosition, surfaceRectangle.Width, verticalPosition);
        }

        /// <summary>
        /// Draws the background gradient and the grid into Graphics <paramref name="g"/>
        /// </summary>
        /// <param name="g">Graphic</param>
        private void DrawBackgroundAndGrid(Graphics g)
        {
            // Draw the background Gradient rectangle
            using (Brush gradientBrush = new LinearGradientBrush(surfaceRectangle, perfChartStyle.BackgroundColorTop, perfChartStyle.BackgroundColorBottom, LinearGradientMode.Vertical))
            {
                g.FillRectangle(gradientBrush, surfaceRectangle);
            }

            // Draw all visible, vertical gridlines (if wanted)
            if (perfChartStyle.ShowVerticalGridLines)
            {
                for (int i = surfaceRectangle.Right - gridScrollOffset; i >= surfaceRectangle.Left; i -= GRID_X_SPACING)
                {
                    g.DrawLine(perfChartStyle.VerticalGridPen.Pen, i, surfaceRectangle.Bottom, i, surfaceRectangle.Top);
                }
            }

            // Draw all visible, horizontal gridlines (if wanted)
            if (perfChartStyle.ShowHorizontalGridLines)
            {
                // The unusual code below is intended to produce the same Y-values as the chart data produces 
                // in calls to CalcVerticalPosition()
                //for (int i = 0; i < Height; i += GRID_SPACING)
                //{
                //    g.DrawLine(perfChartStyle.HorizontalGridPen.Pen, 0, i, Width, i);
                //}
//                for (int i = surfaceRectangle.Top; i <= surfaceRectangle.Bottom; i += Convert.ToInt32(Math.Round(Grid_Y_spacing)) )

                for (decimal d = (decimal) surfaceRectangle.Top; d <= (decimal) surfaceRectangle.Bottom; d += grid_Y_spacing)
                {
                    int i = Convert.ToInt32(Math.Round(d));
                    g.DrawLine(perfChartStyle.HorizontalGridPen.Pen, surfaceRectangle.Left, i, surfaceRectangle.Right, i);
                }
            }
        }

        #endregion


        #region *** Overrides ***

        /// Override OnPaint method
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);

                // Enable AntiAliasing, if needed
                if (perfChartStyle.AntiAliasing)
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                // Re-compute scaling, for grid and data
                calculateVerticalScaler();
                DrawBackgroundAndGrid(e.Graphics);
                DrawChart(e.Graphics);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception {0} in paint {1}", ex.Message, this.Name);
            }

        }

        protected override void OnResize(EventArgs e)
        {
            if (this.Name == "spPerfChart0")
            {
                Console.WriteLine("OnResize: this width={0} Height={1}", this.Width , this.Height );
            }
            base.OnResize(e);
            calculateSurfaceRectangle();

            Invalidate();
        }

        #endregion


        #region *** Event Handlers ***

        private void colorSet_ColorSetChanged(object sender, EventArgs e)
        {
            //Refresh Chart on Resize
            Invalidate();
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            // Don't execute event if running in design time
            if (this.DesignMode) return;

            ChartAppendFromQueue();
        }

        #endregion

    }
}
