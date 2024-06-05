using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Reflection;

namespace TBC.CommonLib
{
    /// <summary>
    /// 数据转换类
    /// </summary>
    public static class Converts
    {
        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ToInt(this string str)
        {
            var b = int.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转整数类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static int ToInt(this string? str, int defaultVal = 0)
        {
            return int.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转ushort
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ushort ToUshort(this string str)
        {
            var b = ushort.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转无符号短整型类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转ushort
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static ushort ToUshort(this string? str, ushort defaultVal = 0)
        {
            return ushort.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转short
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static short ToShort(this string str)
        {
            var b = short.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转短整型类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转short
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static short ToShort(this string? str, short defaultVal = 0)
        {
            return short.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转uint
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static uint ToUint(this string str)
        {
            var b = uint.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转无符号整数类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转uint
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static uint ToUint(this string? str, uint defaultVal = 0)
        {
            return uint.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转Long
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static long ToLong(this string str)
        {
            var b = long.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转长整数类型失败");
            return val;
        }

        /// <summary>
        /// int转Long
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static long ToLong(this int num)
        {
            try
            {
                return num;
            }
            catch
            {
                throw new Exception("整数类型转长整数类型失败");
            }
        }

        /// <summary>
        /// 字符串转Long
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static long ToLong(this string? str, long defaultVal = 0)
        {
            return long.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转uLong
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ulong ToUlong(this string str)
        {
            var b = ulong.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转无符号长整数类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转uLong
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static ulong ToUlong(this string? str, ulong defaultVal = 0)
        {
            return ulong.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static double ToDouble(this string str)
        {
            var b = double.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转双精度浮点数数据类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static double ToDouble(this string? str, double defaultVal = 0)
        {
            return double.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转float
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static float ToFloat(this string str)
        {
            var b = float.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转单精度浮点数数据类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转float
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static float ToFloat(this string? str, float defaultVal = 0)
        {
            return float.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static decimal ToDecimal(this string str)
        {
            var b = decimal.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转高精度小数的数据类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string? str, decimal defaultVal = 0)
        {
            return decimal.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool ToBool(this string str)
        {
            var b = bool.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转布尔类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static bool ToBool(this string? str, bool defaultVal = false)
        {
            return bool.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DateTime ToDateTime(this string str)
        {
            var b = DateTime.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转时间类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转DateTime
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string? str, DateTime defaultVal)
        {
            return DateTime.TryParse(str, out var val) ? val : defaultVal;
        }

        /// <summary>
        /// 字符串转byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static byte ToByte(this string str)
        {
            var b = byte.TryParse(str, out var val);
            if (!b) throw new Exception("字符串转byte类型失败");
            return val;
        }

        /// <summary>
        /// 字符串转byte
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultVal">转换失败后默认值</param>
        /// <returns></returns>
        public static byte ToByte(this string? str, byte defaultVal = 0)
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
            if (!Enum.TryParse(str, out T result)) throw new Exception("字符串转枚举类型失败");
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
            if (!str.IsValidJson()) throw new Exception("请传入json字符串");
            var res = JsonConvert.DeserializeObject<T>(str);
            return res ?? throw new Exception("json字符串转对象失败");
        }

        /// <summary>
        /// 获取json字符串的键的值
        /// </summary>
        /// <param name="str">json字符串</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string Fetch(this string str, string key)
        {
            if (str.IsValidJson())
            {
                var res = JObject.Parse(str);
                return res[key]?.ToString() ?? throw new Exception("键不存在！");
            }
            throw new Exception("非json字符串！");
        }

        /// <summary>
        /// 获取json字符串的键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">json字符串</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static T Fetch<T>(this string str, string key)
        {
            if (str.IsValidJson())
            {
                var res = JObject.Parse(str);
                var val = res[key] ?? throw new Exception("键不存在！");
                var fin = val.ToObject<T>();
                return fin == null ? throw new Exception("类型转换失败！") : fin;
            }
            throw new Exception("非json字符串！");
        }

        /// <summary>
        /// 字符串转JObject
        /// </summary>
        /// <param name="str">json字符串</param>
        /// <returns></returns>
        public static JObject ToJObject(this string str)
        {
            if (str.IsValidJson()) throw new Exception("非json字符串！");
            return JObject.Parse(str);
        }

        /// <summary>
        /// 字符串转JArray
        /// </summary>
        /// <param name="str">json字符串</param>
        /// <returns></returns>
        public static JArray ToJArray(this string str)
        {
            if (str.IsValidJson()) throw new Exception("非json字符串！");
            return JArray.Parse(str);
        }

        /// <summary>
        /// 是否是json字符串
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static bool IsValidJson(this string jsonString)
        {
            try
            {
                _ = JsonConvert.DeserializeObject(jsonString);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        /// <summary>
        /// 字符串转list
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="splitCahr">分割符</param>
        /// <returns></returns>
        public static List<string> ToListStr(this string str, char splitCahr = ',')
        {
            try
            {
                var list = str.Split(splitCahr).ToList();
                return list ?? throw new Exception("字符串转字符串列表失败");
            }
            catch (Exception e)
            {
                throw new Exception("转换失败：" + e.Message);
            }
        }

        /// <summary>
        /// list转字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="splitCahr">分割符</param>
        /// <returns></returns>
        public static string ListToStr<T>(this IEnumerable<T> list, char splitCahr = ',')
        {
            try
            {
                var str = string.Join(splitCahr, list);
                return str ?? throw new Exception("列表转字符串失败");
            }
            catch (Exception e)
            {
                throw new Exception("转换失败：" + e.Message);
            }
        }

        /// <summary>
        /// 字符串转list
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="splitCahr">分割符</param>
        /// <returns></returns>
        public static List<int> ToListInt(this string str, char splitCahr = ',')
        {
            try
            {
                var list = str.Split(splitCahr).Select(t => t.ToInt()).ToList();
                return list ?? throw new Exception("字符串转整数列表失败");
            }
            catch (Exception e)
            {
                throw new Exception("转换失败：" + e.Message);
            }
        }

        /// <summary>
        /// 字符串转list
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="splitCahr">分割符</param>
        /// <returns></returns>
        public static List<T> ToListObj<T>(this string str, char splitCahr = ',')
        {
            try
            {
                var list = str.Split(splitCahr).Select(t => (T)Convert.ChangeType(t.Trim(), typeof(T))).ToList();
                return list ?? throw new Exception("字符串转列表失败");
            }
            catch (Exception e)
            {
                throw new Exception("转换失败：" + e.Message);
            }
        }

        /// <summary>
        /// 转枚举
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value) where T : struct
        {
            try
            {
                if (Enum.IsDefined(typeof(T), value)) return (T)(object)value;
                throw new Exception("整数类型转枚举失败");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// date转时间戳
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="millisecond">true:转毫秒级(默认),false:转秒级</param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime date, bool millisecond = true)
        {
            try
            {
                long timestamp;
                if (millisecond) timestamp = new DateTimeOffset(date).ToUnixTimeSeconds();
                else timestamp = new DateTimeOffset(date).ToUnixTimeMilliseconds();
                return timestamp;
            }
            catch (Exception e)
            {
                throw new Exception("时间转换成时间戳失败，原因：" + e.Message);
            }
        }

        /// <summary>
        /// 类转json字符串
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="value">实体类</param>
        /// <param name="format">格式化方式</param>
        /// <returns></returns>
        public static string ToJsonStr<T>(this T value, Formatting format = Formatting.Indented) where T : class
        {
            try
            {
                var jsonStr = JsonConvert.SerializeObject(value, format);
                return jsonStr;
            }
            catch (Exception e)
            {
                throw new Exception("未成功转为json字符串，原因：" + e.Message);
            }
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value) where T : Enum
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value)!;
            MemberInfo member = type.GetMember(name)[0];
            DescriptionAttribute? attribute = member.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : name;
        }

        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T value) where T : class
        {
            try
            {
                var jsonStr = value.ToJsonStr();
                return jsonStr.ToModel<T>();
            }
            catch (Exception e)
            {
                throw new Exception("对象深克隆失败，原因：" + e.Message);
            }
        }
    }
}
