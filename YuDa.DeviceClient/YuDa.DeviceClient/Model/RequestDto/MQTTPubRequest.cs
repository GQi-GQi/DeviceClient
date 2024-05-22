using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YuDa.DeviceClient
{
    public class MQTTPubRequest
    {
        /// <summary>
        /// 设备服务号
        /// </summary>
        public int ServiceNo { get; set; }

        /// <summary>
        /// 消息主体
        /// </summary>
        public string MessageContent { get; set; }

        /// <summary>
        /// 产品key
        /// </summary>
        public string ProductKey { get; set; }


        /// <summary>
        /// 自定义Topic
        /// </summary>
        public string TopicFullName { get; set; }

        /// <summary>
        /// 实例Id
        /// </summary>
        public string IotInstanceId { get; set; }



    }
}
