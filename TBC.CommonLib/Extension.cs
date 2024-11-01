using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TBC.CommonLib
{

    public static class Extension
    {

        /// <summary>
        /// 获取json字符串的键的值
        /// </summary>
        /// <param name="str">json字符串</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string Fetch(this string str, string key)
        {
            if (!str.IsValidJson())
                throw new ArgumentException("无效的JSON字符串。");

            var keys = key.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            var results = "";

            JObject jsonObject = JObject.Parse(str);

            foreach (var k in keys)
            {
                var nestedKeys = k.Split(':');
                JToken? token = jsonObject;

                foreach (var nestedKey in nestedKeys)
                {
                    token = token?[nestedKey];
                    if (token == null)
                    {
                        throw new KeyNotFoundException($"JSON字符串中找不到键值'{k}'。");
                    }
                }
                results += token.ToString();
            }

            return results;
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
            try
            {
                if (!str.IsValidJson())
                    throw new ArgumentException("无效的JSON字符串。");

                var keys = key.Split(':');
                JObject jsonObject = JObject.Parse(str);

                JToken? token = jsonObject;
                foreach (var k in keys)
                {
                    token = token[k];
                    if (token == null) throw new KeyNotFoundException($"JSON字符串中找不到键值'{key}'。");
                }
                var fin = token.ToObject<T>() ?? throw new InvalidDataException("转换失败！");
                return fin;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 是否是json字符串
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static bool IsValidJson(this string jsonString)
        {
            if (jsonString.IsNullOrWhiteSpace()) return false;
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
            var jsonStr = value.ToJsonStr();
            return jsonStr.ToModel<T>();
        }

        /// <summary>
        /// linq扩展按条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RemoveWhere<T>(this IList<T> list, Func<T, bool> predicate)
        {
            if (list == null || predicate == null) return;
            var itemsToRemove = list.Where(predicate).ToList();
            foreach (var item in itemsToRemove)
            {
                list.Remove(item);
            }
        }
    }
}