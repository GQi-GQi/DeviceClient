namespace YuDa.DeviceClient
{
    public class DeviceTcpInfoRequest
    {
        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; }
        /// <summary>
        /// 数据检验位
        /// </summary>
        public int DataBits { get; set; }
        /// <summary>
        /// 奇偶检验位
        /// </summary>
        public int Parity { get; set; }
        /// <summary>
        /// 停止位
        /// </summary>
        public int StopBits { get; set; }
        /// <summary>
        /// 串口信息
        /// </summary>
        public int Com { get; set; }
        /// <summary>
        /// tcpIP
        /// </summary>
        public string TcpIP { get; set; }
        /// <summary>
        /// tcp端口
        /// </summary>
        public int TcpPort { get; set; }
    }
}
