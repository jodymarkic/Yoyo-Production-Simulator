namespace BI_A02
{
    partial class myForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.yoyoComboBox = new System.Windows.Forms.ComboBox();
            this.myChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.updateButton = new System.Windows.Forms.Button();
            this.TotalMoldedLabel = new System.Windows.Forms.Label();
            this.SuccessMoldLabel = new System.Windows.Forms.Label();
            this.YieldMoldLabel = new System.Windows.Forms.Label();
            this.SuccessPaintlabel = new System.Windows.Forms.Label();
            this.YieldPaintLabel = new System.Windows.Forms.Label();
            this.SuccessAssembleLabel = new System.Windows.Forms.Label();
            this.TotalPackageLabel = new System.Windows.Forms.Label();
            this.TotalYieldLabel = new System.Windows.Forms.Label();
            this.TotalMolded = new System.Windows.Forms.Label();
            this.TotalSuccessfulMolds = new System.Windows.Forms.Label();
            this.YieldAtMold = new System.Windows.Forms.Label();
            this.TotalSuccessfulPaints = new System.Windows.Forms.Label();
            this.YieldAtPaint = new System.Windows.Forms.Label();
            this.TotalSuccessfulAssembly = new System.Windows.Forms.Label();
            this.TotalPartsPackaged = new System.Windows.Forms.Label();
            this.TotalYield = new System.Windows.Forms.Label();
            this.YieldAtAssemblyLabel = new System.Windows.Forms.Label();
            this.YieldAtAssembly = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).BeginInit();
            this.SuspendLayout();
            // 
            // yoyoComboBox
            // 
            this.yoyoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yoyoComboBox.FormattingEnabled = true;
            this.yoyoComboBox.Location = new System.Drawing.Point(13, 13);
            this.yoyoComboBox.Name = "yoyoComboBox";
            this.yoyoComboBox.Size = new System.Drawing.Size(328, 33);
            this.yoyoComboBox.TabIndex = 0;
            this.yoyoComboBox.Text = "Select a Yoyo...";
            this.yoyoComboBox.SelectedIndexChanged += new System.EventHandler(this.yoyoComboBox_SelectedIndexChanged);
            // 
            // myChart
            // 
            chartArea1.Name = "ChartArea1";
            this.myChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.myChart.Legends.Add(legend1);
            this.myChart.Location = new System.Drawing.Point(353, 12);
            this.myChart.Name = "myChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.myChart.Series.Add(series1);
            this.myChart.Size = new System.Drawing.Size(540, 483);
            this.myChart.TabIndex = 1;
            this.myChart.Text = "Pareto Diagram";
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(13, 394);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(329, 101);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "UPDATE";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // TotalMoldedLabel
            // 
            this.TotalMoldedLabel.AutoSize = true;
            this.TotalMoldedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalMoldedLabel.Location = new System.Drawing.Point(15, 66);
            this.TotalMoldedLabel.Name = "TotalMoldedLabel";
            this.TotalMoldedLabel.Size = new System.Drawing.Size(100, 20);
            this.TotalMoldedLabel.TabIndex = 3;
            this.TotalMoldedLabel.Text = "Total Molded";
            // 
            // SuccessMoldLabel
            // 
            this.SuccessMoldLabel.AutoSize = true;
            this.SuccessMoldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccessMoldLabel.Location = new System.Drawing.Point(15, 104);
            this.SuccessMoldLabel.Name = "SuccessMoldLabel";
            this.SuccessMoldLabel.Size = new System.Drawing.Size(172, 20);
            this.SuccessMoldLabel.TabIndex = 4;
            this.SuccessMoldLabel.Text = "Total Successful Molds";
            // 
            // YieldMoldLabel
            // 
            this.YieldMoldLabel.AutoSize = true;
            this.YieldMoldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YieldMoldLabel.Location = new System.Drawing.Point(15, 142);
            this.YieldMoldLabel.Name = "YieldMoldLabel";
            this.YieldMoldLabel.Size = new System.Drawing.Size(102, 20);
            this.YieldMoldLabel.TabIndex = 5;
            this.YieldMoldLabel.Text = "Yield At Mold";
            // 
            // SuccessPaintlabel
            // 
            this.SuccessPaintlabel.AutoSize = true;
            this.SuccessPaintlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccessPaintlabel.Location = new System.Drawing.Point(15, 181);
            this.SuccessPaintlabel.Name = "SuccessPaintlabel";
            this.SuccessPaintlabel.Size = new System.Drawing.Size(174, 20);
            this.SuccessPaintlabel.TabIndex = 6;
            this.SuccessPaintlabel.Text = "Total Successful Paints";
            // 
            // YieldPaintLabel
            // 
            this.YieldPaintLabel.AutoSize = true;
            this.YieldPaintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YieldPaintLabel.Location = new System.Drawing.Point(15, 218);
            this.YieldPaintLabel.Name = "YieldPaintLabel";
            this.YieldPaintLabel.Size = new System.Drawing.Size(104, 20);
            this.YieldPaintLabel.TabIndex = 7;
            this.YieldPaintLabel.Text = "Yield At Paint";
            // 
            // SuccessAssembleLabel
            // 
            this.SuccessAssembleLabel.AutoSize = true;
            this.SuccessAssembleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccessAssembleLabel.Location = new System.Drawing.Point(15, 255);
            this.SuccessAssembleLabel.Name = "SuccessAssembleLabel";
            this.SuccessAssembleLabel.Size = new System.Drawing.Size(190, 20);
            this.SuccessAssembleLabel.TabIndex = 8;
            this.SuccessAssembleLabel.Text = "Total Succesful Assembly";
            // 
            // TotalPackageLabel
            // 
            this.TotalPackageLabel.AutoSize = true;
            this.TotalPackageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPackageLabel.Location = new System.Drawing.Point(15, 325);
            this.TotalPackageLabel.Name = "TotalPackageLabel";
            this.TotalPackageLabel.Size = new System.Drawing.Size(160, 20);
            this.TotalPackageLabel.TabIndex = 9;
            this.TotalPackageLabel.Text = "Total Parts Packaged";
            // 
            // TotalYieldLabel
            // 
            this.TotalYieldLabel.AutoSize = true;
            this.TotalYieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalYieldLabel.Location = new System.Drawing.Point(15, 361);
            this.TotalYieldLabel.Name = "TotalYieldLabel";
            this.TotalYieldLabel.Size = new System.Drawing.Size(83, 20);
            this.TotalYieldLabel.TabIndex = 10;
            this.TotalYieldLabel.Text = "Total Yield";
            // 
            // TotalMolded
            // 
            this.TotalMolded.AutoSize = true;
            this.TotalMolded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalMolded.Location = new System.Drawing.Point(237, 66);
            this.TotalMolded.Name = "TotalMolded";
            this.TotalMolded.Size = new System.Drawing.Size(0, 20);
            this.TotalMolded.TabIndex = 11;
            // 
            // TotalSuccessfulMolds
            // 
            this.TotalSuccessfulMolds.AutoSize = true;
            this.TotalSuccessfulMolds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalSuccessfulMolds.Location = new System.Drawing.Point(237, 104);
            this.TotalSuccessfulMolds.Name = "TotalSuccessfulMolds";
            this.TotalSuccessfulMolds.Size = new System.Drawing.Size(0, 20);
            this.TotalSuccessfulMolds.TabIndex = 12;
            // 
            // YieldAtMold
            // 
            this.YieldAtMold.AutoSize = true;
            this.YieldAtMold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YieldAtMold.Location = new System.Drawing.Point(237, 142);
            this.YieldAtMold.Name = "YieldAtMold";
            this.YieldAtMold.Size = new System.Drawing.Size(0, 20);
            this.YieldAtMold.TabIndex = 13;
            // 
            // TotalSuccessfulPaints
            // 
            this.TotalSuccessfulPaints.AutoSize = true;
            this.TotalSuccessfulPaints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalSuccessfulPaints.Location = new System.Drawing.Point(237, 181);
            this.TotalSuccessfulPaints.Name = "TotalSuccessfulPaints";
            this.TotalSuccessfulPaints.Size = new System.Drawing.Size(0, 20);
            this.TotalSuccessfulPaints.TabIndex = 14;
            // 
            // YieldAtPaint
            // 
            this.YieldAtPaint.AutoSize = true;
            this.YieldAtPaint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YieldAtPaint.Location = new System.Drawing.Point(237, 218);
            this.YieldAtPaint.Name = "YieldAtPaint";
            this.YieldAtPaint.Size = new System.Drawing.Size(0, 20);
            this.YieldAtPaint.TabIndex = 15;
            // 
            // TotalSuccessfulAssembly
            // 
            this.TotalSuccessfulAssembly.AutoSize = true;
            this.TotalSuccessfulAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalSuccessfulAssembly.Location = new System.Drawing.Point(237, 255);
            this.TotalSuccessfulAssembly.Name = "TotalSuccessfulAssembly";
            this.TotalSuccessfulAssembly.Size = new System.Drawing.Size(0, 20);
            this.TotalSuccessfulAssembly.TabIndex = 16;
            // 
            // TotalPartsPackaged
            // 
            this.TotalPartsPackaged.AutoSize = true;
            this.TotalPartsPackaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPartsPackaged.Location = new System.Drawing.Point(237, 325);
            this.TotalPartsPackaged.Name = "TotalPartsPackaged";
            this.TotalPartsPackaged.Size = new System.Drawing.Size(0, 20);
            this.TotalPartsPackaged.TabIndex = 17;
            // 
            // TotalYield
            // 
            this.TotalYield.AutoSize = true;
            this.TotalYield.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalYield.Location = new System.Drawing.Point(237, 361);
            this.TotalYield.Name = "TotalYield";
            this.TotalYield.Size = new System.Drawing.Size(0, 20);
            this.TotalYield.TabIndex = 18;
            // 
            // YieldAtAssemblyLabel
            // 
            this.YieldAtAssemblyLabel.AutoSize = true;
            this.YieldAtAssemblyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YieldAtAssemblyLabel.Location = new System.Drawing.Point(15, 292);
            this.YieldAtAssemblyLabel.Name = "YieldAtAssemblyLabel";
            this.YieldAtAssemblyLabel.Size = new System.Drawing.Size(136, 20);
            this.YieldAtAssemblyLabel.TabIndex = 19;
            this.YieldAtAssemblyLabel.Text = "Yield At Assembly";
            // 
            // YieldAtAssembly
            // 
            this.YieldAtAssembly.AutoSize = true;
            this.YieldAtAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YieldAtAssembly.Location = new System.Drawing.Point(237, 292);
            this.YieldAtAssembly.Name = "YieldAtAssembly";
            this.YieldAtAssembly.Size = new System.Drawing.Size(0, 20);
            this.YieldAtAssembly.TabIndex = 20;
            // 
            // myForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 507);
            this.Controls.Add(this.YieldAtAssembly);
            this.Controls.Add(this.YieldAtAssemblyLabel);
            this.Controls.Add(this.TotalYield);
            this.Controls.Add(this.TotalPartsPackaged);
            this.Controls.Add(this.TotalSuccessfulAssembly);
            this.Controls.Add(this.YieldAtPaint);
            this.Controls.Add(this.TotalSuccessfulPaints);
            this.Controls.Add(this.YieldAtMold);
            this.Controls.Add(this.TotalSuccessfulMolds);
            this.Controls.Add(this.TotalMolded);
            this.Controls.Add(this.TotalYieldLabel);
            this.Controls.Add(this.TotalPackageLabel);
            this.Controls.Add(this.SuccessAssembleLabel);
            this.Controls.Add(this.YieldPaintLabel);
            this.Controls.Add(this.SuccessPaintlabel);
            this.Controls.Add(this.YieldMoldLabel);
            this.Controls.Add(this.SuccessMoldLabel);
            this.Controls.Add(this.TotalMoldedLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.myChart);
            this.Controls.Add(this.yoyoComboBox);
            this.Name = "myForm";
            this.Text = "1";
            ((System.ComponentModel.ISupportInitialize)(this.myChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox yoyoComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart myChart;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label TotalMoldedLabel;
        private System.Windows.Forms.Label SuccessMoldLabel;
        private System.Windows.Forms.Label YieldMoldLabel;
        private System.Windows.Forms.Label SuccessPaintlabel;
        private System.Windows.Forms.Label YieldPaintLabel;
        private System.Windows.Forms.Label SuccessAssembleLabel;
        private System.Windows.Forms.Label TotalPackageLabel;
        private System.Windows.Forms.Label TotalYieldLabel;
        private System.Windows.Forms.Label TotalMolded;
        private System.Windows.Forms.Label TotalSuccessfulMolds;
        private System.Windows.Forms.Label YieldAtMold;
        private System.Windows.Forms.Label TotalSuccessfulPaints;
        private System.Windows.Forms.Label YieldAtPaint;
        private System.Windows.Forms.Label TotalSuccessfulAssembly;
        private System.Windows.Forms.Label TotalPartsPackaged;
        private System.Windows.Forms.Label TotalYield;
        private System.Windows.Forms.Label YieldAtAssemblyLabel;
        private System.Windows.Forms.Label YieldAtAssembly;
    }
}

