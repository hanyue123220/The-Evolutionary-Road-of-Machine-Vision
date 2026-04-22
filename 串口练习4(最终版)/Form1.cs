using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口练习4_最终版_
{
    public partial class Form1 : Form
    {
        Helper helper = new Helper();
        public Form1()
        {
            InitializeComponent();
        }
        public void UpdateUI(Action action)
        {
            if (InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            comboBox2.Items.AddRange(new object[] { 9600, 19200, 38400, 115200 });
            comboBox3.Items.AddRange(new object[] { "None", "Odd", "Even" });
            comboBox4.Items.AddRange(new object[] { 8, 5, 1 });
            comboBox5.Items.AddRange(new object[] { "One", "Two" });
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            helper.ReceiveMsgInfo += Helper_ReceiveMsgInfo;
            helper.StatusINfo += Helper_StatusINfo;
            helper.Info += Helper_Info;
        }

        private void Helper_Info(string obj)
        {
            UpdateUI(() => label1.Text = obj);
        }

        private void Helper_StatusINfo(bool obj)
        {
            comboBox1.Enabled = obj;
            comboBox2.Enabled = obj;
            comboBox3.Enabled = obj;
            comboBox4.Enabled = obj;
            comboBox5.Enabled = obj;
        }

        private void Helper_ReceiveMsgInfo(string obj)
        {
            UpdateUI(()=>textBox1.AppendText(obj));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!helper.isOPen)
            {
                string portName = comboBox1.Text;
                int baud = int.Parse(comboBox2.Text);
                string parityStr = comboBox3.Text;
                int dataBits = int.Parse(comboBox4.Text);
                string stopBitStr = comboBox5.Text;
                // 2. 转成串口需要的枚举类型
                Parity parity = (Parity)Enum.Parse(typeof(Parity), parityStr);
                StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBitStr);
                // 3. 正确传参
                helper.Open(portName, baud, parity, dataBits, stopBits, "\n");

            }
            else
            {
                helper.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            helper.Send(textBox2.Text.Trim()+"\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string content = textBox2.Text.Trim() + "\n"; // 加 \n 结尾
            helper.StartAutoSend(content, 1000); // 1000毫秒 = 1秒
        }

        private void button4_Click(object sender, EventArgs e)
        {
            helper.StopAutoSend();
        }
    }
}
