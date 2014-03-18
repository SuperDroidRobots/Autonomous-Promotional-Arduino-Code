using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Boolean Connected = false;
        int SpeedF = 0;
        int SpeedS = 0;
        int SpeedSp = 0;
        Socket senderSock;
        String S_ArduinoIP = "192.168.10.240";
        int timeout = 0;
        List<byte> Buffer = new List<byte>();



        public Form1()
        {
            InitializeComponent();
        }




        private void TxTimer_Tick(object sender, EventArgs e)
        {
            //Send Serial information
            timeout = timeout + 1;
            if (timeout > 30)
            {
                TxTimer.Stop();
                LBConnected.Text = "Disconnected";
                timeout = 0;
            }
            try
            {
                byte Auto = 0x00;
                if (CBAutoMode.Checked == true)
                {
                    Auto = 0x01;

                }
                else
                {
                    Auto = 0x00;
                }

                byte[] Sendbytes = new Byte[8] 
                { 0x53, 0x44, 0x52, //S,D,R
                (byte)Convert.ToInt32(LBForSpeed.Text), 
                (byte)Convert.ToInt32(LBSiSpeed.Text),
                (byte)Convert.ToInt32(LBSpinSpeed.Text), 
                Auto,
                0x00};

                Sendbytes[7] = (byte)(Sendbytes[6] + Sendbytes[5] + Sendbytes[4] + Sendbytes[3]);

                senderSock.Send(Sendbytes);


            }
            catch (Exception)
            {

            }

        }
        private void Connect_Click(object sender, EventArgs e)
        {

            //Opens the Host on the Local Computer (Will be changed to Arduio
            // Incoming data from the client.
            ///Trys to Open a connection to a Socket Openned on the Local Computer
            ///will change to Arduino

            try
            {

                // Gets first IP address associated with a localhost  
                IPAddress ipAddr = IPAddress.Parse(S_ArduinoIP);

                // Creates a network endpoint  
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 5050);

                // Create one Socket object to setup Tcp connection  
                senderSock = new Socket(
                    AddressFamily.InterNetwork,// Specifies the addressing scheme  
                    SocketType.Stream,   // The type of socket   
                    ProtocolType.Tcp     // Specifies the protocols   
                    );

                senderSock.NoDelay = false;   // Not using the Nagle algorithm  

                // Establishes a connection to a remote host  
                senderSock.Connect(ipEndPoint);
                StateObject state = new StateObject();
                state.workSocket = senderSock;
                senderSock.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

                LBConnected.Text = "Connected";

                TxTimer.Start();
                Connected = true;
            }
            catch (Exception eg)
            {
                LBConnected.Text = "Error In Connection";
            }

        }

        private void ReceiveCallback(IAsyncResult res)
        {
            try
            {
                StateObject state = (StateObject)res.AsyncState;
                Socket socket = state.workSocket;
                int numOfBytes = socket.EndReceive(res);
                byte[] temp = new byte[numOfBytes];

                senderSock.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                Array.Copy(state.Buffer, 0, temp, 0, numOfBytes);

                processBytes(temp);

            }

            catch (Exception en)
            {

            }
        }

        private void processBytes(byte[] bytes)
        {

            Buffer.AddRange(bytes);

            int begin = StringLocation(Buffer, "SDR1");

            while (begin != -1 && Buffer.Count - begin > 8)
            {

                SetText(LBSonarRReading, bytes[begin + 5].ToString());
                SetText(LBSonarLReading, bytes[begin + 6].ToString());
              //  SetText(LBSpinSpeed, bytes[begin + 7].ToString());

                Buffer.RemoveRange(0, begin + 8);

                begin = StringLocation(Buffer, "SDR1");

                timeout = 0;
            }
        }

        private int StringLocation(List<byte> data, string input)
        {
            int inputSize = input.Length;
            int dataSize = data.Count;
            int compare = dataSize - inputSize + 1;

            char[] inputChar = input.ToCharArray();

            if (dataSize < inputSize)
            {
                return -1;
            }

            for (int i = 0; i < compare; i++)
            {
                for (int j = 0; j < inputSize; j++)
                {
                    if (data[i + j] != inputChar[j])
                    {
                        break;
                    }

                    if (j + 1 == inputSize)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private static void SetText(TextBox box, string text)
        {
            if (box.InvokeRequired) // am i ui thread
                box.BeginInvoke(new Action(() => SetText(box, text)));
            else
                box.Text = text;
        }

        private static void SetText(Label box, string text)
        {
            if (box.InvokeRequired) // am i ui thread
                box.BeginInvoke(new Action(() => SetText(box, text)));
            else
                box.Text = text;
        }

        private void TBController_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.W)//w
            {

                try
                {
                    SpeedF = Convert.ToInt32(TBFSpeed.Text);
                    TBFSpeed.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    TBFSpeed.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {

                    TBFSpeed.ForeColor = Color.Red;
                    return;
                }
                if (SpeedF > 0 && SpeedF < 128)
                {
                    LBFoB.Text = "Forward";
                    LBForSpeed.Text = Convert.ToString(127 + SpeedF);
                }
                else
                    TBFSpeed.ForeColor = Color.Red;

            }
            if (e.KeyData == Keys.A)//a
            {
                try
                {
                    SpeedS = Convert.ToInt32(TBSSpeed.Text);
                    TBSSpeed.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    TBSSpeed.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    TBSSpeed.ForeColor = Color.Red;
                    return;
                }

                if (SpeedS > 0 && SpeedS < 128)
                {
                    LBLoR.Text = "Left";
                    LBSiSpeed.Text = Convert.ToString(127 - SpeedS);
                }
                else
                    TBSSpeed.ForeColor = Color.Red; ;


            }
            if (e.KeyData == Keys.S)//s
            {
                try
                {
                    SpeedF = Convert.ToInt32(TBFSpeed.Text);
                    TBFSpeed.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    TBFSpeed.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    TBFSpeed.ForeColor = Color.Red;
                    return;
                }

                if (SpeedF > 0 && SpeedF < 128)
                {
                    LBFoB.Text = "Backward";
                    LBForSpeed.Text = Convert.ToString(127 - SpeedF); ;
                }
                else
                    TBFSpeed.ForeColor = Color.Red;


            }
            if (e.KeyData == Keys.D)//d
            {
                try
                {
                    SpeedS = Convert.ToInt32(TBSSpeed.Text);
                    TBSSpeed.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    TBSSpeed.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    TBSSpeed.ForeColor = Color.Red;
                    return;
                }

                if (SpeedS > 0 && SpeedS < 128)
                {
                    LBLoR.Text = "Right";
                    LBSiSpeed.Text = Convert.ToString(127 + SpeedS);
                }
                else
                    TBSSpeed.ForeColor = Color.Red;
            }
            if (e.KeyData == Keys.E)//e
            {
                try
                {
                    SpeedSp = Convert.ToInt32(TBSpinSpeed.Text);
                    TBSpinSpeed.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    TBSpinSpeed.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    TBSpinSpeed.ForeColor = Color.Red;
                    return;
                }

                if (SpeedSp > 0 && SpeedSp < 128)
                {
                    LBSpinDir.Text = "CounterClockwise";
                    LBSpinSpeed.Text = Convert.ToString(127 - SpeedSp);
                }
                else
                    TBSpinSpeed.ForeColor = Color.Red;


            }
            if (e.KeyData == Keys.Q)//q
            {
                try
                {
                    SpeedSp = Convert.ToInt32(TBSpinSpeed.Text);
                    TBSpinSpeed.ForeColor = Color.Black;
                }
                catch (FormatException ex)
                {
                    TBSpinSpeed.ForeColor = Color.Red;
                    return;
                }
                catch (OverflowException ex)
                {
                    TBSpinSpeed.ForeColor = Color.Red;
                    return;
                }
                if (SpeedSp > 0 && SpeedSp < 128)
                {
                    LBSpinDir.Text = "Clockwise";
                    LBSpinSpeed.Text = Convert.ToString(127 + SpeedSp);
                }
                else
                    TBSpinSpeed.ForeColor = Color.Red;

            }

        }

        private void TBController_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)//w
            {
                LBFoB.Text = "N/A";
                LBForSpeed.Text = Convert.ToString("127");
            }
            if (e.KeyData == Keys.A)//a
            {
                LBSiSpeed.Text = Convert.ToString("127");
                LBLoR.Text = "N/A";
            }
            if (e.KeyData == Keys.S)//s
            {
                LBForSpeed.Text = Convert.ToString("127");
                LBFoB.Text = "N/A";
            }
            if (e.KeyData == Keys.D)//d
            {
                LBSiSpeed.Text = Convert.ToString("127");
                LBLoR.Text = "N/A";
            }
            if (e.KeyData == Keys.E)//e
            {
                LBSpinDir.Text = "N/A";
                LBSpinSpeed.Text = Convert.ToString("127");
            }
            if (e.KeyData == Keys.Q)//q
            {
                LBSpinDir.Text = "N/A";
                LBSpinSpeed.Text = Convert.ToString("127");
            }
            CBAutoMode.Checked = false;


        }

        private void TBFSpeed_TextChanged(object sender, EventArgs e)
        {
            TBFSpeed.ForeColor = Color.Black;
        }

        private void TBSSpeed_TextChanged(object sender, EventArgs e)
        {
            TBSSpeed.ForeColor = Color.Black;
        }

        private void TBSpinSpeed_TextChanged(object sender, EventArgs e)
        {
            TBSpinSpeed.ForeColor = Color.Black;
        }


    }

    public class StateObject
    {
        public Socket workSocket;
        public const int BufferSize = 512;
        public byte[] Buffer = new Byte[BufferSize];
        public StringBuilder sb = new StringBuilder();

    }

}

