namespace YuDa.DeviceClient
{
    public class SystemAPISecurityVerifyRequest
    {
        /// <summary>
        /// body
        /// </summary>
        public string Request_body { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// token（加密后的32位字符串）
        /// </summary>
        public string Token => Common.TokenEncodeMD5(this.Request_body + this.Timestamp);
    }
}
