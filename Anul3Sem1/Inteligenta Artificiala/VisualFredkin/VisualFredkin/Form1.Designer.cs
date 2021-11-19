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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NextStep = new System.Windows.Forms.Button();
            this.Toggle = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.color1 = new System.Windows.Forms.Button();
            this.color2 = new System.Windows.Forms.Button();
            this.color3 = new System.Windows.Forms.Button();
            this.color4 = new System.Windows.Forms.Button();
            this.color5 = new System.Windows.Forms.Button();
            this.color6 = new System.Windows.Forms.Button();
            this.color7 = new System.Windows.Forms.Button();
            this.color8 = new System.Windows.Forms.Button();
            this.color9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(510, 510);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // NextStep
            // 
            this.NextStep.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NextStep.Location = new System.Drawing.Point(516, 71);
            this.NextStep.Name = "NextStep";
            this.NextStep.Size = new System.Drawing.Size(107, 32);
            this.NextStep.TabIndex = 1;
            this.NextStep.Text = "Next Step";
            this.NextStep.UseVisualStyleBackColor = true;
            this.NextStep.Click += new System.EventHandler(this.NextStep_Click);
            // 
            // Toggle
            // 
            this.Toggle.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Toggle.Location = new System.Drawing.Point(516, 109);
            this.Toggle.Name = "Toggle";
            this.Toggle.Size = new System.Drawing.Size(107, 32);
            this.Toggle.TabIndex = 2;
            this.Toggle.Text = "Toggle";
            this.Toggle.UseVisualStyleBackColor = true;
            this.Toggle.Click += new System.EventHandler(this.Toggle_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(516, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nr. of colors:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(520, 35);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 30);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "2";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(512, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Colors:";
            // 
            // color1
            // 
            this.color1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color1.Location = new System.Drawing.Point(516, 170);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(107, 32);
            this.color1.TabIndex = 6;
            this.color1.Text = "1";
            this.color1.UseVisualStyleBackColor = true;
            this.color1.Click += new System.EventHandler(this.collor1_Click);
            // 
            // color2
            // 
            this.color2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color2.Location = new System.Drawing.Point(516, 208);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(107, 32);
            this.color2.TabIndex = 7;
            this.color2.Text = "2";
            this.color2.UseVisualStyleBackColor = true;
            this.color2.Click += new System.EventHandler(this.collor2_Click);
            // 
            // color3
            // 
            this.color3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color3.Location = new System.Drawing.Point(516, 246);
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(107, 32);
            this.color3.TabIndex = 8;
            this.color3.Text = "3";
            this.color3.UseVisualStyleBackColor = true;
            this.color3.Click += new System.EventHandler(this.collor3_Click);
            // 
            // color4
            // 
            this.color4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color4.Location = new System.Drawing.Point(516, 284);
            this.color4.Name = "color4";
            this.color4.Size = new System.Drawing.Size(107, 32);
            this.color4.TabIndex = 9;
            this.color4.Text = "4";
            this.color4.UseVisualStyleBackColor = true;
            this.color4.Click += new System.EventHandler(this.collor4_Click);
            // 
            // color5
            // 
            this.color5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color5.Location = new System.Drawing.Point(516, 322);
            this.color5.Name = "color5";
            this.color5.Size = new System.Drawing.Size(107, 32);
            this.color5.TabIndex = 10;
            this.color5.Text = "5";
            this.color5.UseVisualStyleBackColor = true;
            this.color5.Click += new System.EventHandler(this.collor5_Click);
            // 
            // color6
            // 
            this.color6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color6.Location = new System.Drawing.Point(516, 360);
            this.color6.Name = "color6";
            this.color6.Size = new System.Drawing.Size(107, 32);
            this.color6.TabIndex = 11;
            this.color6.Text = "6";
            this.color6.UseVisualStyleBackColor = true;
            this.color6.Click += new System.EventHandler(this.collor6_Click);
            // 
            // color7
            // 
            this.color7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color7.Location = new System.Drawing.Point(516, 398);
            this.color7.Name = "color7";
            this.color7.Size = new System.Drawing.Size(107, 32);
            this.color7.TabIndex = 12;
            this.color7.Text = "7";
            this.color7.UseVisualStyleBackColor = true;
            this.color7.Click += new System.EventHandler(this.collor7_Click);
            // 
            // color8
            // 
            this.color8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color8.Location = new System.Drawing.Point(516, 436);
            this.color8.Name = "color8";
            this.color8.Size = new System.Drawing.Size(107, 32);
            this.color8.TabIndex = 13;
            this.color8.Text = "8";
            this.color8.UseVisualStyleBackColor = true;
            this.color8.Click += new System.EventHandler(this.collor8_Click);
            // 
            // color9
            // 
            this.color9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color9.Location = new System.Drawing.Point(516, 473);
            this.color9.Name = "color9";
            this.color9.Size = new System.Drawing.Size(107, 32);
            this.color9.TabIndex = 14;
            this.color9.Text = "9";
            this.color9.UseVisualStyleBackColor = true;
            this.color9.Click += new System.EventHandler(this.collor9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 517);
            this.Controls.Add(this.color9);
            this.Controls.Add(this.color8);
            this.Controls.Add(this.color7);
            this.Controls.Add(this.color6);
            this.Controls.Add(this.color5);
            this.Controls.Add(this.color4);
            this.Controls.Add(this.color3);
            this.Controls.Add(this.color2);
            this.Controls.Add(this.color1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Toggle);
            this.Controls.Add(this.NextStep);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NextStep;
        private System.Windows.Forms.Button Toggle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button color1;
        public System.Windows.Forms.Button color2;
        public System.Windows.Forms.Button color3;
        public System.Windows.Forms.Button color4;
        public System.Windows.Forms.Button color5;
        public System.Windows.Forms.Button color6;
        public System.Windows.Forms.Button color7;
        public System.Windows.Forms.Button color8;
        public System.Windows.Forms.Button color9;
    }
}

