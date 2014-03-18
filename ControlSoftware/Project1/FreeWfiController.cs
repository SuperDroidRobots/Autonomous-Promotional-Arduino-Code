using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Boolean BackwardFlag = false;
        Boolean LeftFlag = false;
        Boolean AutoMode = false;
        int SpeedF = 0;
        int SpeedS = 0;
        int AutoSpeed = 0;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Stop_Click(object sender, EventArgs e)
        {

            AutoModeCheck.Checked = false;
            FSpeedBox.Text = "127";
            AutoSpeedBox.Text = "90";
            SSpeedBox.Text = "127";
            AS.Text = Convert.ToString("N/A");
            SS.Text = Convert.ToString("0");
            FS.Text = Convert.ToString("0");

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.W)//w
            {

                try
                {
                    SpeedF = Convert.ToInt32(FSpeedBox.Text);
                    FSpeedBox.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    FSpeedBox.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    
                    FSpeedBox.ForeColor = Color.Red;
                    return;
                }
                FoB.Text = "Forward";
                FS.Text = Convert.ToString(127 + SpeedF);
                BackwardFlag = false;
                
            }
            if (e.KeyData == Keys.A)//a
            {
                try
                {
                    SpeedS = Convert.ToInt32(SSpeedBox.Text);
                    SSpeedBox.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    SSpeedBox.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    SSpeedBox.ForeColor = Color.Red;
                    return;
                }
                LoR.Text = "Left";
                SS.Text = Convert.ToString(127 + SpeedS);
                LeftFlag = true;
                
            }
            if (e.KeyData == Keys.S)//s
            {
                try
                {
                    SpeedF = Convert.ToInt32(FSpeedBox.Text);
                    FSpeedBox.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    FSpeedBox.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    FSpeedBox.ForeColor = Color.Red;
                    return;
                }
                FoB.Text = "Backward";
                FS.Text = Convert.ToString(127 + SpeedF);
                BackwardFlag = true;

            }
            if (e.KeyData == Keys.D)//d
            {
                try
                {
                    SpeedS = Convert.ToInt32(SSpeedBox.Text);
                    FSpeedBox.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    SSpeedBox.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    SSpeedBox.ForeColor = Color.Red;
                    return;
                }
                LoR.Text = "Right";
                SS.Text = Convert.ToString(127 + SpeedS);
                LeftFlag = false;
               
            }




            if (e.KeyData == Keys.Q)//q
            {
                ;
            }
            if (e.KeyData == Keys.E)//e
            {
                ;
            }


        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            AutoModeCheck.Checked = false;
            AS.Text = Convert.ToString("0");
            SS.Text = Convert.ToString("0");
            FS.Text = Convert.ToString("0");
            FoB.Text = "N/A";
            LoR.Text = "N/A"; 

        }

        private void AutoModeCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            AutoMode = !AutoMode;
            if (AutoMode == true)
                AS.Text = AutoSpeedBox.Text;
            else
                AS.Text = "N/A";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



 
    }
}
