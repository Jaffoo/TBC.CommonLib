using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Reflection;

namespace TBC.CommonLib;

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
            throw new ArgumentException("Invalid JSON string.");

        var keys = key.Split(':');
        JObject jsonObject = JObject.Parse(str);

        JToken? token = jsonObject;
        foreach (var k in keys)
        {
            token = token[k];
            if (token == null) throw new KeyNotFoundException($"Key '{k}' not found in JSON.");
        }

        return token.ToString();
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
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(predicate);
        var itemsToRemove = list.Where(predicate).ToList();
        foreach (var item in itemsToRemove)
        {
            list.Remove(item);
        }
    }
}
