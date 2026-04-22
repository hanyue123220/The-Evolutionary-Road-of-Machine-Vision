using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口练习4_最终版_
{
    /*串口配置	串口号下拉（自动刷新）、波特率、数据位、停止位、校验位全部可选
连接管理	打开/关闭按钮，状态栏实时显示连接状态和已接收字节数
数据接收	接收区显示数据，支持文本和HEX两种显示格式，可以清空
数据发送	发送框输入文本，支持发送\n结尾，支持循环发送（每隔N毫秒自动发）
快捷指令	可以保存3-5条常用指令，点按钮一键发送（比如 START\n、STOP\n）
日志记录	所有收发记录带时间戳显示，可以保存到txt文件
*/
    internal class Helper
    {
        public SerialPort _port;//串口
        public readonly object _lock = new object();//锁
        public string _buffer;//缓冲区
        public event Action<string> Info;//显示连接状态
        public event Action<bool> StatusINfo;//根据连接用于控制组件
        public event Action<string> ReceiveMsgInfo;//用于显示收到的信息
        public bool isOPen = false;
        public string _end;
        private Timer _sendTimer = new Timer();
        private string _autoSendMsg = "";

        // 构造函数 + 绑定定时器
        public Helper()
        {
            _sendTimer.Tick += _sendTimer_Tick;
        }
        private void _sendTimer_Tick(object sender, EventArgs e)
        {
            Send(_autoSendMsg);
        }
        public void StartAutoSend(string msg, int ms)
        {
            if (!isOPen)
            {
                Info?.Invoke("请先打开串口！");
                return;
            }

            _autoSendMsg = msg;
            _sendTimer.Interval = ms;
            _sendTimer.Start();
            Info?.Invoke($"已开启自动发送，{ms}ms 一次");
        }

        // 停止自动发送
        public void StopAutoSend()
        {
            _sendTimer.Stop();
            Info?.Invoke("自动发送已停止");
        }
        public bool Open(string name,int baudnum, Parity parity ,int databits,StopBits endnub,string end)
        {
             _end=end;
            if (_port != null &&_port.IsOpen)
            {
                Close();
            }
            try
            {
                _port = new SerialPort(name, baudnum, parity, databits, endnub)
                {

                    ReadTimeout = 500,
                    WriteTimeout = 500,
                    Encoding = Encoding.UTF8
                };
                _port.Open();
                isOPen = true;
                _port.DataReceived += _port_DataReceived;
                StatusINfo?.Invoke(false);
                Info?.Invoke($"串口号:{name},波特率:{baudnum},奇数偶数校验位:{parity},数据位数:{databits},停止位数:{endnub}");
                return true;
            }
            catch (Exception ex)
            {
                Info?.Invoke(ex.Message);
                return false;
              
            }


        }
     public   void Send(string msg)
        {
            _port.Write(msg);
        }
        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = _port.ReadExisting();
            lock (_lock)
            {
                _buffer += data;
                while (_buffer.Contains(_end))
                {
                    int index = _buffer.IndexOf(_end);
                    string message = _buffer.Substring(0, index);
                    _buffer = _buffer.Substring(index + _end.Length);
                    DealData(message);
                } 
            }
        }
        void DealData(string msg)
        {
            ReceiveMsgInfo?.Invoke($"时间:{DateTime.Now.ToString("HH.mm.ss.fff")} 收到的信息:{msg}");
        }
        public void Close()
        {
            isOPen = false;
            lock (_lock)
            {
                _buffer = "";
            }
            try
            {
                _port.DataReceived -= _port_DataReceived;
                _port.Close();
                _port.Dispose();
                StatusINfo?.Invoke(true);
                StopAutoSend();
                Info?.Invoke("断开连接");

            }
            catch 
            {

            }
        }

    }
}
