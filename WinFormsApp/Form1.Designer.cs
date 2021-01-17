
namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxWave = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbxSpectrum = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarAmplification = new System.Windows.Forms.TrackBar();
            this.lbFreqWindow = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarWindowFreq = new System.Windows.Forms.TrackBar();
            this.lbCentralFreq = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarCentralFreq = new System.Windows.Forms.TrackBar();
            this.lbAmplitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetScale = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSnapshot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSpectrum)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmplification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWindowFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCentralFreq)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxWave
            // 
            this.pbxWave.BackColor = System.Drawing.Color.Black;
            this.pbxWave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxWave.Location = new System.Drawing.Point(0, 0);
            this.pbxWave.Name = "pbxWave";
            this.pbxWave.Size = new System.Drawing.Size(1874, 380);
            this.pbxWave.TabIndex = 0;
            this.pbxWave.TabStop = false;
            this.pbxWave.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxWave_Paint);
            this.pbxWave.Resize += new System.EventHandler(this.pbxWave_Resize);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbxWave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbxSpectrum);
            this.splitContainer1.Size = new System.Drawing.Size(1874, 760);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 1;
            // 
            // pbxSpectrum
            // 
            this.pbxSpectrum.BackColor = System.Drawing.Color.Black;
            this.pbxSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxSpectrum.Location = new System.Drawing.Point(0, 0);
            this.pbxSpectrum.Name = "pbxSpectrum";
            this.pbxSpectrum.Size = new System.Drawing.Size(1874, 376);
            this.pbxSpectrum.TabIndex = 1;
            this.pbxSpectrum.TabStop = false;
            this.pbxSpectrum.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxSpectrum_Paint);
            this.pbxSpectrum.Resize += new System.EventHandler(this.pbxSpectrum_Resize);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.trackBarAmplification);
            this.panel1.Controls.Add(this.lbFreqWindow);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.trackBarWindowFreq);
            this.panel1.Controls.Add(this.lbCentralFreq);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.trackBarCentralFreq);
            this.panel1.Controls.Add(this.lbAmplitude);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnResetScale);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnSnapshot);
            this.panel1.Location = new System.Drawing.Point(12, 778);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1874, 233);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1113, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "AMPLIFICATION";
            // 
            // trackBarAmplification
            // 
            this.trackBarAmplification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarAmplification.Location = new System.Drawing.Point(1555, 3);
            this.trackBarAmplification.Maximum = 1000;
            this.trackBarAmplification.Minimum = 1;
            this.trackBarAmplification.Name = "trackBarAmplification";
            this.trackBarAmplification.Size = new System.Drawing.Size(294, 45);
            this.trackBarAmplification.TabIndex = 12;
            this.trackBarAmplification.Value = 1;
            this.trackBarAmplification.Scroll += new System.EventHandler(this.trackBarAmplification_Scroll);
            // 
            // lbFreqWindow
            // 
            this.lbFreqWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFreqWindow.AutoSize = true;
            this.lbFreqWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFreqWindow.Location = new System.Drawing.Point(1347, 151);
            this.lbFreqWindow.Name = "lbFreqWindow";
            this.lbFreqWindow.Size = new System.Drawing.Size(48, 26);
            this.lbFreqWindow.TabIndex = 11;
            this.lbFreqWindow.Text = "???";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1110, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "FREQ WINDOW ±";
            // 
            // trackBarWindowFreq
            // 
            this.trackBarWindowFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarWindowFreq.Location = new System.Drawing.Point(1555, 153);
            this.trackBarWindowFreq.Maximum = 3000;
            this.trackBarWindowFreq.Minimum = 10;
            this.trackBarWindowFreq.Name = "trackBarWindowFreq";
            this.trackBarWindowFreq.Size = new System.Drawing.Size(294, 45);
            this.trackBarWindowFreq.TabIndex = 9;
            this.trackBarWindowFreq.Value = 10;
            this.trackBarWindowFreq.Scroll += new System.EventHandler(this.trackBarWindowFreq_Scroll);
            // 
            // lbCentralFreq
            // 
            this.lbCentralFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCentralFreq.AutoSize = true;
            this.lbCentralFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCentralFreq.Location = new System.Drawing.Point(1347, 84);
            this.lbCentralFreq.Name = "lbCentralFreq";
            this.lbCentralFreq.Size = new System.Drawing.Size(48, 26);
            this.lbCentralFreq.TabIndex = 8;
            this.lbCentralFreq.Text = "???";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1110, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "CENTRAL FREQ";
            // 
            // trackBarCentralFreq
            // 
            this.trackBarCentralFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarCentralFreq.Location = new System.Drawing.Point(1555, 78);
            this.trackBarCentralFreq.Maximum = 22000;
            this.trackBarCentralFreq.Minimum = 100;
            this.trackBarCentralFreq.Name = "trackBarCentralFreq";
            this.trackBarCentralFreq.Size = new System.Drawing.Size(294, 45);
            this.trackBarCentralFreq.TabIndex = 6;
            this.trackBarCentralFreq.Value = 18222;
            this.trackBarCentralFreq.Scroll += new System.EventHandler(this.trackBarCentralFreq_Scroll);
            // 
            // lbAmplitude
            // 
            this.lbAmplitude.AutoSize = true;
            this.lbAmplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAmplitude.Location = new System.Drawing.Point(773, 9);
            this.lbAmplitude.Name = "lbAmplitude";
            this.lbAmplitude.Size = new System.Drawing.Size(48, 26);
            this.lbAmplitude.TabIndex = 5;
            this.lbAmplitude.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(525, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "MAX AMPLITUDE";
            // 
            // btnResetScale
            // 
            this.btnResetScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResetScale.Location = new System.Drawing.Point(351, 3);
            this.btnResetScale.Name = "btnResetScale";
            this.btnResetScale.Size = new System.Drawing.Size(168, 62);
            this.btnResetScale.TabIndex = 3;
            this.btnResetScale.Text = "1:1";
            this.btnResetScale.UseVisualStyleBackColor = true;
            this.btnResetScale.Click += new System.EventHandler(this.btnResetScale_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(177, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(168, 62);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSnapshot.Location = new System.Drawing.Point(3, 3);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(168, 62);
            this.btnSnapshot.TabIndex = 0;
            this.btnSnapshot.Text = "Start";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Signal graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbxWave)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSpectrum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmplification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWindowFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCentralFreq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxWave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbxSpectrum;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnResetScale;
        private System.Windows.Forms.Label lbAmplitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarCentralFreq;
        private System.Windows.Forms.Label lbCentralFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbFreqWindow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarWindowFreq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarAmplification;
    }
}

