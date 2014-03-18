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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LableSpinSpeed = new System.Windows.Forms.Label();
            this.LBForwardSpeed = new System.Windows.Forms.Label();
            this.LBSideSpeed = new System.Windows.Forms.Label();
            this.LBForSpeed = new System.Windows.Forms.Label();
            this.LBSiSpeed = new System.Windows.Forms.Label();
            this.LBSpinSpeed = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.TBController = new System.Windows.Forms.TextBox();
            this.LBFSpeed = new System.Windows.Forms.Label();
            this.TBFSpeed = new System.Windows.Forms.TextBox();
            this.LBLoR = new System.Windows.Forms.Label();
            this.LBFoB = new System.Windows.Forms.Label();
            this.TBSSpeed = new System.Windows.Forms.TextBox();
            this.LBSSpeed = new System.Windows.Forms.Label();
            this.LBSpinSpe = new System.Windows.Forms.Label();
            this.TBSpinSpeed = new System.Windows.Forms.TextBox();
            this.LBSpinDir = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.LBConnected = new System.Windows.Forms.Label();
            this.LBSonarRReading = new System.Windows.Forms.Label();
            this.LBSonarLReading = new System.Windows.Forms.Label();
            this.LBAutoSpeed = new System.Windows.Forms.Label();
            this.CBAutoMode = new System.Windows.Forms.CheckBox();
            this.LBSonarL = new System.Windows.Forms.Label();
            this.LBSonar2 = new System.Windows.Forms.Label();
            this.Arduino = new System.IO.Ports.SerialPort(this.components);
            this.TxTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.LableSpinSpeed, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LBForwardSpeed, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LBSideSpeed, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBForSpeed, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.LBSiSpeed, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBSpinSpeed, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.LBFSpeed, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TBFSpeed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LBLoR, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBFoB, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.TBSSpeed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBSSpeed, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBSpinSpe, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TBSpinSpeed, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LBSpinDir, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.Connect, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.LBConnected, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.LBSonarRReading, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.LBSonarLReading, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.LBAutoSpeed, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.CBAutoMode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LBSonarL, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.LBSonar2, 2, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LableSpinSpeed
            // 
            this.LableSpinSpeed.AllowDrop = true;
            this.LableSpinSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LableSpinSpeed.AutoSize = true;
            this.LableSpinSpeed.Location = new System.Drawing.Point(193, 58);
            this.LableSpinSpeed.Name = "LableSpinSpeed";
            this.LableSpinSpeed.Size = new System.Drawing.Size(71, 13);
            this.LableSpinSpeed.TabIndex = 17;
            this.LableSpinSpeed.Text = "Spin Speed =";
            // 
            // LBForwardSpeed
            // 
            this.LBForwardSpeed.AllowDrop = true;
            this.LBForwardSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBForwardSpeed.AutoSize = true;
            this.LBForwardSpeed.Location = new System.Drawing.Point(191, 6);
            this.LBForwardSpeed.Name = "LBForwardSpeed";
            this.LBForwardSpeed.Size = new System.Drawing.Size(74, 13);
            this.LBForwardSpeed.TabIndex = 15;
            this.LBForwardSpeed.Text = "Front Speed =";
            this.LBForwardSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBSideSpeed
            // 
            this.LBSideSpeed.AllowDrop = true;
            this.LBSideSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSideSpeed.AutoSize = true;
            this.LBSideSpeed.Location = new System.Drawing.Point(193, 32);
            this.LBSideSpeed.Name = "LBSideSpeed";
            this.LBSideSpeed.Size = new System.Drawing.Size(71, 13);
            this.LBSideSpeed.TabIndex = 16;
            this.LBSideSpeed.Text = "Side Speed =";
            // 
            // LBForSpeed
            // 
            this.LBForSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBForSpeed.AutoSize = true;
            this.LBForSpeed.Location = new System.Drawing.Point(316, 6);
            this.LBForSpeed.Name = "LBForSpeed";
            this.LBForSpeed.Size = new System.Drawing.Size(25, 13);
            this.LBForSpeed.TabIndex = 21;
            this.LBForSpeed.Text = "127";
            // 
            // LBSiSpeed
            // 
            this.LBSiSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSiSpeed.AutoSize = true;
            this.LBSiSpeed.Location = new System.Drawing.Point(316, 32);
            this.LBSiSpeed.Name = "LBSiSpeed";
            this.LBSiSpeed.Size = new System.Drawing.Size(25, 13);
            this.LBSiSpeed.TabIndex = 22;
            this.LBSiSpeed.Text = "127";
            // 
            // LBSpinSpeed
            // 
            this.LBSpinSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSpinSpeed.AutoSize = true;
            this.LBSpinSpeed.Location = new System.Drawing.Point(316, 58);
            this.LBSpinSpeed.Name = "LBSpinSpeed";
            this.LBSpinSpeed.Size = new System.Drawing.Size(25, 13);
            this.LBSpinSpeed.TabIndex = 34;
            this.LBSpinSpeed.Text = "127";
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 3);
            this.flowLayoutPanel2.Controls.Add(this.TBController);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 114);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(282, 14);
            this.flowLayoutPanel2.TabIndex = 39;
            // 
            // TBController
            // 
            this.TBController.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TBController.Location = new System.Drawing.Point(0, 0);
            this.TBController.Margin = new System.Windows.Forms.Padding(0);
            this.TBController.Name = "TBController";
            this.TBController.ReadOnly = true;
            this.TBController.Size = new System.Drawing.Size(282, 20);
            this.TBController.TabIndex = 1;
            this.TBController.Text = "Click Here to Control    (WASD + QE)";
            this.TBController.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBController.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBController_KeyDown);
            this.TBController.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBController_KeyUp);
            // 
            // LBFSpeed
            // 
            this.LBFSpeed.AllowDrop = true;
            this.LBFSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBFSpeed.AutoSize = true;
            this.LBFSpeed.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LBFSpeed.Location = new System.Drawing.Point(11, 6);
            this.LBFSpeed.Name = "LBFSpeed";
            this.LBFSpeed.Size = new System.Drawing.Size(79, 13);
            this.LBFSpeed.TabIndex = 4;
            this.LBFSpeed.Text = "Forward Speed";
            this.LBFSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBFSpeed
            // 
            this.TBFSpeed.AllowDrop = true;
            this.TBFSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TBFSpeed.Location = new System.Drawing.Point(105, 3);
            this.TBFSpeed.Name = "TBFSpeed";
            this.TBFSpeed.Size = new System.Drawing.Size(61, 20);
            this.TBFSpeed.TabIndex = 2;
            this.TBFSpeed.Text = "127";
            this.TBFSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBFSpeed.TextChanged += new System.EventHandler(this.TBFSpeed_TextChanged);
            // 
            // LBLoR
            // 
            this.LBLoR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBLoR.AutoSize = true;
            this.LBLoR.Location = new System.Drawing.Point(416, 32);
            this.LBLoR.Name = "LBLoR";
            this.LBLoR.Size = new System.Drawing.Size(27, 13);
            this.LBLoR.TabIndex = 28;
            this.LBLoR.Text = "N/A";
            // 
            // LBFoB
            // 
            this.LBFoB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBFoB.AutoSize = true;
            this.LBFoB.Location = new System.Drawing.Point(416, 6);
            this.LBFoB.Name = "LBFoB";
            this.LBFoB.Size = new System.Drawing.Size(27, 13);
            this.LBFoB.TabIndex = 10;
            this.LBFoB.Text = "N/A";
            // 
            // TBSSpeed
            // 
            this.TBSSpeed.AllowDrop = true;
            this.TBSSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TBSSpeed.Location = new System.Drawing.Point(105, 29);
            this.TBSSpeed.Name = "TBSSpeed";
            this.TBSSpeed.Size = new System.Drawing.Size(61, 20);
            this.TBSSpeed.TabIndex = 3;
            this.TBSSpeed.Text = "127";
            this.TBSSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBSSpeed.TextChanged += new System.EventHandler(this.TBSSpeed_TextChanged);
            // 
            // LBSSpeed
            // 
            this.LBSSpeed.AllowDrop = true;
            this.LBSSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSSpeed.AutoSize = true;
            this.LBSSpeed.Location = new System.Drawing.Point(20, 32);
            this.LBSSpeed.Name = "LBSSpeed";
            this.LBSSpeed.Size = new System.Drawing.Size(62, 13);
            this.LBSSpeed.TabIndex = 5;
            this.LBSSpeed.Text = "Side Speed";
            // 
            // LBSpinSpe
            // 
            this.LBSpinSpe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSpinSpe.AutoSize = true;
            this.LBSpinSpe.Location = new System.Drawing.Point(20, 58);
            this.LBSpinSpe.Name = "LBSpinSpe";
            this.LBSpinSpe.Size = new System.Drawing.Size(62, 13);
            this.LBSpinSpe.TabIndex = 40;
            this.LBSpinSpe.Text = "Spin Speed";
            // 
            // TBSpinSpeed
            // 
            this.TBSpinSpeed.AllowDrop = true;
            this.TBSpinSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TBSpinSpeed.Location = new System.Drawing.Point(105, 55);
            this.TBSpinSpeed.Name = "TBSpinSpeed";
            this.TBSpinSpeed.Size = new System.Drawing.Size(61, 20);
            this.TBSpinSpeed.TabIndex = 41;
            this.TBSpinSpeed.Text = "127";
            this.TBSpinSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBSpinSpeed.TextChanged += new System.EventHandler(this.TBSpinSpeed_TextChanged);
            // 
            // LBSpinDir
            // 
            this.LBSpinDir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSpinDir.AutoSize = true;
            this.LBSpinDir.Location = new System.Drawing.Point(416, 58);
            this.LBSpinDir.Name = "LBSpinDir";
            this.LBSpinDir.Size = new System.Drawing.Size(27, 13);
            this.LBSpinDir.TabIndex = 42;
            this.LBSpinDir.Text = "N/A";
            // 
            // Connect
            // 
            this.Connect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Connect.Location = new System.Drawing.Point(291, 114);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 22);
            this.Connect.TabIndex = 30;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // LBConnected
            // 
            this.LBConnected.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBConnected.AutoSize = true;
            this.LBConnected.Location = new System.Drawing.Point(390, 119);
            this.LBConnected.Name = "LBConnected";
            this.LBConnected.Size = new System.Drawing.Size(79, 13);
            this.LBConnected.TabIndex = 31;
            this.LBConnected.Text = "Not Connected";
            // 
            // LBSonarRReading
            // 
            this.LBSonarRReading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSonarRReading.AutoSize = true;
            this.LBSonarRReading.Location = new System.Drawing.Point(416, 81);
            this.LBSonarRReading.Name = "LBSonarRReading";
            this.LBSonarRReading.Size = new System.Drawing.Size(27, 13);
            this.LBSonarRReading.TabIndex = 38;
            this.LBSonarRReading.Text = "N/A";
            // 
            // LBSonarLReading
            // 
            this.LBSonarLReading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSonarLReading.AutoSize = true;
            this.LBSonarLReading.Location = new System.Drawing.Point(416, 98);
            this.LBSonarLReading.Name = "LBSonarLReading";
            this.LBSonarLReading.Size = new System.Drawing.Size(27, 13);
            this.LBSonarLReading.TabIndex = 36;
            this.LBSonarLReading.Text = "N/A";
            // 
            // LBAutoSpeed
            // 
            this.LBAutoSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBAutoSpeed.AutoSize = true;
            this.LBAutoSpeed.Location = new System.Drawing.Point(3, 81);
            this.LBAutoSpeed.Name = "LBAutoSpeed";
            this.LBAutoSpeed.Size = new System.Drawing.Size(96, 13);
            this.LBAutoSpeed.TabIndex = 17;
            this.LBAutoSpeed.Text = "Autonomous Mode";
            // 
            // CBAutoMode
            // 
            this.CBAutoMode.AllowDrop = true;
            this.CBAutoMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CBAutoMode.AutoSize = true;
            this.CBAutoMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CBAutoMode.Location = new System.Drawing.Point(128, 81);
            this.CBAutoMode.Name = "CBAutoMode";
            this.CBAutoMode.Size = new System.Drawing.Size(15, 14);
            this.CBAutoMode.TabIndex = 1;
            this.CBAutoMode.UseVisualStyleBackColor = true;
            // 
            // LBSonarL
            // 
            this.LBSonarL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSonarL.AutoSize = true;
            this.LBSonarL.Location = new System.Drawing.Point(182, 81);
            this.LBSonarL.Name = "LBSonarL";
            this.LBSonarL.Size = new System.Drawing.Size(93, 13);
            this.LBSonarL.TabIndex = 35;
            this.LBSonarL.Text = "SonarL Reading =";
            // 
            // LBSonar2
            // 
            this.LBSonar2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBSonar2.AutoSize = true;
            this.LBSonar2.Location = new System.Drawing.Point(181, 98);
            this.LBSonar2.Name = "LBSonar2";
            this.LBSonar2.Size = new System.Drawing.Size(95, 13);
            this.LBSonar2.TabIndex = 37;
            this.LBSonar2.Text = "SonarR Reading =";
            // 
            // TxTimer
            // 
            this.TxTimer.Tick += new System.EventHandler(this.TxTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 140);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Wireless Robot Controller";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TBSSpeed;
        private System.Windows.Forms.Label LBSSpeed;
        private System.Windows.Forms.TextBox TBFSpeed;
        private System.Windows.Forms.Label LBFSpeed;
        private System.Windows.Forms.CheckBox CBAutoMode;
        private System.Windows.Forms.Label LBFoB;
        private System.Windows.Forms.Label LBSiSpeed;
        private System.Windows.Forms.Label LBSideSpeed;
        private System.Windows.Forms.Label LBAutoSpeed;
        private System.Windows.Forms.Label LBForSpeed;
        public System.Windows.Forms.Label LBForwardSpeed;
        private System.Windows.Forms.Label LBLoR;
        private System.IO.Ports.SerialPort Arduino;
        private System.Windows.Forms.Timer TxTimer;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label LBConnected;
        private System.Windows.Forms.Label LableSpinSpeed;
        private System.Windows.Forms.Label LBSpinSpeed;
        private System.Windows.Forms.Label LBSonarL;
        private System.Windows.Forms.Label LBSonarLReading;
        private System.Windows.Forms.Label LBSonar2;
        private System.Windows.Forms.Label LBSonarRReading;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox TBController;
        private System.Windows.Forms.Label LBSpinSpe;
        private System.Windows.Forms.TextBox TBSpinSpeed;
        private System.Windows.Forms.Label LBSpinDir;
    }
}

