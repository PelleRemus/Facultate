namespace VisualFredkin
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NextStep = new System.Windows.Forms.Button();
            this.InfiniteSteps = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 440);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // NextStep
            // 
            this.NextStep.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NextStep.Location = new System.Drawing.Point(446, 168);
            this.NextStep.Name = "NextStep";
            this.NextStep.Size = new System.Drawing.Size(107, 40);
            this.NextStep.TabIndex = 1;
            this.NextStep.Text = "Next Step";
            this.NextStep.UseVisualStyleBackColor = true;
            this.NextStep.Click += new System.EventHandler(this.NextStep_Click);
            // 
            // InfiniteSteps
            // 
            this.InfiniteSteps.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InfiniteSteps.Location = new System.Drawing.Point(446, 214);
            this.InfiniteSteps.Name = "InfiniteSteps";
            this.InfiniteSteps.Size = new System.Drawing.Size(107, 55);
            this.InfiniteSteps.TabIndex = 2;
            this.InfiniteSteps.Text = "Infinite Steps";
            this.InfiniteSteps.UseVisualStyleBackColor = true;
            this.InfiniteSteps.Click += new System.EventHandler(this.InfiniteSteps_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 450);
            this.Controls.Add(this.InfiniteSteps);
            this.Controls.Add(this.NextStep);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NextStep;
        private System.Windows.Forms.Button InfiniteSteps;
    }
}

