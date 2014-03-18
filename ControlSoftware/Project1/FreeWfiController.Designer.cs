namespace WindowsFormsApplication1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FSpeedLB = new System.Windows.Forms.Label();
            this.SideSpeedLB = new System.Windows.Forms.Label();
            this.FSpeedBox = new System.Windows.Forms.TextBox();
            this.SSpeedBox = new System.Windows.Forms.TextBox();
            this.AutoSpeedBox = new System.Windows.Forms.TextBox();
            this.ForwardSpeedLB = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.FS = new System.Windows.Forms.Label();
            this.SS = new System.Windows.Forms.Label();
            this.AS = new System.Windows.Forms.Label();
            this.AutoModeCheck = new System.Windows.Forms.CheckBox();
            this.FoB = new System.Windows.Forms.Label();
            this.LoR = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Stop, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.FSpeedLB, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SideSpeedLB, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.FSpeedBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.SSpeedBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.AutoSpeedBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ForwardSpeedLB, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.FS, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.SS, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.AS, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.AutoModeCheck, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FoB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LoR, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(397, 143);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Autonomous Mode";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Direction(L/R)";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(16, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Direction(F/B)";
            // 
            // Stop
            // 
            this.Stop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Stop.Location = new System.Drawing.Point(307, 113);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 25;
            this.Stop.Text = "Reset";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 109);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(287, 31);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(355, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Click Here to Control    (WASD + QE)";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // FSpeedLB
            // 
            this.FSpeedLB.AllowDrop = true;
            this.FSpeedLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FSpeedLB.AutoSize = true;
            this.FSpeedLB.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FSpeedLB.Location = new System.Drawing.Point(13, 49);
            this.FSpeedLB.Name = "FSpeedLB";
            this.FSpeedLB.Size = new System.Drawing.Size(79, 13);
            this.FSpeedLB.TabIndex = 4;
            this.FSpeedLB.Text = "Forward Speed";
            this.FSpeedLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SideSpeedLB
            // 
            this.SideSpeedLB.AllowDrop = true;
            this.SideSpeedLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SideSpeedLB.AutoSize = true;
            this.SideSpeedLB.Location = new System.Drawing.Point(22, 69);
            this.SideSpeedLB.Name = "SideSpeedLB";
            this.SideSpeedLB.Size = new System.Drawing.Size(62, 13);
            this.SideSpeedLB.TabIndex = 5;
            this.SideSpeedLB.Text = "Side Speed";
            // 
            // FSpeedBox
            // 
            this.FSpeedBox.AllowDrop = true;
            this.FSpeedBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FSpeedBox.Location = new System.Drawing.Point(109, 49);
            this.FSpeedBox.Name = "FSpeedBox";
            this.FSpeedBox.Size = new System.Drawing.Size(61, 20);
            this.FSpeedBox.TabIndex = 2;
            this.FSpeedBox.Text = "127";
            this.FSpeedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SSpeedBox
            // 
            this.SSpeedBox.AllowDrop = true;
            this.SSpeedBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SSpeedBox.Location = new System.Drawing.Point(109, 69);
            this.SSpeedBox.Name = "SSpeedBox";
            this.SSpeedBox.Size = new System.Drawing.Size(61, 20);
            this.SSpeedBox.TabIndex = 3;
            this.SSpeedBox.Text = "127";
            this.SSpeedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AutoSpeedBox
            // 
            this.AutoSpeedBox.AllowDrop = true;
            this.AutoSpeedBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AutoSpeedBox.Location = new System.Drawing.Point(109, 89);
            this.AutoSpeedBox.Name = "AutoSpeedBox";
            this.AutoSpeedBox.Size = new System.Drawing.Size(61, 20);
            this.AutoSpeedBox.TabIndex = 11;
            this.AutoSpeedBox.Text = "90";
            this.AutoSpeedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ForwardSpeedLB
            // 
            this.ForwardSpeedLB.AllowDrop = true;
            this.ForwardSpeedLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ForwardSpeedLB.AutoSize = true;
            this.ForwardSpeedLB.Location = new System.Drawing.Point(189, 0);
            this.ForwardSpeedLB.Name = "ForwardSpeedLB";
            this.ForwardSpeedLB.Size = new System.Drawing.Size(88, 13);
            this.ForwardSpeedLB.TabIndex = 15;
            this.ForwardSpeedLB.Text = "Forward Speed =";
            this.ForwardSpeedLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AllowDrop = true;
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(197, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Side Speed =";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(178, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Autonomous Speed =";
            // 
            // FS
            // 
            this.FS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FS.AutoSize = true;
            this.FS.Location = new System.Drawing.Point(338, 0);
            this.FS.Name = "FS";
            this.FS.Size = new System.Drawing.Size(13, 13);
            this.FS.TabIndex = 21;
            this.FS.Text = "0";
            // 
            // SS
            // 
            this.SS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SS.AutoSize = true;
            this.SS.Location = new System.Drawing.Point(338, 13);
            this.SS.Name = "SS";
            this.SS.Size = new System.Drawing.Size(13, 13);
            this.SS.TabIndex = 22;
            this.SS.Text = "0";
            // 
            // AS
            // 
            this.AS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AS.AutoSize = true;
            this.AS.Location = new System.Drawing.Point(331, 29);
            this.AS.Name = "AS";
            this.AS.Size = new System.Drawing.Size(27, 13);
            this.AS.TabIndex = 23;
            this.AS.Text = "N/A";
            // 
            // AutoModeCheck
            // 
            this.AutoModeCheck.AllowDrop = true;
            this.AutoModeCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AutoModeCheck.AutoSize = true;
            this.AutoModeCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoModeCheck.Location = new System.Drawing.Point(132, 29);
            this.AutoModeCheck.Name = "AutoModeCheck";
            this.AutoModeCheck.Size = new System.Drawing.Size(15, 14);
            this.AutoModeCheck.TabIndex = 1;
            this.AutoModeCheck.UseVisualStyleBackColor = true;
            this.AutoModeCheck.CheckedChanged += new System.EventHandler(this.AutoModeCheck_CheckedChanged_1);
            // 
            // FoB
            // 
            this.FoB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FoB.AutoSize = true;
            this.FoB.Location = new System.Drawing.Point(126, 0);
            this.FoB.Name = "FoB";
            this.FoB.Size = new System.Drawing.Size(27, 13);
            this.FoB.TabIndex = 10;
            this.FoB.Text = "N/A";
            // 
            // LoR
            // 
            this.LoR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoR.AutoSize = true;
            this.LoR.Location = new System.Drawing.Point(126, 13);
            this.LoR.Name = "LoR";
            this.LoR.Size = new System.Drawing.Size(27, 13);
            this.LoR.TabIndex = 28;
            this.LoR.Text = "N/A";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Autonomous Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 143);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Wireless Robot Controller";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox SSpeedBox;
        private System.Windows.Forms.Label SideSpeedLB;
        private System.Windows.Forms.TextBox FSpeedBox;
        private System.Windows.Forms.Label FSpeedLB;
        private System.Windows.Forms.CheckBox AutoModeCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AutoSpeedBox;
        private System.Windows.Forms.Label FoB;
        private System.Windows.Forms.Label AS;
        private System.Windows.Forms.Label SS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label FS;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Label ForwardSpeedLB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LoR;
        private System.Windows.Forms.Label label7;
    }
}

