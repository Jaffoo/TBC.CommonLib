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
            string pattern = @"^((https|http|ftp|rtsp|mms|ws|wss)?:\/\/)[^\s]+";
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
    }
}
