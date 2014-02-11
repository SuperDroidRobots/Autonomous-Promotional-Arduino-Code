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
        int SpeedR = 0;
        int AutoSpeed = 0;

        void Form1()
        {
            InitializeComponent();
        }

        
        void Form1_KeyPress(object sneder, KeyPressEventArgs e)
        {
            if (e.KeyChar == 119)//w
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

                    LS.Text = Convert.ToString(127+SpeedF);
                    BackwardFlag=false;
                    BackwardCB.Checked=false;
            }  
            if (e.KeyChar == 97)//a
            {
                try
                {
                    SpeedR = Convert.ToInt32(FSpeedBox.Text);
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

                    LS.Text = Convert.ToString(127-SpeedF);
                    BackwardFlag=true;
                    BackwardCB.Checked=true;
            } 
            if (e.KeyChar == 115)//s
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

                    LS.Text = Convert.ToString(127-SpeedF);
                    BackwardFlag=true;
                    BackwardCB.Checked=true;

            }
            if (e.KeyChar == 100)//d
            {
                try
                {
                    SpeedR = Convert.ToInt32(FSpeedBox.Text);
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

                    LS.Text = Convert.ToString(127+SpeedF);
                    BackwardFlag=false;
                    BackwardCB.Checked=false;
            }




                if (e.KeyChar== 113)//q
                {
;
                }
                if (e.KeyChar == 101)//e
                {
;
                }
            
        }

        private void BackwardCB_CheckedChanged(object sender, EventArgs e)
        {
            BackwardFlag = !BackwardFlag;
        }
        private void LeftCB_CheckedChanged(object sender, EventArgs e)
        {
            LeftFlag = !LeftFlag;
        }
        private void AutoModeCheck_CheckedChanged(object sender, EventArgs e)
        {
            AutoMode = !AutoMode;
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            BackwardCB.Checked = false;
            LeftCB.Checked = false;
            AutoModeCheck.Checked = false;
            FSpeedBox.Text = "0";
            AutoSpeedBox.Text = "0";
            SSpeedBox.Text = "0";
            AS.Text = Convert.ToString("0");
            RS.Text = Convert.ToString("0");
            LS.Text = Convert.ToString("0");
            AMCheck.Text = "No";
            RRCheck.Text = "No";
            RLCheck.Text = "No";
        }
    
    }
}
