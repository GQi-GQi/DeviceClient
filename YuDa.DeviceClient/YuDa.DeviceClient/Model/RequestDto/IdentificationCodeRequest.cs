namespace YuDa.DeviceClient
{
    /// <summary>
    /// 通过验证码获取tcp数据
    /// </summary>
    public class IdentificationCodeRequest
    {
        /// <summary>
        /// 识别码
        /// </summary>
        public string IdentificationCode { get; set; }

        /// <summary>
        /// 自定义验证码（非必填，传入会使用自定义的验证码）
        /// </summary>
        public string Code { get; set; }
    }
}
