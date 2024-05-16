using Newtonsoft.Json;
using System.Web;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TBC.CommonLib
{
    /// <summary>
    /// 工具类
    /// </summary>
    public static class Tools
    {
        #region 敏感信息脱敏
        /// <summary>
        /// 电话号码脱敏
        /// </summary>
        /// <param name="phone">电话号码</param>
        /// <param name="num">隐藏几位</param>
        /// <param name="start">开头显示几位</param>
        /// <param name="charStr">隐藏替换符号</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string PhoneHide(string phone, int num = 4, int start = 3, string charStr = "*")
        {
            try
            {
                if (start >= 11) start = 3;
                if (num + start >= 11) num = 11 - start;
                var numStr = phone!.Substring(start, num);
                charStr = new string(charStr[0], num);
                var result = phone.Replace(numStr, charStr);
                return result;
            }
            catch (Exception)
            {
                throw new ArgumentException("电话号码格式错误");
            }
        }

        /// <summary>
        /// 字符串脱敏
        /// </summary>
        /// <param name="str">脱敏字符串</param>
        /// <param name="num">隐藏几位</param>
        /// <param name="start">开始脱敏索引</param>
        /// <param name="charStr">隐藏替换符号</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string StringHide(string str, int num, int start, string charStr = "*")
        {
            try
            {
                if (start >= str.Length) throw new Exception("脱敏开始索引大于脱敏字符串长度");
                if (num + start >= str.Length) num = str.Length - start;
                var numStr = str!.Substring(start, num);
                charStr = new string(charStr[0], num);
                var result = str.Replace(numStr, charStr);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 身份证
        /// <summary>
        /// 从身份证号码中提取出生日期
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime BirthdayFromIDCard(string idCard)
        {
            try
            {
                string birthdayPart = idCard!.Substring(6, 8);
                int year = birthdayPart.Substring(0, 4).ToInt();
                int month = birthdayPart.Substring(4, 2).ToInt();
                int day = birthdayPart.Substring(6, 2).ToInt();

                var birthday = new DateTime(year, month, day);
                return birthday;
            }
            catch (Exception)
            {
                throw new ArgumentException("身份证号码格式错误");
            }
        }

        /// <summary>
        /// 从身份证号码中提取性别
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string SexFromIDCard(string idCard)
        {
            try
            {
                char genderChar = idCard![^2]; // 获取倒数第二位字符
                if (genderChar % 2 == 0) return "女";
                else return "男";
            }
            catch (Exception)
            {
                throw new ArgumentException("身份证号码格式错误");
            }
        }

        /// <summary>
        /// 身份证号码中计算年龄
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        public static int AgeFromIDCard(string idCard)
        {
            try
            {
                var birthday = BirthdayFromIDCard(idCard);
                DateTime currentDate = DateTime.Now;
                int age = currentDate.Year - birthday.Year;
                if (currentDate < birthday.AddYears(age))
                    age--;
                return age;
            }
            catch (Exception)
            {
                throw new ArgumentException("身份证号码格式错误");
            }
        }

        /// <summary>
        /// 身份证获取星座
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string StarFromIdCard(string idCard)
        {
            try
            {
                var birthday = BirthdayFromIDCard(idCard);
                int month = birthday.Month;
                int day = birthday.Day;

                if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                {
                    return "白羊座";
                }
                else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                {
                    return "金牛座";
                }
                else if ((month == 5 && day >= 21) || (month == 6 && day <= 21))
                {
                    return "双子座";
                }
                else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
                {
                    return "巨蟹座";
                }
                else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                {
                    return "狮子座";
                }
                else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                {
                    return "处女座";
                }
                else if ((month == 9 && day >= 23) || (month == 10 && day <= 23))
                {
                    return "天秤座";
                }
                else if ((month == 10 && day >= 24) || (month == 11 && day <= 22))
                {
                    return "天蝎座";
                }
                else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
                {
                    return "射手座";
                }
                else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                {
                    return "摩羯座";
                }
                else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                {
                    return "水瓶座";
                }
                else // (month == 2 && day >= 19) || (month == 3 && day <= 20)
                {
                    return "双鱼座";
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("身份证号码格式错误");
            }
        }
        #endregion

        #region 时间
        /// <summary>
        /// 时间戳字符串转时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="num">时间戳位数</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime TimeStampToDate(string timeStamp, int num = 13)
        {
            if (string.IsNullOrWhiteSpace(timeStamp))
                throw new ArgumentException("时间戳不能为空");

            if (!long.TryParse(timeStamp, out long unixTimeStamp))
                throw new ArgumentException("时间戳格式不正确");

            if (num == 10)
                unixTimeStamp *= 1000; // 将 10 位时间戳转换为 13 位时间戳
            else if (num != 13)
                throw new ArgumentException("时间戳位数必须为 10 或 13");
            try
            {
                DateTime origin = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = origin.AddMilliseconds(unixTimeStamp);
                return date;
            }
            catch (Exception)
            {
                throw new Exception("转换失败");
            }
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
            try
            {
                DateTime origin = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = origin.AddMilliseconds(timeStamp);
                return date;
            }
            catch (Exception)
            {
                throw new Exception("转换失败");
            }
        }

        /// <summary>
        /// 获取周一的时间
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public static DateTime Monday(DateTime date)
        {
            int daysToSubtract = ((int)date.DayOfWeek - 1 + 7) % 7; // 计算需要减去的天数以获取星期一
            return date.Date.AddDays(-daysToSubtract); // 返回星期一的日期
        }

        /// <summary>
        /// 获取某月第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FirstDay(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            return new DateTime(year, month, 1);
        }

        /// <summary>
        /// 获取月末最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime LastDay(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, daysInMonth);
        }

        /// <summary>
        /// 获取某时间所在周的数组
        /// </summary>
        /// <param name="date"></param>
        /// <param name="order">排序方式</param>
        /// <returns></returns>
        public static List<DateTime> ThisWeek(DateTime date, string order = "asc")
        {
            List<DateTime> weekDates = new();
            DateTime startDate = date.Date.AddDays(-(int)date.DayOfWeek);
            for (int i = 0; i < 7; i++)
            {
                weekDates.Add(startDate.AddDays(i));
            }
            if (order.ToLower() == "desc") weekDates.Reverse();
            return weekDates;
        }

        /// <summary>
        /// 获取某个时间近7天数组
        /// </summary>
        /// <param name="order">排序方式</param>
        /// <returns></returns>
        public static List<DateTime> RecentSevenDays(DateTime date, string order = "asc")
        {
            List<DateTime> recentDates = new();
            for (int i = 0; i < 7; i++)
            {
                recentDates.Add(date.Date.AddDays(-i));
            }
            if (order.ToLower() == "asc") recentDates.Reverse();
            return recentDates;
        }

        /// <summary>
        /// 获取某月数组
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="order">排序方式</param>
        /// <returns></returns>
        public static List<DateTime> ThisMonth(DateTime date, string order = "asc")
        {
            List<DateTime> monthDates = new();
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            for (int i = 1; i <= daysInMonth; i++)
            {
                monthDates.Add(new DateTime(date.Year, date.Month, i)); // 将本月的日期加入列表
            }
            if (order.ToLower() == "desc") monthDates.Reverse();
            return monthDates;
        }
        #endregion

        #region 反射
        /// <summary>
        /// 获取某个命名空间下所有类的默认实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="namespace"></param>
        /// <returns></returns>
        public static IEnumerable<T> CreateInstances<T>(string @namespace) where T : class
        {
            var list = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.FullName != null)
            .Where(type => type.FullName!.Contains(@namespace))
            .Where(type => !type.IsAbstract)
            .Select(type =>
            {
                if (Activator.CreateInstance(type) is T instance)
                    return instance;
                return null;
            })
            .Where(i => i != null);
            return list!;
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T">要创建对象的类型</typeparam>
        /// <param name="assemblyName">类型所在程序集名称</param>
        /// <param name="namespace">类型所在命名空间</param>
        /// <param name="className">类型名</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string assemblyName, string @namespace, string className) where T : class
        {
            try
            {
                var assembly = Assembly.Load(assemblyName) ?? throw new Exception("未能找到程序集");
                object? obj = assembly.CreateInstance(@namespace + className, false);
                return obj == null ? throw new Exception("类实例化失败") : (T)obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 反射字段值
        /// </summary>
        /// <param name="obj">反射对象</param>
        /// <param name="propertyName">字段名称</param>
        /// <returns></returns>
        public static T? GetPropValue<T>(object obj, string propertyName)
        {
            try
            {
                if (obj == null) throw new ArgumentNullException(nameof(obj));
                Type type = obj.GetType();
                PropertyInfo propertyInfo = type.GetProperty(propertyName) ?? throw new Exception("类中属性不存在");
                var res = (T?)propertyInfo.GetValue(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 反射字段值
        /// </summary>
        /// <param name="obj">反射对象</param>
        /// <param name="propertyName">字段名称</param>
        /// <returns></returns>
        public static object? GetPropValue(object obj, string propertyName)
        {
            try
            {
                if (obj == null) throw new ArgumentNullException(nameof(obj));
                Type type = obj.GetType();
                PropertyInfo propertyInfo = type.GetProperty(propertyName) ?? throw new Exception("类中属性不存在");
                var res = propertyInfo.GetValue(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 网络请求
        private static readonly HttpClient _httpClient = new();

        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<string> GetAsync(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        _httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        _httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(res) ?? throw new Exception("类型转换失败！");
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="jsonBody">请求body</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, string jsonBody, Dictionary<string, string>? headers = null)
        {
            try
            {
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        content.Headers.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="jsonBody">请求body</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(string url, string jsonBody, Dictionary<string, string>? headers = null)
        {
            try
            {
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        content.Headers.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(res) ?? throw new Exception("类型转换失败！");
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        #endregion

        #region MD5
        /// <summary>
        /// MD5信息摘要
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string str)
        {
            string result = "";
            var buffer = Encoding.UTF8.GetBytes(str);
            var md5 = MD5.HashData(buffer);
            foreach (var item in md5)
            {
                result += item.ToString("x2");
            }
            return result;
        }
        #endregion

        #region AES加密/解密
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static byte[] AESEncrypt(string plainText, byte[] key, byte[] iv)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }
            return msEncrypt.ToArray();
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string AESDecrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream msDecrypt = new(cipherText);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
        #endregion

        #region RSA加密/解密
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static byte[] Encrypt(string plainText, RSAParameters publicKey)
        {
            using RSACryptoServiceProvider rsa = new();
            rsa.ImportParameters(publicKey);
            return rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), true);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string Decrypt(byte[] cipherText, RSAParameters privateKey)
        {
            using RSACryptoServiceProvider rsa = new();
            rsa.ImportParameters(privateKey);
            return Encoding.UTF8.GetString(rsa.Decrypt(cipherText, true));
        }
        #endregion

        #region HttpContext
        /// <summary>
        /// 获取ip
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetIPAddress(this HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress;
            if (ipAddress != null)
            {
                if (ipAddress.IsIPv4MappedToIPv6)
                {
                    ipAddress = ipAddress.MapToIPv4();
                }
            }
            return ipAddress?.ToString() ?? throw new Exception("ip地址获取失败");
        }

        /// <summary>
        /// 绝对url
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetAbsoluteUri(this HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }

        /// <summary>
        /// 获取相对URL
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetRelativeUri(this HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }
        #endregion

        #region 文件夹操作

        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toPath"></param>
        /// <param name="ignoreDir"></param>
        /// <param name="ignoreFile"></param>
        public static void DirCopyTo(string source, string toPath, List<string>? ignoreDir = null, List<string>? ignoreFile = null)
        {
            try
            {
                if (!Directory.Exists(source)) throw new Exception("要移动的目录不存在！");
                if (Directory.Exists(toPath)) throw new Exception("目标目录已存在！");
                Directory.CreateDirectory(toPath);
                var sourceInfo = new DirectoryInfo(source);
                CopyAll(sourceInfo, toPath, ignoreDir, ignoreFile);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toPath"></param>
        /// <param name="ignoreDir"></param>
        /// <param name="ignoreFile"></param>
        public static void DirCopyTo(this DirectoryInfo source, string toPath, List<string>? ignoreDir = null, List<string>? ignoreFile = null)
        {
            try
            {
                if (Directory.Exists(toPath)) throw new Exception("目标目录已存在！");
                Directory.CreateDirectory(toPath);
                //递归复制文件
                CopyAll(source, toPath, ignoreDir, ignoreFile);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 递归复制文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toPath"></param>
        /// <param name="ignoreList"></param>
        private static void CopyAll(DirectoryInfo source, string toPath, List<string>? ignoreDir = null, List<string>? ignoreFile = null)
        {
            //处理文件夹
            var dirs = source.GetDirectories();
            if (dirs != null)
                foreach (var dir in dirs)
                {
                    if (ignoreDir != null && ignoreDir.Contains(dir.Name)) continue;
                    var copyDir = Path.Combine(toPath, dir.Name);
                    Directory.CreateDirectory(copyDir);
                    var childDir = dir.GetDirectories();
                    var childFile = dir.GetFiles();
                    if ((childDir != null && childDir.Length > 0) || (childFile != null && childFile.Length > 0))
                        CopyAll(dir, copyDir, ignoreDir, ignoreFile);
                }

            //处理文件
            var files = source.GetFiles();
            if (files != null)
                foreach (var file in files)
                {
                    if (ignoreFile != null && ignoreFile.Contains(file.Name)) continue;
                    var copyFile = Path.Combine(toPath, file.Name);
                    File.Copy(file.FullName, copyFile);
                }
        }
        #endregion
    }
}