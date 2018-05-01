/*
*   FILENAME: myForm
*   PROJECT: BI_A02
*   PROGRAMMER: Jody Markic
*   FIRST VERSION: 10/2/2017
*   DESCRIPTION: This files holds the event handles and objects to the BI_A02 project.
*                This file uses a DAL object to securely access a database. This file uses a button
*                to update the a pareto diagram that reflects scrap rate along with values displayed as
*                a report.
*
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Messaging;
using System.Windows.Forms.DataVisualization.Charting;

namespace BI_A02
{
    //
    // Class: myForm : Form
    // Description: This method acts as event handle and api to the BI_A02
    //
    //
    public partial class myForm : Form
    {
        //local variables
        private DAL myDAL = new DAL();
        //System.Windows.Forms.SystemInformation.ComputerName;
        private MessageQueue myQueue = new MessageQueue();
        private Boolean bRead = false;
        private String queueName = "\\private$\\yoyo";

        private string queueRecordString = "";
        private string[] defects = { "FINAL_COAT_FLAW", "BROKEN_SHELL", "TANGLED_STRING", "PRIMER_DEFECT", "DRIP_MARK", "INCONSISTENT_THICKNESS", "WARPING", "PITTING" };

        //QueueReader myReader = new QueueReader();

        //enum
        enum productName { AllProjects = 0, OriginalSleeper, BlackBeauty,
            Firecracker, LemonYellow, MidnightBlue, ScreamingOrange,
            GoldGlitter, WhiteLightening }

        //
        //  METHOD      : myForm
        //  DESCRIPTION : Constructor
        //  PARAMETERS  : N/A
        //  RETURNS     : N/A
        //
        public myForm()
        {
            InitializeComponent();
            //seed combobox
            seedYoyoCombobox();
            //seed pareto
            LoadParetoDiagram();
            InitializeReader();
            //start reading Q
            ReadQueue();
        }

        //
        //  METHOD      : InitializeReader
        //  DESCRIPTION : Initialize a event handle
        //  PARAMETERS  : N/A
        //  RETURNS     : void
        //
        public void InitializeReader()
        {
            myQueue.Formatter = new ActiveXMessageFormatter();
            myQueue.MessageReadPropertyFilter.LookupId = true;
            myQueue.SynchronizingObject = this;
            myQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(myQueue_ReceiveCompleted);
        }

        //
        //  METHOD      : ReadQueue
        //  DESCRIPTION : Begin recieving messages from the Q
        //  PARAMETERS  : N/A
        //  RETURNS     : void
        //
        public void ReadQueue()
        {
            myQueue.Path = "Formatname:Direct=os:" + System.Windows.Forms.SystemInformation.ComputerName + queueName;
            bRead = true;
            myQueue.BeginReceive();
        }

        //
        //  METHOD      : myQueue_ReceiveCompleted
        //  DESCRIPTION : Event handle for recieving a message from the Q
        //  PARAMETERS  : object sender, ReceiveCompletedEventArgs e
        //  RETURNS     : void
        //
        public void myQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                queueRecordString = e.Message.Body.ToString();
                myQueue.EndReceive(e.AsyncResult);

                myDAL.InsertToProduction(queueRecordString);


                Application.DoEvents();
                if (bRead)
                {
                    myQueue.BeginReceive();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //
        //  METHOD      : seedYoyoCombobox
        //  DESCRIPTION : seed the combobox
        //  PARAMETERS  : N/A
        //  RETURNS     : void
        //
        public void seedYoyoCombobox()
        {
            yoyoComboBox.Items.Add("All Projects");
            yoyoComboBox.Items.Add("Original Sleeper");
            yoyoComboBox.Items.Add("Black Beauty");
            yoyoComboBox.Items.Add("Firecracker");
            yoyoComboBox.Items.Add("Lemon Yellow");
            yoyoComboBox.Items.Add("Midnight Blue");
            yoyoComboBox.Items.Add("Screaming Orange");
            yoyoComboBox.Items.Add("Gold Glitter");
            yoyoComboBox.Items.Add("White Lightening");
        }

        //
        //  METHOD      : yoyoComboBox_SelectedIndexChanged
        //  DESCRIPTION : Event handle for selected index changing in combobox
        //  PARAMETERS  : object sender, EventArgs e
        //  RETURNS     : void
        //
        private void yoyoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (yoyoComboBox.SelectedIndex)
            {
                case (int)productName.AllProjects:
                    //query for all products
                    break;
                case (int)productName.OriginalSleeper:
                case (int)productName.BlackBeauty:
                case (int)productName.Firecracker:
                case (int)productName.LemonYellow:
                case (int)productName.MidnightBlue:
                case (int)productName.ScreamingOrange:
                case (int)productName.GoldGlitter:
                case (int)productName.WhiteLightening:
                default:
                    break;
            }
        }

        //
        //  METHOD      : seedReport
        //  DESCRIPTION : run queries on getting report values, then write them to its respective label
        //  PARAMETERS  : int productID, string procOne, string procTwo, string procThree, string procFour, string procFive, string procSix, string procSeven
        //  RETURNS     : void
        //
        private void seedReport(int productID, string procOne, string procTwo, string procThree, string procFour, string procFive, string procSix, string procSeven)
        {
            //local variables
            int selTotalMold = 0;
            int selInspectionOne = 0;
            int selTotalPaint = 0;
            int selInspectionTwo = 0;
            int selTotalAssembly = 0;
            int selInspectionThree = 0;
            int selTotalPackage = 0;

            double calculationBuffer = 0;

            //run stored procedures, store results
            selTotalMold = myDAL.GetData(procOne, productID);
            selInspectionOne = myDAL.GetData(procTwo, productID);
            selTotalPaint = myDAL.GetData(procThree, productID);
            selInspectionTwo = myDAL.GetData(procFour, productID);
            selTotalAssembly = myDAL.GetData(procFive, productID);
            selInspectionThree = myDAL.GetData(procSix, productID);
            selTotalPackage = myDAL.GetData(procSeven, productID);

            //do calculations
            TotalMolded.Text = selTotalMold.ToString();

            //start of seeding UI with stored procedure results
            calculationBuffer = selTotalMold - selInspectionOne;
            TotalSuccessfulMolds.Text = calculationBuffer.ToString();

            if (selInspectionOne != 0)
            {
                calculationBuffer = calculationBuffer / selTotalMold;
                calculationBuffer = calculationBuffer * 100;
                YieldAtMold.Text = calculationBuffer.ToString("#.##");
            }
            calculationBuffer = selTotalPaint - selInspectionTwo;
            TotalSuccessfulPaints.Text = calculationBuffer.ToString();

            if (Int32.Parse(TotalSuccessfulMolds.Text) != 0)
            {
                calculationBuffer = calculationBuffer / (Int32.Parse(TotalSuccessfulMolds.Text));
                calculationBuffer = calculationBuffer * 100;
                YieldAtPaint.Text = calculationBuffer.ToString("#.##");
            }
            calculationBuffer = selTotalAssembly - selInspectionThree;
            TotalSuccessfulAssembly.Text = calculationBuffer.ToString();

            if (Int32.Parse(TotalSuccessfulPaints.Text) != 0)
            {
                calculationBuffer = calculationBuffer / (Int32.Parse(TotalSuccessfulPaints.Text));
                calculationBuffer = calculationBuffer * 100;
                YieldAtAssembly.Text = calculationBuffer.ToString("#.##");
            }
            TotalPartsPackaged.Text = selTotalPackage.ToString();

            if (selTotalMold != 0)
            {
                calculationBuffer = Double.Parse(selTotalPackage.ToString()) / Double.Parse(selTotalMold.ToString());
                calculationBuffer = calculationBuffer * 100;
                TotalYield.Text = calculationBuffer.ToString("#.##");
            }
            //stop of seeding UI with stored procedure results
        }

        //
        //  METHOD      : seedReport
        //  DESCRIPTION :  run queries on getting report values, then write them to its respective label
        //  PARAMETERS  : string procOne, string procTwo, string procThree, string procFour, string procFive, string procSix, string procSeven
        //  RETURNS     : void
        //
        private void seedReport(string procOne, string procTwo, string procThree, string procFour, string procFive, string procSix, string procSeven)
        {
            //local variables
            int selTotalMold = 0;
            int selInspectionOne = 0;
            int selTotalPaint = 0;
            int selInspectionTwo = 0;
            int selTotalAssembly = 0;
            int selInspectionThree = 0;
            int selTotalPackage = 0;

            double calculationBuffer = 0;

            //run stored procedures, store results
            selTotalMold = myDAL.GetData(procOne);
            selInspectionOne = myDAL.GetData(procTwo);
            selTotalPaint = myDAL.GetData(procThree);
            selInspectionTwo = myDAL.GetData(procFour);
            selTotalAssembly = myDAL.GetData(procFive);
            selInspectionThree = myDAL.GetData(procSix);
            selTotalPackage = myDAL.GetData(procSeven);

            //do calculations
            TotalMolded.Text = selTotalMold.ToString();

            //start of seeding UI with stored procedure results
            calculationBuffer = selTotalMold - selInspectionOne;
            TotalSuccessfulMolds.Text = calculationBuffer.ToString();

            if (selInspectionOne != 0)
            {
                calculationBuffer = calculationBuffer / selTotalMold;
                calculationBuffer = calculationBuffer * 100;
                YieldAtMold.Text = calculationBuffer.ToString("#.##");
            }
            calculationBuffer = selTotalPaint - selInspectionTwo;
            TotalSuccessfulPaints.Text = calculationBuffer.ToString();

            if (Int32.Parse(TotalSuccessfulMolds.Text) != 0)
            {
                calculationBuffer = calculationBuffer / (Int32.Parse(TotalSuccessfulMolds.Text));
                calculationBuffer = calculationBuffer * 100;
                YieldAtPaint.Text = calculationBuffer.ToString("#.##");
            }
            calculationBuffer = selTotalAssembly - selInspectionThree;
            TotalSuccessfulAssembly.Text = calculationBuffer.ToString();

            if (Int32.Parse(TotalSuccessfulPaints.Text) != 0)
            {
                calculationBuffer = calculationBuffer / (Int32.Parse(TotalSuccessfulPaints.Text));
                calculationBuffer = calculationBuffer * 100;
                YieldAtAssembly.Text = calculationBuffer.ToString("#.##");
            }
            TotalPartsPackaged.Text = selTotalPackage.ToString();

            calculationBuffer = Double.Parse(selTotalPackage.ToString()) / Double.Parse(selTotalMold.ToString());
            calculationBuffer = calculationBuffer * 100;
            TotalYield.Text = calculationBuffer.ToString("#.##");
            //stop of seeding UI with stored procedure results
        }

        //
        //  METHOD      : seedDiagram
        //  DESCRIPTION :this method runs stored procedures get the results and displays them in a pareto diagram
        //  PARAMETERS  : string procOne, string procTwo, string procThree, string procFour, string procFive, string procSix, string procSeven, string procEight, string procNine
        //  RETURNS     : void
        //
        private void seedDiagram(string procOne, string procTwo, string procThree, string procFour, string procFive, string procSix, string procSeven, string procEight, string procNine)
        {
            //local variables
            double finalCoatFlaw = 0;
            double brokenShell = 0;
            double brokenAxle = 0;
            double tangledString = 0;
            double primerDefect = 0;
            double dripMark = 0;
            double inconsistentThickness = 0;
            double warping = 0;
            double pitting = 0;

            //run stored procedures, store results
            finalCoatFlaw = myDAL.GetData(procOne);
            brokenShell = myDAL.GetData(procTwo);
            brokenAxle = myDAL.GetData(procThree);
            tangledString = myDAL.GetData(procFour);
            primerDefect = myDAL.GetData(procFive);
            dripMark = myDAL.GetData(procSix);
            inconsistentThickness = myDAL.GetData(procSeven);
            warping = myDAL.GetData(procSeven);
            pitting = myDAL.GetData(procSeven);

            //clear existing data
            myChart.Series["Rejects"].Points.Clear();
            myChart.Series["Rejection Percentage"].Points.Clear();

            //store results
            double[] defectValues = { finalCoatFlaw, brokenShell, brokenAxle, tangledString, primerDefect, dripMark, inconsistentThickness, warping, pitting };
            //sort results
            Array.Sort(defectValues);
            Array.Reverse(defectValues);

            double total = finalCoatFlaw + brokenShell + brokenAxle + tangledString + primerDefect + dripMark + inconsistentThickness + warping + pitting;
            double defectPercentage = 0;
            double cumulativeDefectsPercentage = 0;
            //seed Bar chart
            if (total != 0)
            {
                for (int i = 0; i < defects.Length; i++)
                {
                    myChart.Series["Rejects"].Points.AddY(defectValues[i]);
                    myChart.Series["Rejects"].Points[i].AxisLabel = defects[i];
                    myChart.Series["Rejects"].Points[i].IsValueShownAsLabel = true;
                }
                //seed Line
                for (int i = 0; i < defectValues.Length; i++)
                {
                    defectPercentage = (defectValues[i] / total) * 100;
                    cumulativeDefectsPercentage += defectPercentage;
                    //add line to the chart
                    myChart.Series["Rejection Percentage"].Points.AddY(cumulativeDefectsPercentage);
                    myChart.Series["Rejection Percentage"].Points[i].MarkerStyle = MarkerStyle.Circle;
                    myChart.Series["Rejection Percentage"].Points[i].MarkerColor = Color.Red;
                    myChart.Series["Rejection Percentage"].Points[i].MarkerSize = 5;
                }
            }
        }

        //
        //  METHOD      : seedDiagram
        //  DESCRIPTION : this method runs stored procedures get the results and displays them in a pareto diagram
        //  PARAMETERS  : int productID, string procOne, string procTwo, string procThree, string procFour, string procFive, string procSix, string procSeven, string procEight, string procNine
        //  RETURNS     : void
        //
        private void seedDiagram(int productID, string procOne, string procTwo, string procThree, string procFour, string procFive, string procSix, string procSeven, string procEight, string procNine)
        {
            //local variables
            double finalCoatFlaw = 0;
            double brokenShell = 0;
            double brokenAxle = 0;
            double tangledString = 0;
            double primerDefect = 0;
            double dripMark = 0;
            double inconsistentThickness = 0;
            double warping = 0;
            double pitting = 0;

            //run stored procedures, store results
            finalCoatFlaw = myDAL.GetData(procOne, productID);
            brokenShell = myDAL.GetData(procTwo, productID);
            brokenAxle = myDAL.GetData(procThree, productID);
            tangledString = myDAL.GetData(procFour, productID);
            primerDefect = myDAL.GetData(procFive, productID);
            dripMark = myDAL.GetData(procSix, productID);
            inconsistentThickness = myDAL.GetData(procSeven, productID);
            warping = myDAL.GetData(procSeven, productID);
            pitting = myDAL.GetData(procSeven, productID);

            //clear existing data
            myChart.Series["Rejects"].Points.Clear();
            myChart.Series["Rejection Percentage"].Points.Clear();

            //store results
            double[] defectValues = { finalCoatFlaw, brokenShell, brokenAxle, tangledString, primerDefect, dripMark, inconsistentThickness, warping, pitting };

            Array.Sort(defectValues);
            Array.Reverse(defectValues);

            double total = finalCoatFlaw + brokenShell + brokenAxle + tangledString + primerDefect + dripMark + inconsistentThickness + warping + pitting;
            double defectPercentage = 0;
            double cumulativeDefectsPercentage = 0;
            if (total != 0)
            {
                for (int i = 0; i < defects.Length; i++)
                {
                    myChart.Series["Rejects"].Points.AddY(defectValues[i]);
                    myChart.Series["Rejects"].Points[i].AxisLabel = defects[i];
                    myChart.Series["Rejects"].Points[i].IsValueShownAsLabel = true;
                }
                //seed Line
                for (int i = 0; i < defectValues.Length; i++)
                {
                    defectPercentage = (defectValues[i] / total) * 100;
                    cumulativeDefectsPercentage += defectPercentage;
                    //add line to the chart
                    myChart.Series["Rejection Percentage"].Points.AddY(cumulativeDefectsPercentage);
                    myChart.Series["Rejection Percentage"].Points[i].MarkerStyle = MarkerStyle.Circle;
                    myChart.Series["Rejection Percentage"].Points[i].MarkerColor = Color.Red;
                    myChart.Series["Rejection Percentage"].Points[i].MarkerSize = 5;
                }

                myChart.DataManipulator.Sort(PointSortOrder.Descending, "Rejects");
            }

            //here is where i seed the bar and the percentage
        }

        //
        //  METHOD      : ClearCurrentChart
        //  DESCRIPTION : Clears existing data from chart
        //  PARAMETERS  : N/A
        //  RETURNS     : void
        //
        private void ClearCurrentChart()
        {
            myChart.Series.Clear();
            myChart.Titles.Clear();
            myChart.ChartAreas.Clear();
        }

        //
        //  METHOD      : LoadParetoDiagram
        //  DESCRIPTION : pre-load some values into the pareto diagram
        //  PARAMETERS  : N/A
        //  RETURNS     : void
        //
        private void LoadParetoDiagram()
        {
            //clear chart data
            ClearCurrentChart();

            //add a chart area
            myChart.ChartAreas.Add("MyChartArea");

            //add series
            myChart.Series.Add("Rejects");
            myChart.Series.Add("Rejection Percentage");

            //give series a chart type
            myChart.Series["Rejects"].ChartType = SeriesChartType.Column;
            myChart.Series["Rejection Percentage"].ChartType = SeriesChartType.Line;
            myChart.Series["Rejection Percentage"].YAxisType = AxisType.Secondary;

            //add title
            myChart.Titles.Add("Yoyo Pareto Diagram");

            //configure chart axises
            myChart.ChartAreas["MyChartArea"].AxisY.Title = "Freq.";
            myChart.ChartAreas["MyChartArea"].AxisY2.Title = "Cum. %";
            myChart.ChartAreas["MyChartArea"].AxisX.Title = "Defect Catergory";

            myChart.ChartAreas["MyChartArea"].AxisY2.Enabled = AxisEnabled.True;
            myChart.ChartAreas["MyChartArea"].AxisY2.Maximum = 100;
            myChart.ChartAreas["MyChartArea"].AxisY2.Minimum = 0;

        }

        //
        //  METHOD      : updateButton_Click
        //  DESCRIPTION : Event handles for the update button
        //  PARAMETERS  : object sender, EventArgs e
        //  RETURNS     : void
        //
        private void updateButton_Click(object sender, EventArgs e)
        {
            switch (yoyoComboBox.SelectedIndex)
            {
                case (int)productName.AllProjects:
                    //run stored procedures on report values and seed report for all
                    seedReport("SelectAllTotalMold", "SelectAllInspectionScrapOne", "SelectAllTotalPaint",
                        "SelectAllScrapAndReworkTwo", "SelectAllTotalAssembly", "SelectAllScrapAndReworkTHREE", "SelectAllTotalPackage");
                    //run stored procedures on pareto values and seed pareto for all
                    seedDiagram("SelectAllFinalCoatFlaw", "SelectAllBrokenShell", "SelectAllBrokenAxle", "SelectAllTangledString", "SelectAllPrimerDefect",
                        "SelectAllDripMark", "SelectAllInconsistentThickness", "SelectAllWarping", "SelectAllPitting");
                    break;
                case (int)productName.OriginalSleeper:
                    //run stored procedures on report values and seed report for OriginalSleeper
                    seedReport((int)productName.OriginalSleeper, "SelectSpecficTotalMold", "SelectSpecificInspectionScrapONE", "SelectSpecificTotalPaint",
                       "SelectSpecificScrapAndReworkTWO", "SelectSpecificTotalAssembly", "SelectSpecificScrapAndReworkTHREE", "SelectSpecificTotalPackage");

                    //run stored procedures on pareto values and seed pareto for OriginalSleeper
                    seedDiagram((int)productName.OriginalSleeper, "SelectSpecificFinalCoatFlaw", "SelectSpecificBrokenShell", "SelectSpecificBrokenAxle", "SelectSpecificTangledString", "SelectSpecificPrimerDefect",
                        "SelectSpecificDripMark", "SelectSpecificInconsistentThickness", "SelectSpecificWarping", "SelectSpecificPitting");
                    break;
                case (int)productName.BlackBeauty:
                    //run stored procedures on report values and seed report for BlackBeauty
                    seedReport((int)productName.BlackBeauty, "SelectSpecficTotalMold", "SelectSpecificInspectionScrapONE", "SelectSpecificTotalPaint",
                       "SelectSpecificScrapAndReworkTWO", "SelectSpecificTotalAssembly", "SelectSpecificScrapAndReworkTHREE", "SelectSpecificTotalPackage");

                    //run stored procedures on pareto values and seed pareto for BlackBeauty
                    seedDiagram((int)productName.BlackBeauty, "SelectSpecificFinalCoatFlaw", "SelectSpecificBrokenShell", "SelectSpecificBrokenAxle", "SelectSpecificTangledString", "SelectSpecificPrimerDefect",
                        "SelectSpecificDripMark", "SelectSpecificInconsistentThickness", "SelectSpecificWarping", "SelectSpecificPitting");
                    break;
                case (int)productName.Firecracker:
                    //run stored procedures on report values and seed report for Firecracker
                    seedReport((int)productName.Firecracker, "SelectSpecficTotalMold", "SelectSpecificInspectionScrapONE", "SelectSpecificTotalPaint",
                       "SelectSpecificScrapAndReworkTWO", "SelectSpecificTotalAssembly", "SelectSpecificScrapAndReworkTHREE", "SelectSpecificTotalPackage");

                    //run stored procedures on pareto values and seed pareto for Firecracker
                    seedDiagram((int)productName.Firecracker, "SelectSpecificFinalCoatFlaw", "SelectSpecificBrokenShell", "SelectSpecificBrokenAxle", "SelectSpecificTangledString", "SelectSpecificPrimerDefect",
                        "SelectSpecificDripMark", "SelectSpecificInconsistentThickness", "SelectSpecificWarping", "SelectSpecificPitting");
                    break;
                case (int)productName.LemonYellow:
                    //run stored procedures on report values and seed report for LemonYellow
                    seedReport((int)productName.LemonYellow, "SelectSpecficTotalMold", "SelectSpecificInspectionScrapONE", "SelectSpecificTotalPaint",
                       "SelectSpecificScrapAndReworkTWO", "SelectSpecificTotalAssembly", "SelectSpecificScrapAndReworkTHREE", "SelectSpecificTotalPackage");

                    //run stored procedures on pareto values and seed pareto for LemonYellow
                    seedDiagram((int)productName.LemonYellow, "SelectSpecificFinalCoatFlaw", "SelectSpecificBrokenShell", "SelectSpecificBrokenAxle", "SelectSpecificTangledString", "SelectSpecificPrimerDefect",
                        "SelectSpecificDripMark", "SelectSpecificInconsistentThickness", "SelectSpecificWarping", "SelectSpecificPitting");
                    break;
                case (int)productName.MidnightBlue:
                    //run stored procedures on report values and seed report for MidnightBlue
                    seedReport((int)productName.MidnightBlue, "SelectSpecficTotalMold", "SelectSpecificInspectionScrapONE", "SelectSpecificTotalPaint",
                       "SelectSpecificScrapAndReworkTWO", "SelectSpecificTotalAssembly", "SelectSpecificScrapAndReworkTHREE", "SelectSpecificTotalPackage");

                    //run stored procedures on pareto values and seed pareto for MidnightBlue
                    seedDiagram((int)productName.MidnightBlue, "SelectSpecificFinalCoatFlaw", "SelectSpecificBrokenShell", "SelectSpecificBrokenAxle", "SelectSpecificTangledString", "SelectSpecificPrimerDefect",
                        "SelectSpecificDripMark", "SelectSpecificInconsistentThickness", "SelectSpecificWarping", "SelectSpecificPitting");
                    break;
                case (int)productName.ScreamingOrange:
                    //run stored procedures on report values and seed report for ScreamingOrange
                    seedReport((int)productName.ScreamingOrange, "SelectSpecficTotalMold", "SelectSpecificInspectionScrapONE", "SelectSpecificTotalPaint",
                       "SelectSpecificScrapAndReworkTWO", "SelectSpecificTotalAssembly", "SelectSpecificScrapAndReworkTHREE", "SelectSpecificTotalPackage");

                    //run stored procedures on pareto values and seed pareto for ScreamingOrange
                    seedDiagram((int)productName.ScreamingOrange, "SelectSpecificFinalCoatFlaw", "SelectSpecificBrokenShell", "SelectSpecificBrokenAxle", "SelectSpecificTangledString", "SelectSpecificPrimerDefect",
                        "SelectSpecificDripMark", "SelectSpecificInconsistentThickness", "SelectSpecificWarping", "SelectSpecificPitting");
                    break;
                case (int)productName.GoldGlitter:
                    //run stored procedures on report values and seed report for GoldGlitter
                    seedReport((int)productName.GoldGlitter, "SelectSpecficTotalMold", "SelectSpecificInspectionScrapONE", "SelectSpecificTotalPaint",
                       "SelectSpecificScrapAndReworkTWO", "SelectSpecificTotalAssembly", "SelectSpecificScrapAndReworkTHREE", "SelectSpecificTotalPackage");

                    //run stored procedures on pareto values and seed pareto for GoldGlitter
                    seedDiagram((int)productName.GoldGlitter, "SelectSpecificFinalCoatFlaw", "SelectSpecificBrokenShell", "SelectSpecificBrokenAxle", "SelectSpecificTangledString", "SelectSpecificPrimerDefect",
                        "SelectSpecificDripMark", "SelectSpecificInconsistentThickness", "SelectSpecificWarping", "SelectSpecificPitting");
                    break;
                case (int)productName.WhiteLightening:
                    //run stored procedures on report values and seed report for WhiteLightening
                    seedReport((int)productName.WhiteLightening, "SelectSpecficTotalMold", "SelectSpecificInspectionScrapONE", "SelectSpecificTotalPaint",
                       "SelectSpecificScrapAndReworkTWO", "SelectSpecificTotalAssembly", "SelectSpecificScrapAndReworkTHREE", "SelectSpecificTotalPackage");

                    //run stored procedures on pareto values and seed pareto for WhiteLightening
                    seedDiagram((int)productName.WhiteLightening, "SelectSpecificFinalCoatFlaw", "SelectSpecificBrokenShell", "SelectSpecificBrokenAxle", "SelectSpecificTangledString", "SelectSpecificPrimerDefect",
                        "SelectSpecificDripMark", "SelectSpecificInconsistentThickness", "SelectSpecificWarping", "SelectSpecificPitting");
                    break;
                default:
                    break;
            }
        }
    }
}
