using Newtonsoft.Json;

namespace TBC.CommonLib
{
    /// <summary>
    /// 数据转换类
    /// </summary>
    public static class Convert
    {
        #region 字符串转其他
        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static int ToInt(this string? str, int defaultVal = 0)
        {
            return int.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转ushort
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static ushort ToUshort(this string? str, ushort defaultVal = 0)
        {
            return ushort.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转short
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static short ToShort(this string? str, short defaultVal = 0)
        {
            return short.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转uint
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static uint ToUint(this string? str, uint defaultVal = 0)
        {
            return uint.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转Long
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static long ToLong(this string? str, long defaultVal = 0)
        {
            return long.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转uLong
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static ulong ToUlong(this string? str, ulong defaultVal = 0)
        {
            return ulong.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static double ToDouble(this string? str, double defaultVal = 0)
        {
            return double.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转float
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static float ToFloat(this string? str, float defaultVal = 0)
        {
            return float.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:0</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string? str, decimal defaultVal = 0)
        {
            return decimal.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:false</param>
        /// <returns></returns>
        public static bool ToBool(this string? str, bool defaultVal = false)
        {
            return bool.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转DateTime
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值:当前时间</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string? str, DateTime? defaultVal = null)
        {
            return DateTime.TryParse(str, out var val) ? val : defaultVal ?? DateTime.Now;
        }

        /// <summary>
        /// 字符串转byte
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns></returns>
        public static byte ToByte(this string? str, byte? defaultVal = null)
        {
            return byte.TryParse(str, out var val) ? val : defaultVal ?? new byte();
        }

        /// <summary>
        /// 字符串转枚举
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static T? ToEnum<T>(this string? str) where T : struct
        {
            if (!Enum.TryParse(str, out T result)) return null;
            return result;
        }

        /// <summary>
        /// json字符串转对象
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="str">json字符串</param>
        /// <returns></returns>
        public static T? ToModel<T>(this string? str) where T : class
        {
            if (string.IsNullOrWhiteSpace(str)) return default;
            var res = JsonConvert.DeserializeObject<T>(str);
            return res;
        }
        #endregion

        #region int/long转其他
        /// <summary>
        /// 转枚举
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static T? ToEnum<T>(this int value) where T : struct
        {
            if (Enum.IsDefined(typeof(T), value)) return (T)(object)value;
            else return null;
        }
        #endregion

        #region object转其他
        /// <summary>
        /// 类转json字符串
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="value">实体类</param>
        /// <param name="format">格式化方式</param>
        /// <returns></returns>
        public static string ToJsonString<T>(this T? value, Formatting format = Formatting.Indented) where T : class
        {
            if (value == null) return "";
            var jsonStr = JsonConvert.SerializeObject(value, format);
            return jsonStr ?? "";
        }
        #endregion
    }
}
