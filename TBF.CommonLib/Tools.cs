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
            if (!phone.IsMobile()) throw new ArgumentException("电话号码格式错误");
            if (start >= 11) start = 3;
            if (num + start >= 11) num = 11 - start;
            var numStr = phone!.Substring(start, num);
            charStr = new string(charStr[0], num);
            var result = phone.Replace(numStr, charStr);
            return result;
        }

        /// <summary>
        /// 从身份证号码中提取出生日期
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTime BirthdayFromIDCard(string? idCard)
        {
            if (!idCard.IsIDCard()) throw new ArgumentException("身份证号码格式错误");

            string birthdayPart = idCard!.Substring(6, 8);
            int year = birthdayPart.Substring(0, 4).ToInt();
            int month = birthdayPart.Substring(4, 2).ToInt();
            int day = birthdayPart.Substring(6, 2).ToInt();

            var birthday = new DateTime(year, month, day);
            return birthday;
        }

        /// <summary>
        /// 从身份证号码中提取性别
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string SexFromIDCard(string? idCard)
        {
            if (!idCard.IsIDCard()) throw new ArgumentException("身份证号码格式错误");

            char genderChar = idCard![idCard.Length - 2]; // 获取倒数第二位字符
            if (genderChar % 2 == 0) return "女";
            else return "男";
        }

        /// <summary>
        /// 身份证号码中计算年龄
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        public static int AgeFromIDCard(string? idCard)
        {
            if (!idCard.IsIDCard()) throw new ArgumentException("身份证号码格式错误");
            var birthday = BirthdayFromIDCard(idCard);
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthday.Year;
            if (currentDate < birthday.AddYears(age))
                age--;
            return age;
        }
    }
}