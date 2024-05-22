using Com0Com.CSharp;
using EASkins;
using EASkins.Controls;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace YuDa.DeviceClient
{
    public partial class Main : MaterialForm
    {
        private static ILog log = LogManager.GetLogger(typeof(Main));

        private static Com0ComSetupCFacade SetupCFacade = new Com0ComSetupCFacade(Application.StartupPath + "\\Com0Com\\setupc.exe");
        private static CrossoverPortPair PortPair = null;
        private int Com0ComStartPort = 25;

        public static byte[] data = new byte[1024];
        bool TcpConnectFlag = false;
        bool NetworkSpeedFlag = false;

        //发送和接收的字节数
        int Send = 0;
        int Receive = 0;

        //定义SerialPort类实例 串口
        SerialPort SpCom = new SerialPort();
        //NetworkStream networkStream;

        TcpServicePortReceive TcpPortDeviceInfo;
        DateTime SerialReceiveLastTime = DateTime.Now;

        static int headSize = 4;//包头长度 固定4
        //声明一个客户端
        TcpClient tcpClient;
        Thread T;

        // UI管理
        private readonly MaterialSkinManager materialSkinManager;

        public Main()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Black, Primary.Black, Primary.Black, Accent.LightBlue200, TextShade.WHITE);

            InitData();

            // 绑定上一次选择数据
            BindingInitInfo();

            // 初始化虚拟串口
            InitVirtualSerialPort();
            //设置控件可跨线程访问
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region 加载基础数据
        public void InitData()
        {
            this.cbx_BaudRate.Text = "9600";
            this.cbx_DataBits.Text = "8";
            this.cbx_Com.Text = "232";

            List<StopBits> stopBitsSource = Common.GetEnumList<StopBits>();
            stopBitsSource.Remove(StopBits.None);
            this.cbx_StopBits.DataSource = stopBitsSource;

            List<ParityStrEnum> paritysSource = Common.GetEnumList<ParityStrEnum>();
            this.cbx_Parity.DataSource = paritysSource;

        }

        /// <summary>
        /// 初始化虚拟串口
        /// </summary>
        private void InitVirtualSerialPort()
        {
            if (Properties.Settings.Default.PairNumber > -1)
            {
                var portPairs = SetupCFacade.GetCrossoverPortPairs().ToList();
                PortPair = portPairs.FirstOrDefault(w => w.PairNumber == Properties.Settings.Default.PairNumber);
            }

            // 创建虚拟串口
            PortPair = PortPair ?? CreateVirtualSerialPort(Com0ComStartPort);
            AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + $" 虚拟串口 {PortPair.PortNameA} 已创建");
            AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + $" 请将编程程序工具连接到 串口 {PortPair.PortNameA}");

            Properties.Settings.Default.PairNumber = PortPair.PairNumber;
            Properties.Settings.Default.Save();

            this.lbl_VirtualSerialPort.Text += $"{PortPair.PortNameA}";
            //this.lbl_VirtualSerialPort.Text = $"{PortPair.PortNameA}";
        }


        /// <summary>
        /// 绑定上一次选择数据
        /// </summary>
        public void BindingInitInfo()
        {
            this.cbx_BaudRate.Text = Properties.Settings.Default.BaudRate;
            this.cbx_DataBits.Text = Properties.Settings.Default.DataBits;
            this.cbx_Parity.Text = Properties.Settings.Default.Parity;
            this.cbx_StopBits.Text = Properties.Settings.Default.StopBits;
            this.cbx_Com.Text = Properties.Settings.Default.Com;
            this.txb_Code.Text = Properties.Settings.Default.Code;
            this.txb_IdentificationCode.Text = Properties.Settings.Default.IdentificationCode;
        }

        #endregion

        #region 按钮触发事件
        /// <summary>
        /// 打开/关闭tcp连接按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            Action action = new Action(ConnectAction);
            action.BeginInvoke(new AsyncCallback(ConnectActionCallback), action);
        }

        /// <summary>
        /// 测速点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NetworkSpeed_Click(object sender, EventArgs e)
        {
            try
            {
                if (!NetworkSpeedFlag)
                {
                    if (!VerifyConnectInfo()) return;

                    #region 串口配置禁止选择
                    this.cbx_BaudRate.Enabled = false;
                    this.cbx_DataBits.Enabled = false;
                    this.cbx_Parity.Enabled = false;
                    this.cbx_StopBits.Enabled = false;
                    this.cbx_Com.Enabled = false;
                    this.btn_Connect.Enabled = false;
                    this.txb_IdentificationCode.Enabled = false;
                    this.txb_Code.Enabled = false;
                    this.btn_NetworkSpeed.Enabled = false;
                    #endregion

                    this.btn_NetworkSpeed.Text = "测速中..";


                    IdentificationCodeRequest identificationCodeRequest = new IdentificationCodeRequest()
                    {
                        IdentificationCode = this.txb_IdentificationCode.Text,
                        Code = this.txb_Code.Text.Trim()
                    };

                    SystemAPISecurityVerifyRequest securityVerifyRequest = new SystemAPISecurityVerifyRequest()
                    {
                        Request_body = identificationCodeRequest.ObjectToJson(),
                        Timestamp = Common.GetCurrentMilliseconds().ToString()
                    };

                    // 调用接口获取tcp服务器连接配置
                    var TcpConfigResult = NetHelper.HttpPostToObject<PubulicMsgResult<TcpServicePortReceive>>(RequestBaseInfo.ApiUrl + "/api/ThirdParty/GetTcpServicePortByCode", securityVerifyRequest.ObjectToJson(), NetHelper.ContentType.application_json);

                    if (TcpConfigResult.Code != ResultCode.Success)
                    {
                        this.btn_Connect.Enabled = true;
                        throw new Exception(TcpConfigResult.Msg);
                    }

                    TcpPortDeviceInfo = TcpConfigResult.Data;
                    tcpClient = new TcpClient(TcpConfigResult.Data.ServiceIp, int.Parse(TcpConfigResult.Data.ServicePort));

                    //int port = ConnectMainTcpServer();
                    //this.txb_Port.Text = port.ToString();
                    //if (port == -1)
                    //    throw new Exception("连接服务端失败！");

                    //tcpClient = new TcpClient("192.168.3.132", port); // 这里填自己本机服务器ip和端口

                    if (tcpClient.Connected)
                    {
                        AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 连接服务端成功!");

                        // 发送mqtt消息，通知设备连接tcp服务器
                        DeviceTcpInfoRequest deviceTcpInfo = new DeviceTcpInfoRequest()
                        {
                            BaudRate = int.Parse(this.cbx_BaudRate.Text),
                            DataBits = int.Parse(this.cbx_DataBits.Text) - 5, // 对应mcu端
                            Parity = (int)Enum.Parse(typeof(DeviceParityEnum), this.cbx_Parity.Text),
                            StopBits = (int)Enum.Parse(typeof(DeviceStopBitsEnum), this.cbx_StopBits.Text),
                            Com = 0,   // 测速传固定值 0
                            TcpIP = TcpPortDeviceInfo.ServiceIp,
                            TcpPort = int.Parse(TcpPortDeviceInfo.ServicePort)
                        };

                        MQTTPubRequest pubRequest = new MQTTPubRequest()
                        {
                            MessageContent = deviceTcpInfo.ObjectToJson(),
                            ServiceNo = TcpPortDeviceInfo.ServiceNo,
                            ProductKey = TcpPortDeviceInfo.ProductKey,
                            TopicFullName = $"/{TcpPortDeviceInfo.ProductKey}/{TcpPortDeviceInfo.DeviceName}/user/GetTCPConnect",
                            IotInstanceId = TcpPortDeviceInfo.IotInstanceId
                        };

                        SystemAPISecurityVerifyRequest pubSecurityVerifyRequest = new SystemAPISecurityVerifyRequest()
                        {
                            Request_body = pubRequest.ObjectToJson(),
                            Timestamp = Common.GetCurrentMilliseconds().ToString()
                        };

                        //调用接口获取tcp服务器连接配置
                        var MQTTPubResult = NetHelper.HttpPostToObject<PubulicMsgResult<Object>>(RequestBaseInfo.ApiUrl + "/api/ThirdParty/MQTTPub", pubSecurityVerifyRequest.ObjectToJson(), NetHelper.ContentType.application_json);

                        if (MQTTPubResult.Code != ResultCode.Success)
                        {
                            this.btn_Connect.Enabled = true;
                            throw new Exception(MQTTPubResult.Msg);
                        }
                        AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 设备 " + this.txb_IdentificationCode.Text + " 配对请求已发送！");
                    }
                    var pingICMPHostHelper = new PingICMPHostHelper();


                    // 往tcp 发送4次数据
                    for (int i = 0; i < 10; i++)
                    {
                        AppendLog(pingICMPHostHelper.PingHost(tcpClient));
                        Thread.Sleep(1000);
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("网络测速失败：" + ex.Message);
                AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 网络测速失败：" + ex.Message);
                log.Error(ex);
            }
            finally
            {
                if (tcpClient != null && tcpClient.Connected)
                    tcpClient.Close();
                #region 串口配置开启选择
                this.cbx_BaudRate.Enabled = true;
                this.cbx_DataBits.Enabled = true;
                this.cbx_Parity.Enabled = true;
                this.cbx_StopBits.Enabled = true;
                this.cbx_Com.Enabled = true;
                this.txb_IdentificationCode.Enabled = true;
                this.txb_Code.Enabled = true;
                this.btn_NetworkSpeed.Enabled = true;
                #endregion

                this.btn_NetworkSpeed.Text = "测速";
            }
        }

        /// <summary>
        /// 校验输入连接信息是否正确
        /// </summary>
        /// <returns></returns>
        private bool VerifyConnectInfo()
        {
            // 校验输入框
            if (string.IsNullOrEmpty(this.txb_IdentificationCode.Text) || !Common.GetIsInt(Common.StrRegexTrim(this.txb_IdentificationCode.Text)))
            {
                MessageBox.Show("请输入识别码 只能输入数字！");
                return false;
            }

            if (string.IsNullOrEmpty(this.txb_Code.Text))
            {
                MessageBox.Show("请输入验证码！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 回车登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)    // 回车键
            {
                btn_Connect_Click(null, null);  // 登录方法
            }
        }

        #endregion

        #region 连接Tcp客户端
        /// <summary>
        /// 打开/关闭tcp连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectAction()
        {
            try
            {
                if (!TcpConnectFlag)
                {
                    if (!VerifyConnectInfo()) return;

                    #region 串口配置禁止选择
                    this.cbx_BaudRate.Enabled = false;
                    this.cbx_DataBits.Enabled = false;
                    this.cbx_Parity.Enabled = false;
                    this.cbx_StopBits.Enabled = false;
                    this.cbx_Com.Enabled = false;
                    this.btn_Connect.Enabled = false;
                    this.txb_IdentificationCode.Enabled = false;
                    this.txb_Code.Enabled = false;
                    this.btn_NetworkSpeed.Enabled = false;
                    #endregion
                    this.btn_Connect.Text = "连接中...";

                    #region 打开串口
                    //打开端口号
                    if (!SpCom.IsOpen)
                    {
                        var Serial = PortPair.PortNameB;
                        var BaudRate = int.Parse(this.cbx_BaudRate.Text.ToString());
                        var DataBits = int.Parse(this.cbx_DataBits.Text.ToString());
                        var StopBits = this.cbx_StopBits.SelectedValue;
                        var Parity = this.cbx_Parity.SelectedValue;

                        SpCom = new SerialPort();

                        //设置通讯端口号及波特率、数据位、停止位和校验位。
                        SpCom.PortName = Serial;
                        SpCom.BaudRate = BaudRate;
                        SpCom.Parity = (Parity)Parity;
                        SpCom.DataBits = DataBits;
                        SpCom.StopBits = (StopBits)StopBits;

                        //打开端口号
                        if (!SpCom.IsOpen)
                            SpCom.Open();
                    }
                    //AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + $" 串口 {PortPair.PortNameA}：已打开");
                    SpCom.DataReceived += new SerialDataReceivedEventHandler(ReceiveDataSerialEvent);
                    SpCom.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorDataSerialEvent);
                    #endregion

                    IdentificationCodeRequest identificationCodeRequest = new IdentificationCodeRequest()
                    {
                        IdentificationCode = Common.StrRegexTrim(this.txb_IdentificationCode.Text),
                        Code = Common.StrRegexTrim(this.txb_Code.Text)
                    };

                    SystemAPISecurityVerifyRequest securityVerifyRequest = new SystemAPISecurityVerifyRequest()
                    {
                        Request_body = identificationCodeRequest.ObjectToJson(),
                        Timestamp = Common.GetCurrentMilliseconds().ToString()
                    };

                    // 调用接口获取tcp服务器连接配置
                    var TcpConfigResult = NetHelper.HttpPostToObject<PubulicMsgResult<TcpServicePortReceive>>(RequestBaseInfo.ApiUrl + "/api/ThirdParty/GetTcpServicePortByCode", securityVerifyRequest.ObjectToJson(), NetHelper.ContentType.application_json);

                    if (TcpConfigResult.Code != ResultCode.Success)
                    {
                        this.btn_Connect.Enabled = true;
                        throw new Exception(TcpConfigResult.Msg);
                    }

                    TcpPortDeviceInfo = TcpConfigResult.Data;
                    tcpClient = new TcpClient(TcpConfigResult.Data.ServiceIp, int.Parse(TcpConfigResult.Data.ServicePort));

                    //int port = ConnectMainTcpServer();
                    //this.txb_Port.Text = port.ToString();
                    //if (port == -1)
                    //    throw new Exception("连接服务端失败！");

                    //tcpClient = new TcpClient("192.168.3.132", port); // 这里填自己本机服务器ip和端口

                    if (tcpClient.Connected)
                    {
                        AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 连接服务端成功!");

                        // 发送mqtt消息，通知设备连接tcp服务器
                        DeviceTcpInfoRequest deviceTcpInfo = new DeviceTcpInfoRequest()
                        {
                            BaudRate = int.Parse(this.cbx_BaudRate.Text),
                            DataBits = int.Parse(this.cbx_DataBits.Text) - 5, // 对应mcu端
                            Parity = (int)Enum.Parse(typeof(DeviceParityEnum), this.cbx_Parity.Text),
                            StopBits = (int)Enum.Parse(typeof(DeviceStopBitsEnum), this.cbx_StopBits.Text),
                            Com = int.Parse(this.cbx_Com.Text),
                            TcpIP = TcpPortDeviceInfo.ServiceIp,
                            TcpPort = int.Parse(TcpPortDeviceInfo.ServicePort)
                        };

                        MQTTPubRequest pubRequest = new MQTTPubRequest()
                        {
                            MessageContent = deviceTcpInfo.ObjectToJson(),
                            ServiceNo = TcpPortDeviceInfo.ServiceNo,
                            ProductKey = TcpPortDeviceInfo.ProductKey,
                            TopicFullName = $"/{TcpPortDeviceInfo.ProductKey}/{TcpPortDeviceInfo.DeviceName}/user/GetTCPConnect",
                            IotInstanceId = TcpPortDeviceInfo.IotInstanceId
                        };

                        SystemAPISecurityVerifyRequest pubSecurityVerifyRequest = new SystemAPISecurityVerifyRequest()
                        {
                            Request_body = pubRequest.ObjectToJson(),
                            Timestamp = Common.GetCurrentMilliseconds().ToString()
                        };

                        //调用接口获取tcp服务器连接配置
                        var MQTTPubResult = NetHelper.HttpPostToObject<PubulicMsgResult<Object>>(RequestBaseInfo.ApiUrl + "/api/ThirdParty/MQTTPub", pubSecurityVerifyRequest.ObjectToJson(), NetHelper.ContentType.application_json);

                        if (MQTTPubResult.Code != ResultCode.Success)
                        {
                            this.btn_Connect.Enabled = true;
                            throw new Exception(MQTTPubResult.Msg);
                        }
                        AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 设备 " + this.txb_IdentificationCode.Text + " 配对请求已发送！");
                    }

                    //通过线程循环接收
                    T = new Thread(new ParameterizedThreadStart(PrintReceiveMsg));
                    T.IsBackground = true;
                    T.Start(tcpClient);
                    TcpConnectFlag = true;
                    this.btn_Connect.Text = "断开";
                }
                else
                {
                    if (SpCom.IsOpen)
                    {
                        SpCom.Close();
                        //AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + $" 串口 {SpCom.PortName}：已关闭");
                    }

                    T.Abort();
                    tcpClient.Close();
                    this.txb_IdentificationCode.Enabled = true;
                    this.txb_Code.Enabled = true;

                    AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 断开连接成功!");
                    TcpConnectFlag = false;
                    this.btn_Connect.Text = "连接";
                }
            }
            catch (Exception ex)
            {
                if (!TcpConnectFlag)
                {
                    this.btn_Connect.Text = "连接";
                }

                if (tcpClient != null && tcpClient.Connected)
                    tcpClient.Close();

                if (SpCom.IsOpen)
                    SpCom.Close();

                MessageBox.Show("透传开启失败：" + ex.Message);
                AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 透传开启失败：" + ex.Message);
                log.Error(ex);
                return;
            }
        }

        private void ConnectActionCallback(IAsyncResult ar)
        {
            this.btn_Connect.Enabled = true;
            if (!TcpConnectFlag)
            {
                #region 串口配置开启选择
                this.cbx_BaudRate.Enabled = true;
                this.cbx_DataBits.Enabled = true;
                this.cbx_Parity.Enabled = true;
                this.cbx_StopBits.Enabled = true;
                this.cbx_Com.Enabled = true;
                this.txb_IdentificationCode.Enabled = true;
                this.txb_Code.Enabled = true;
                this.btn_NetworkSpeed.Enabled = true;
                #endregion
            }
        }

        /// <summary>
        /// 接收TCP服务端返回的数据
        /// </summary>
        /// <param name="Obj_tcpClient"></param>
        /// 
        private void PrintReceiveMsg(object Obj_tcpClient)
        {
            TcpClient tcpClient = (TcpClient)Obj_tcpClient;
            try
            {
                if (!tcpClient.Connected)
                {
                    return;
                }
                var networkStream = tcpClient.GetStream();

                byte[] nHeadLen = new byte[headSize]; //包含长度的数据首部
                BinaryReader br = new BinaryReader(networkStream);

                while (true)
                {
                    DateTime lastTime = DateTime.Now;
                    if (networkStream.DataAvailable)
                    {

                        nHeadLen = br.ReadBytes(headSize); //从字节流中读取四个字节，若是字节数小于四个，会继续等待，继续读取

                        if (nHeadLen.Length == headSize) //读到一个整形的数据后，读指定长度的内容
                        {
                            //int dataLen = BitConverter.ToInt32(nHeadLen, 0);
                            int dataLen = 0;

                            if (!int.TryParse(Encoding.ASCII.GetString(nHeadLen), out dataLen))
                            {
                                AppendLog("数据长度异常,请重新连接");
                                continue;
                            }

                            byte[] data = new byte[dataLen];

                            if (dataLen == 0) // 防止传 "0000"
                                continue;

                            data = br.ReadBytes(dataLen);  //若是读到数据没有到指定长度,继续等待读取

                            Array.Clear(nHeadLen, 0, nHeadLen.Length);

                            //Console.WriteLine("\n接收服务端发来的数据: " + getStringFromBytes(data, data.Length));
                            AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 收→◆" + Common.getStringFromBytes(data, data.Length));

                            string receiveMsg = Encoding.Default.GetString(data, 0, dataLen);
                            if (receiveMsg == "Device TCP connect success")
                            {
                                AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 设备 " + this.txb_IdentificationCode.Text + "：已上线！");
                                continue;
                            }

                            if (receiveMsg == "Device TCP cancel connect")
                            {
                                AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 设备 " + this.txb_IdentificationCode.Text + "：已离线！");
                                continue;
                            }

                            var SleepTime = (DateTime.Now - lastTime).TotalMilliseconds;
                            if (SleepTime <= 20)
                                Thread.Sleep(20 - (int)SleepTime);

                            if (SpCom.IsOpen)
                                SpCom.Write(data, 0, data.Length);
                            else
                            {
                                AppendLog("本地串口已断开连接");
                                MessageBox.Show("本地串口已断开连接");

                                this.btn_Connect.Text = "连接";
                                TcpConnectFlag = false;
                                tcpClient.Close();
                                this.txb_IdentificationCode.Enabled = true;
                                this.txb_Code.Enabled = true;
                                return;
                            }
                            Receive += dataLen;
                            this.lab_Receive.Text = "R:" + Receive;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "正在中止线程。") return;
                log.Error(ex);
                AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 服务器断开连接");
            }
        }

        #endregion

        #region 串口操作
        /// <summary>
        /// 读取串口发送数据线程
        /// </summary>
        public void PrintSerialMsg(object Obj_tcpClient)
        {
            while (true)
            {
                try
                {
                    DateTime lastTime = DateTime.Now;
                    if (SpCom.IsOpen)
                    {
                        int count = SpCom.BytesToRead;
                        if (count == 0) continue;

                        if (tcpClient == null || !tcpClient.Connected) continue;
                        byte[] readBuffer = new byte[count];
                        SpCom.Read(readBuffer, 0, count);

                        var SleepTime = (DateTime.Now - lastTime).TotalMilliseconds;
                        if (SleepTime <= 20)
                        {
                            Thread.Sleep(20 - (int)SleepTime);
                        }

                        var sendBuffer = Common.PacketData(readBuffer);   // 加上自定义头部，数据长度
                        tcpClient.GetStream().Write(sendBuffer, 0, sendBuffer.Length);

                        AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 发→◇" + Common.getStringFromBytes(readBuffer, count));
                        //Send(16, sendBuffer, stream);

                        Send += readBuffer.Length;
                        this.lab_Send.Text = "S:" + Send;
                    }
                    //else
                    //{
                    //    break;
                    //}
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    if (ex.Message == "正在中止线程。") break;
                    AppendLog("读取串口发送数据线程" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 串口错误回调
        /// </summary>
        public void ErrorDataSerialEvent(object sender, SerialErrorReceivedEventArgs e)
        {
            //MessageBox.Show("串口错误：", e.EventType.ToString());
        }

        /// <summary>
        /// 串口收到数据回调
        /// </summary>
        public void ReceiveDataSerialEvent(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;

            int count = SpCom.BytesToRead;
            if (count == 0) return;

            byte[] readBuffer = new byte[count];
            SpCom.Read(readBuffer, 0, count);

            if (tcpClient == null || !tcpClient.Connected) return;

            var sendBuffer = Common.PacketData(readBuffer);   // 加上自定义头部，数据长度
            tcpClient.GetStream().Write(sendBuffer, 0, sendBuffer.Length);

            AppendLog(DateTime.Now.ToString("HH:mm:ss ffff") + " 发→◇" + Common.getStringFromBytes(readBuffer, count));

            Send += readBuffer.Length;
            this.lab_Send.Text = "S:" + Send;

            //var SleepTime = (DateTime.Now - SerialReceiveLastTime).TotalMilliseconds;
            //if (SleepTime <= 20)
            //{
            //    Thread.Sleep(20 - (int)SleepTime);
            //}
            //SerialReceiveLastTime = DateTime.Now;
        }

        /// <summary>
        /// 获取未被占用的Com Port
        /// </summary>
        /// <param name="portStart"></param>
        /// <returns></returns>
        public int GetUnoccupiedPort(int portStart)
        {
            List<string> portNames = SerialPort.GetPortNames().ToList();

            for (int i = portStart; i < 100; i++)
            {
                if (!portNames.Contains("COM" + i))
                {
                    return i;
                }
            }
            return portStart + 100;
        }

        /// <summary>
        /// 创建虚拟串口
        /// </summary>
        private CrossoverPortPair CreateVirtualSerialPort(int startPort)
        {
            // 创建两个相通的串口
            int portFirst = GetUnoccupiedPort(startPort);
            int portSecond = GetUnoccupiedPort(portFirst + 1);

            return SetupCFacade.CreatePortPair($"COM{portFirst}", $"COM{portSecond}");
        }
        #endregion

        #region 关闭触发事件
        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (T != null && T.IsAlive) T.Abort();
            if (tcpClient != null && tcpClient.Connected)
            {
                tcpClient.Close();
            }
            if (SpCom.IsOpen)
            {
                SpCom.Close();
            }

            // 关闭虚拟串口
            if (PortPair != null)
            {
                if (!Common.IsCommPortValid(PortPair.PortNameA) || !Common.IsCommPortValid(PortPair.PortNameB))
                    Properties.Settings.Default.PairNumber = PortPair.PairNumber;
                else
                {
                    SetupCFacade.DeletePortPair(PortPair.PairNumber);
                    Properties.Settings.Default.PairNumber = -1;
                }
            }

            Properties.Settings.Default.BaudRate = this.cbx_BaudRate.Text;
            Properties.Settings.Default.DataBits = this.cbx_DataBits.Text;
            Properties.Settings.Default.Parity = this.cbx_Parity.Text;
            Properties.Settings.Default.StopBits = this.cbx_StopBits.Text;
            Properties.Settings.Default.Com = this.cbx_Com.Text;
            Properties.Settings.Default.Code = this.txb_Code.Text;
            Properties.Settings.Default.IdentificationCode = this.txb_IdentificationCode.Text;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region 日志输出框
        /// <summary>
        /// 清空日志输出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            Send = 0;
            Receive = 0;
            lab_Send.Text = "S:0";
            lab_Receive.Text = "R:0";

            txb_Log.Text = "";
        }

        /// <summary>
        /// 输出添加日志
        /// </summary>
        /// <param name="str"></param>
        private void AppendLog(string str)
        {
            txb_Log.AppendText("\r\n" + str);
            this.txb_Log.Focus();//获取焦点
            this.txb_Log.Select(this.txb_Log.TextLength, 0);
            this.txb_Log.ScrollToCaret();
        }
        #endregion

        /// <summary>
        /// 从剪切板粘贴数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CopyFormClipboard_Click(object sender, EventArgs e)
        {
            //设备识别码：717220241 验证码：FMpR4f 有限期至：2022/07/22 00:32:29
            string clipboardText = Clipboard.GetText();

            if (string.IsNullOrEmpty(clipboardText))
            {
                MessageBox.Show("读取剪切板数据失败");
                return;
            }

            List<string> extractStrList = new List<string>();

            string str = string.Empty;
            foreach (char c in clipboardText)
            {
                if (IsLetterOrDigit(c))
                {
                    str += c;
                }
                else
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        extractStrList.Add(str);
                        str = string.Empty;
                    }
                }
            }
            if (!string.IsNullOrEmpty(str))
                extractStrList.Add(str);

            string identificationCode = extractStrList.FirstOrDefault(w => w.Length > 5 && Common.GetIsInt(w));
            string code = extractStrList.FirstOrDefault(w => w.Length > 5 && identificationCode != w);
            if (string.IsNullOrEmpty(identificationCode) || string.IsNullOrEmpty(identificationCode))
            {
                MessageBox.Show("读取剪切板数据失败");
                return;
            }
            this.txb_IdentificationCode.Text = identificationCode;
            this.txb_Code.Text = code;
        }

        private bool IsLetterOrDigit(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            if (c >= 'a' && c <= 'z')
            {
                return true;
            }
            if (c >= 'A' && c <= 'Z')
            {
                c = (char)(c + 32);
                return true;
            }
            return false;
        }


    }
}
