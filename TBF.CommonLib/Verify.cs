using System.Text.RegularExpressions;

namespace TBC.CommonLib
{
    /// <summary>
    /// 数据校验
    /// </summary>
    public static class Verify
    {
        /// <summary>
        /// 判断是否为有效的Email地址
        /// </summary>
        /// <returns></returns>
        public static bool IsEmail(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return Regex.IsMatch(value, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");
        }

        /// <summary>
        /// 验证是否是合法的电话号码
        /// </summary>
        /// <returns></returns>
        public static bool IsMobile(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return Regex.IsMatch(value, @"^(0|86|17951)?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$");
        }

        /// <summary>
        /// 判断字符串是否是qq
        /// </summary>
        /// <returns></returns>
        public static bool IsQQ(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return Regex.IsMatch(value, @"^[1-9]\d{4,15}$");
        }

        /// <summary>
        /// 判断字符串是否是身份证
        /// </summary>
        /// <returns></returns>
        public static bool IsIDCard(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            var regex = "(^[1-9]\\d{5}(18|19|([23]\\d))\\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\\d{3}[0-9Xx]$)|(^[1-9]\\d{5}\\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\\d{2}$)";
            return Regex.IsMatch(value, regex);
        }

        /// <summary>
        /// 判断字符串是否是url
        /// </summary>
        /// <returns></returns>
        public static bool IsUrl(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            string pattern = @"^(http|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$";
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 判断字符串是否是合法IPV4
        /// </summary>
        /// <returns></returns>
        public static bool IsIPV4(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            string pattern =
            @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 时间戳字符串转时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="num">时间戳位数</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime TimeStampToDate(string? timeStamp, int num = 13)
        {
            if (string.IsNullOrWhiteSpace(timeStamp))
                throw new ArgumentException("时间戳不能为空");

            if (!long.TryParse(timeStamp, out long unixTimeStamp))
                throw new ArgumentException("时间戳格式不正确");

            if (num == 10)
                unixTimeStamp *= 1000; // 将 10 位时间戳转换为 13 位时间戳
            else if (num != 13)
                throw new ArgumentException("时间戳位数必须为 10 或 13");

            DateTime origin = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = origin.AddMilliseconds(unixTimeStamp);
            return date;
        }

        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="num">时间戳位数</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime TimeStampToDate(long timeStamp, int num = 13)
        {
            if (num == 10)
                timeStamp *= 1000; // 将 10 位时间戳转换为 13 位时间戳
            else if (num != 13)
                throw new ArgumentException("时间戳位数必须为 10 或 13");

            DateTime origin = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = origin.AddMilliseconds(timeStamp);
            return date;
        }
    }
}
