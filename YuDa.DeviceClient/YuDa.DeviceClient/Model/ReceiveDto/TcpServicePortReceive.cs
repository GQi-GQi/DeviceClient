using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YuDa.DeviceClient
{
    /// <summary>
    /// 获取tcp连接信息
    /// </summary>
    public class TcpServicePortReceive
    {
        /// <summary>
        /// 服务号
        /// </summary>
        public int ServiceNo { get; set; }

        /// <summary>
        /// 产品Key
        /// </summary>
        public string ProductKey { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// TCP服务端 IP
        /// </summary>
        public string ServiceIp { get; set; }

        /// <summary>
        /// TCP服务端 端口号
        /// </summary>
        public string ServicePort { get; set; }

        /// <summary>
        /// 实例Id
        /// </summary>
        public string IotInstanceId { get; set; }
    }
}
