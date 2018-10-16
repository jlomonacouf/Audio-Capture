namespace Audio_Capture
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.microphoneButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.computerButton = new System.Windows.Forms.RadioButton();
            this.recordButton = new System.Windows.Forms.Button();
            this.recordingTimer = new System.Windows.Forms.Timer(this.components);
            this.recordingLabel = new System.Windows.Forms.Label();
            this.wavPanel = new System.Windows.Forms.Panel();
            this.lastFileLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.wavPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // microphoneButton
            // 
            this.microphoneButton.AutoSize = true;
            this.microphoneButton.Enabled = false;
            this.microphoneButton.Location = new System.Drawing.Point(6, 91);
            this.microphoneButton.Name = "microphoneButton";
            this.microphoneButton.Size = new System.Drawing.Size(156, 29);
            this.microphoneButton.TabIndex = 0;
            this.microphoneButton.TabStop = true;
            this.microphoneButton.Text = "Microphone";
            this.microphoneButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.computerButton);
            this.groupBox1.Controls.Add(this.microphoneButton);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Device:";
            // 
            // computerButton
            // 
            this.computerButton.AutoSize = true;
            this.computerButton.Checked = true;
            this.computerButton.Location = new System.Drawing.Point(6, 43);
            this.computerButton.Name = "computerButton";
            this.computerButton.Size = new System.Drawing.Size(136, 29);
            this.computerButton.TabIndex = 1;
            this.computerButton.TabStop = true;
            this.computerButton.Text = "Computer";
            this.computerButton.UseVisualStyleBackColor = true;
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(24, 152);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(218, 79);
            this.recordButton.TabIndex = 2;
            this.recordButton.Text = "Start \r\nRecording";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // recordingTimer
            // 
            this.recordingTimer.Interval = 1000;
            this.recordingTimer.Tick += new System.EventHandler(this.recordingTimer_Tick);
            // 
            // recordingLabel
            // 
            this.recordingLabel.AutoSize = true;
            this.recordingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordingLabel.Location = new System.Drawing.Point(99, 234);
            this.recordingLabel.Name = "recordingLabel";
            this.recordingLabel.Size = new System.Drawing.Size(67, 31);
            this.recordingLabel.TabIndex = 3;
            this.recordingLabel.Text = "0:00";
            // 
            // wavPanel
            // 
            this.wavPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.wavPanel.Controls.Add(this.lastFileLabel);
            this.wavPanel.Location = new System.Drawing.Point(255, 12);
            this.wavPanel.Name = "wavPanel";
            this.wavPanel.Size = new System.Drawing.Size(380, 258);
            this.wavPanel.TabIndex = 4;
            this.wavPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.wavPanel_MouseDown);
            this.wavPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.wavPanel_MouseMove);
            this.wavPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.wavPanel_MouseUp);
            // 
            // lastFileLabel
            // 
            this.lastFileLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lastFileLabel.AutoSize = true;
            this.lastFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastFileLabel.Location = new System.Drawing.Point(60, 112);
            this.lastFileLabel.Name = "lastFileLabel";
            this.lastFileLabel.Size = new System.Drawing.Size(267, 31);
            this.lastFileLabel.TabIndex = 0;
            this.lastFileLabel.Text = "View Audio Captures";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 282);
            this.Controls.Add(this.wavPanel);
            this.Controls.Add(this.recordingLabel);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Audio Capture";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.wavPanel.ResumeLayout(false);
            this.wavPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton microphoneButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton computerButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Timer recordingTimer;
        private System.Windows.Forms.Label recordingLabel;
        private System.Windows.Forms.Panel wavPanel;
        private System.Windows.Forms.Label lastFileLabel;
    }
}

