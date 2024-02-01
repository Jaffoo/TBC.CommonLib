namespace TBC.CommonLib
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 电话号码脱敏
        /// </summary>
        /// <param name="phone">电话号码</param>
        /// <param name="num">隐藏几位</param>
        /// <param name="start">开头显示几位</param>
        /// <param name="charStr">隐藏替换符号</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string PhoneHide(string? phone, int num = 5, int start = 3, string charStr = "*")
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
        /// 从身份证号码中提取出生日期
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime BirthdayFromIDCard(string? idCard)
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
        public static string SexFromIDCard(string? idCard)
        {
            try
            {
                char genderChar = idCard![idCard.Length - 2]; // 获取倒数第二位字符
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
        public static int AgeFromIDCard(string? idCard)
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
        /// 获取星座
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetZodiacByIdCard(string idCard)
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
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMonday(DateTime date)
        {
            int daysToSubtract = ((int)date.DayOfWeek - 1 + 7) % 7; // 计算需要减去的天数以获取星期一
            return date.Date.AddDays(-daysToSubtract); // 返回星期一的日期
        }
    }
}