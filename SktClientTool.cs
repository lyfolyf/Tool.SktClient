using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.Tool.Interface;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.Drawing;
using System.IO;
using Lead.Tool.XML;
using Lead.Tool.Log;

namespace Lead.Tool.SktClient
{
    public delegate void MesRecved(string mes);
    public class SktClientTool : ITool
    {
        public Config _Config;
        public string _path = "";
        public event MesRecved MesEvent = null;

        private ConfigUI _configUI ;
        private DebugUI _debugUI;
        private IToolState _State = IToolState.ToolMin;

        private Socket _socket = null;
        private IPAddress _ip;
        private IPEndPoint _port;

        private Task _sendTask = null;
        private Task _revTask = null;
        private Task _heartTask = null;

        private Queue<object> _sendQueue = null;
        private object _sendQueueMutex = new object();
        private bool _sendFlag = false;

        private object _revQueueMutex = new object();
        private bool _revFlag = false;

        private int SendQueueCnt = 1024;
        private bool IsConnected = false;
        private bool IsHeart = false;

        private SktClientTool()
        {

        }

        public  SktClientTool(string Name, string path)
        {
            _path = path;
            if (File.Exists(path))
            {
                _Config = (Config)XmlSerializerHelper.ReadXML(path, typeof(Config));
            }
            else
            {
                _Config = new Config();
            }
            _configUI = new ConfigUI(this);
            _debugUI = new DebugUI(this);
        }

        #region Common
        public IToolState State
        {
            get { return _State; }    
        }

        public Control ConfigUI
        {
            get
            {
                return _configUI;
            }
        }

        public Control DebugUI
        {
            get
            {
                return _debugUI;
            }
        }

        public void Init()
        {
            if (IsConnected == true)
            {
                MessageBox.Show("已连接");
            }

            _ip = IPAddress.Parse(_Config.IP);

            _port = new IPEndPoint(_ip, int.Parse(_Config.Port));

            if (SendQueueCnt <= 0)
            {
                _sendQueue = new Queue<object>();
            }
            else
            {
                _sendQueue = new Queue<object>(SendQueueCnt);
            }


            if (_socket == null)
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

            _State = IToolState.ToolInit;
        }

        public void Start()
        {
            while (true)
            {
                int reconnectCnt = 0;
                try
                {
                    _socket.Connect(_port);

                    break;
                }
                catch(Exception ex)
                {
                    Logger.Warn(ex.Message);
                    reconnectCnt++;
                    if (reconnectCnt >= 3)
                    {
                        return;
                    }
                }
            }

            if (_sendTask == null)
            {
                _sendTask = new Task(() => this.CycleSend());
                _sendFlag = true;
                _sendTask.Start();
            }

            if (_revTask == null)
            {
                _revTask = new Task(() => this.CycleRev());
                _revFlag = true;
                _revTask.Start();
            }

            if (_heartTask == null)
            {
                IsHeart = true;
                _heartTask = new Task(() => this.CycleHeart());
                _heartTask.Start();
            }
            IsConnected = true;
            _State = IToolState.ToolRunning;
        }

        public void Terminate()
        {
            IsHeart = false;
            Thread.Sleep(50);
            //_socket.Disconnect(true);
            _socket.Close();
            //_socket.Dispose();
            _revTask.Wait();
            _heartTask.Wait();
            _socket = null;
            IsConnected = false;
            _State = IToolState.ToolTerminate;
            return;
        }
        #endregion

        public int SendInfo(string rev, object context)
        {
            int iRet = 0;

            lock (_sendQueueMutex)
            {
                _sendQueue.Enqueue(context);
            }

            return iRet;
        }

        #region Task

        private void CycleSend()
        {
            while (true)
            {
                if (!IsConnected)
                {
                    try
                    {
                        _socket.Connect(_port);
                        IsConnected = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Warn(ex.Message);
                        IsConnected = false; ;
                        Thread.Sleep(100);
                        continue;
                    }
                }

                if (!_sendFlag) { Thread.Sleep(2); continue; }


                if (_sendQueue.Count < 1) { Thread.Sleep(2); continue; }

                object sendObj = null;

                lock (_sendQueueMutex)
                {
                    sendObj = _sendQueue.Dequeue();
                }

                if (sendObj == null) { Thread.Sleep(2); continue; }

                string sendStr = (string)sendObj;

                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(sendStr);
                    if (buffer.Length > 0)
                    {
                        _socket.Send(buffer);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex.Message);
                    IsConnected = false; ;
                }

                Thread.Sleep(2);
            }
        }

        private void CycleRev()
        {
            while (true)
            {
                if (!_revFlag) { Thread.Sleep(2); continue; }

                try
                {
                    byte[] buffer = new byte[1024];

                    int n = _socket.Receive(buffer);

                    string revMsg = Encoding.UTF8.GetString(buffer, 0, n);

                    if (MesEvent != null)
                    {
                        MesEvent(revMsg);

                    }

                }
                catch (Exception ex)
                {
                    Logger.Warn(ex.Message);
                    throw ex;
                }
                Thread.Sleep(2);
            }
        }

        private void CycleHeart()
        {
            while (IsHeart)
            {
                if (_Config.Heart > 30)
                {
                    Thread.Sleep(_Config.Heart);
                    lock (_sendQueueMutex)
                    {
                        _sendQueue.Enqueue("Heart");
                    }
                }
            }
        }

        #endregion

    }
}
