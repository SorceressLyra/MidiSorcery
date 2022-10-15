namespace MidiSorcery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PlayPauseButton = new System.Windows.Forms.Button();
            this.TrackBar = new System.Windows.Forms.TrackBar();
            this.ProgressText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayPauseButton
            // 
            this.PlayPauseButton.Location = new System.Drawing.Point(12, 12);
            this.PlayPauseButton.Name = "PlayPauseButton";
            this.PlayPauseButton.Size = new System.Drawing.Size(75, 59);
            this.PlayPauseButton.TabIndex = 0;
            this.PlayPauseButton.Text = "Pause";
            this.PlayPauseButton.UseVisualStyleBackColor = true;
            this.PlayPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // TrackBar
            // 
            this.TrackBar.Location = new System.Drawing.Point(115, 26);
            this.TrackBar.Maximum = 50;
            this.TrackBar.Name = "TrackBar";
            this.TrackBar.Size = new System.Drawing.Size(363, 45);
            this.TrackBar.TabIndex = 1;
            this.TrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TrackBar.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // ProgressText
            // 
            this.ProgressText.AutoSize = true;
            this.ProgressText.Location = new System.Drawing.Point(115, 9);
            this.ProgressText.Name = "ProgressText";
            this.ProgressText.Size = new System.Drawing.Size(52, 15);
            this.ProgressText.TabIndex = 2;
            this.ProgressText.Text = "Progress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 86);
            this.Controls.Add(this.ProgressText);
            this.Controls.Add(this.TrackBar);
            this.Controls.Add(this.PlayPauseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PlayPauseButton;
        private TrackBar TrackBar;
        private Label ProgressText;
    }
}