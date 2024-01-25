﻿using Newtonsoft.Json;

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
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int ToInt(this string str)
        {
            var b = int.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static int ToInt(this string str, int defaultVal)
        {
            return int.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转ushort
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ushort ToUshort(this string str)
        {
            var b = ushort.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转ushort
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static ushort ToUshort(this string str, ushort defaultVal)
        {
            return ushort.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转short
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static short ToShort(this string str)
        {
            var b = short.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转short
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static short ToShort(this string str, short defaultVal)
        {
            return short.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转uint
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static uint ToUint(this string str)
        {
            var b = uint.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转uint
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static uint ToUint(this string str, uint defaultVal)
        {
            return uint.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转Long
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static long ToLong(this string str)
        {
            var b = long.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转Long
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static long ToLong(this string str, long defaultVal)
        {
            return long.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转uLong
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ulong ToUlong(this string str)
        {
            var b = ulong.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转uLong
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static ulong ToUlong(this string str, ulong defaultVal)
        {
            return ulong.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double ToDouble(this string str)
        {
            var b = double.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static double ToDouble(this string str, double defaultVal)
        {
            return double.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转float
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static float ToFloat(this string str)
        {
            var b = float.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转float
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static float ToFloat(this string str, float defaultVal)
        {
            return float.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static decimal ToDecimal(this string str)
        {
            var b = decimal.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str, decimal defaultVal)
        {
            return decimal.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool ToBool(this string str)
        {
            var b = bool.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static bool ToBool(this string str, bool defaultVal)
        {
            return bool.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime ToDateTime(this string str)
        {
            var b = DateTime.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转DateTime
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str, DateTime defaultVal)
        {
            return DateTime.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static byte ToByte(this string str)
        {
            var b = byte.TryParse(str, out var val);
            if (!b) throw new ArgumentException("转换失败");
            return val;
        }

        /// <summary>
        /// 字符串转byte
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static byte ToByte(this string str, byte defaultVal)
        {
            return byte.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转枚举
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str) where T : struct
        {
            if (!Enum.TryParse(str, out T result)) throw new ArgumentException("转换失败");
            return result;
        }

        /// <summary>
        /// json字符串转对象
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="str">json字符串</param>
        /// <returns></returns>
        public static T ToModel<T>(this string str) where T : class
        {
            var res = JsonConvert.DeserializeObject<T>(str);
            return res ?? throw new ArgumentException("转换失败");
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
        public static string ToJsonString<T>(this T value, Formatting format = Formatting.Indented) where T : class
        {
            if (value == null) return "";
            var jsonStr = JsonConvert.SerializeObject(value, format);
            return jsonStr ?? "";
        }
        #endregion
    }
}
