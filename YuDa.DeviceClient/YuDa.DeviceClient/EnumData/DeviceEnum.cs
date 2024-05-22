namespace YuDa.DeviceClient
{
    /// <summary>
    ///  停止位
    /// </summary>
    public enum DeviceStopBitsEnum : int
    {
        One = 1,
        Two = 2,
        OnePointFive = 3
    }

    /// <summary>
    /// 数据校验位
    /// </summary>
    public enum DeviceParityEnum : int
    {
        None_无校验 = 0,
        Even_偶校验 = 2,
        Odd__奇校验 = 3,
    }

    public enum ParityStrEnum
    {
        None_无校验,
        Odd__奇校验,
        Even_偶校验
    }
}
