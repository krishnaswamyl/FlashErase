using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace FlashErase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //show list of valid com ports
            
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
            comboBox1.Select();
            comboBox1.Update();
            serialPort1 = new SerialPort();
            buttonErase.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                serialPort1.RtsEnable = true;
            }
            else
            {
                serialPort1.RtsEnable = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool temp;
            if (checkBox2.Checked)
            {
                serialPort1.DtrEnable = true;
            }
            else
            {
                serialPort1.DtrEnable = false;
            }

            temp = serialPort1.DtrEnable;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if(buttonConnect.Text == "CONNECT")
            {
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                serialPort1.BaudRate = 115200;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.Handshake = Handshake.None;
                serialPort1.NewLine = "\r\n";
                serialPort1.WriteTimeout = 1000;
                serialPort1.ReadTimeout = 3000;
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show("Serial Port alread open");
                    return;
                }
                serialPort1.Open();
                buttonConnect.Text = "DISCONNECT";
                buttonConnect.BackColor = Color.Pink;

            }else
            {
                serialPort1.Dispose();
                serialPort1.Close();
                buttonConnect.Text = "CONNECT";
                buttonConnect.BackColor = Color.LimeGreen;
            }
            

        }
        private string readComPort()
        {
            string res = "NULL";
            try
            {
                res = serialPort1.ReadExisting();      //read response.
            }
            catch (TimeoutException e)
            {
                MessageBox.Show(e.ToString());
                
                return "TimeOut";
            }
            return res;
        }

        private void eraseLPC1857()
        {
            string response = "";
            int delay = 100;
            serialPort1.DiscardInBuffer();           
            Thread.Sleep(delay);
            serialPort1.Write("?");                 //Send "?" to Target.
            
            response = readComPort();
            if(response.Contains("TimeOut"))
            {
                MessageBox.Show("Please check wiring and Target connections.");
            }
            else
            {
                if(response.Contains("Synchronized"))
                {
                    richTextBox1.AppendText("Synchronized\r\n");
                }
            }
            Thread.Sleep(delay);
            serialPort1.Write("Synchronized\r\n");                 //Send "Synchronized\r\n" to Target.
            response = readComPort();
            if (response.Contains("TimeOut"))
            {
                MessageBox.Show("Please check wiring and Target connections.");
            }
            else
            {
                if (response.Contains("OK"))
                {
                    richTextBox1.AppendText("OK\r\n");
                }
            }
            Thread.Sleep(delay);
            serialPort1.Write("0\r\n");                 //Send "0\r\n" to Target.
            response = readComPort();
            if (response.Contains("TimeOut"))
            {
                MessageBox.Show("Please check wiring and Target connections.");
            }
            else
            {
                if (response.Contains("OK"))
                {
                    richTextBox1.AppendText("OK Target ready\r\n");
                    buttonErase.Enabled = true;
                }
            }
            Thread.Sleep(delay);
            



        }

        private void eraseLPC1768()
        {
            string treads = "";
            serialPort1.DiscardInBuffer();
            richTextBox1.Clear();
            serialPort1.Write("?");
            treads = serialPort1.ReadLine();
            richTextBox1.Text = treads;
            if (treads.Equals("Synchronized"))
            {
                serialPort1.Write("Synchronized\r");
            }
            treads = "RESPONSE: " + serialPort1.ReadLine() + "\n";
            richTextBox1.AppendText(treads);
            if (treads.Contains("OK"))
            {
                serialPort1.Write("12000\r");
            }
            treads = "RESPONSE: " + serialPort1.ReadLine() + "\n";
            richTextBox1.AppendText(treads);
            if (treads.Contains("OK"))
            {
                serialPort1.Write("B 115200 1\r");
            }
            treads = "RESPONSE: " + serialPort1.ReadLine() + "\n";
            richTextBox1.AppendText(treads);
            if (treads.Contains("0"))
            {
                serialPort1.Write("U 23130\r");

            }
            treads = "RESPONSE: " + serialPort1.ReadLine() + "\n";
            richTextBox1.AppendText(treads);
            if (treads.Contains("0"))
            {
                serialPort1.Write("P 0 29\r");

            }
            treads = "RESPONSE: " + serialPort1.ReadLine() + "\n";
            richTextBox1.AppendText(treads);
            if (treads.Contains("0"))
            {
                serialPort1.Write("E 0 29\r");

            }
            treads = "RESPONSE: " + serialPort1.ReadLine() + "\n";
            richTextBox1.AppendText(treads);
            
        }

        private void buttonSendSync_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Update();
            richTextBox1.Text = "Please Wait\r\n";
            serialPort1.DtrEnable = true;   //Make DTR Signal High. Make RESET pin LOW.
            serialPort1.RtsEnable = true;   //Make RTS Signal High. Make Pin ISP LOW.
            Thread.Sleep(500);
            serialPort1.DtrEnable = false;   //Make DTR Signal Low. Make RESET pin HIGH.
            Thread.Sleep(600);
            serialPort1.RtsEnable = false;   //Make RTS Signal Low. Make Pin ISP HIGH.
            
            if (serialPort1.IsOpen)
            {
                if (checkBoxLPC1857.Checked)
                {
                    eraseLPC1857();

                }
                else
                    if(checkBoxLPC1768.Checked)
                {
                    eraseLPC1768();
                }
          
                
            }
            else
            {
                MessageBox.Show("Please connect to Comport and try again...");
            }
           
        }

        private void buttonEraseClicked(object sender, EventArgs e)
        {
            string response = "";
            buttonErase.BackColor = Color.OrangeRed;
            int delay = 250;
            if(checkBoxLPC1857.Checked)
            {
                serialPort1.Write("B 115200 1\r");      //Send ISP to set Baud rate.
                response = readComPort();
                if (response.Contains("TimeOut"))
                {
                    MessageBox.Show("Please check wiring and Target connections.");
                }
                else
                {
                    if (response.Contains("0"))
                    {
                        richTextBox1.AppendText("Baud Rate Set Success\r\n");
                    }
                }
                Thread.Sleep(delay);
                serialPort1.Write("U 23130\r");     //send ISP to Unlock Flash.
                response = readComPort();
                if (response.Contains("TimeOut"))
                {
                    MessageBox.Show("Please check wiring and Target connections.");
                }
                else
                {
                    if (response.Contains("0"))
                    {
                        richTextBox1.AppendText("Unlock Flash success\r\n");
                    }
                }
                Thread.Sleep(delay);
                serialPort1.Write("P 0 14 0\r");      //send ISP to Prepare flash for Erase Bank A.
                response = readComPort();
                if (response.Contains("TimeOut"))
                {
                    MessageBox.Show("Please check wiring and Target connections.");
                }
                else
                {
                    if (response.Contains("0"))
                    {
                        richTextBox1.AppendText("Prepare flash for Erase A Success\r\n");
                    }
                }
                Thread.Sleep(delay);
                serialPort1.Write("P 0 14 1\r");      //send ISP to Prepare flash for Erase Bank B.
                response = readComPort();
                if (response.Contains("TimeOut"))
                {
                    MessageBox.Show("Please check wiring and Target connections.");
                }
                else
                {
                    if (response.Contains("0"))
                    {
                        richTextBox1.AppendText("Prepare flash for Erase B Success\r\n");
                    }
                }
                Thread.Sleep(delay);
                serialPort1.Write("E 0 14 0\r");      //send ISP to Erase flash Bank A.
                response = readComPort();
                if (response.Contains("TimeOut"))
                {
                    MessageBox.Show("Please check wiring and Target connections.");
                }
                else
                {
                    if (response.Contains("0"))
                    {
                        richTextBox1.AppendText("Erase A Success\r\n");
                    }
                }
                Thread.Sleep(delay);
                serialPort1.Write("E 0 14 1\r");      //send ISP to Erase flash Bank B.
                response = readComPort();
                if (response.Contains("TimeOut"))
                {
                    MessageBox.Show("Please check wiring and Target connections.");
                }
                else
                {
                    if (response.Contains("0"))
                    {
                        richTextBox1.AppendText("Erase B Success\r\n");
                    }
                }
               // serialPort1.RtsEnable = true;   //Make RTS Signal High. Make Pin ISP LOW.
                //Thread.Sleep(250);               
               // serialPort1.RtsEnable = false;   //Make RTS Signal Low. Make Pin ISP HIGH.
                buttonErase.BackColor = Color.LimeGreen;

            }
        }
    }
}
