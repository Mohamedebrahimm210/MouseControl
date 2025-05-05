namespace MouseControl
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnStop = new Button();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            lblTimer = new Label();
            uiTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(48, 91);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(178, 91);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Location = new Point(678, 427);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 2;
            label1.Text = "Copyright Abosa";
            // 
            // lblTimer
            // 
            lblTimer.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTimer.Location = new Point(48, 31);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(224, 30);
            lblTimer.TabIndex = 4;
            lblTimer.Text = "Timer: Not started";
            // 
            // uiTimer
            // 
            uiTimer.Interval = 1000;
            uiTimer.Tick += UiTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblTimer);
            Name = "Form1";
            Text = "Mouse Mover";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label label1;
        private Label lblTimer;
        private System.Windows.Forms.Timer uiTimer; // Timer for countdown display
        private System.Windows.Forms.Timer timer1;
    }
}
