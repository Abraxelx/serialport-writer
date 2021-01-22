using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Port
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cmbPorts.Items.AddRange(ports);
            cmbPorts.SelectedIndex = 0;
            btnClose.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClose.Enabled = true;

            try
            {
                serialPort1.PortName = cmbPorts.Text;
                serialPort1.Open();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                if(serialPort1.IsOpen)
                {
                    while (true)
                    {
                        serialPort1.WriteLine("Try IT!");
                        Thread.Sleep(200);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;

            try
            {
                serialPort1.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }
    }
}
