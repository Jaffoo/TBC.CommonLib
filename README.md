### 打造一个符合每个人需求的通用工具帮助类
 - 扩展方法类，数据类型转换，字符串转其他类型，包括枚举，日期，json，数字，布尔，列表，对象等（Fetch方法支持查找json深层次值，例如传入user:sex，可以获取json对象中的user对象的sex值，可以无限嵌套）；列表转字符串等，具体请查看代码[Convert.cs](https://github.com/Jaffoo/TBC.CommonLib/blob/master/TBF.CommonLib/Convert.cs)
 - 数据校验类，验证字符串是否是空、电话号码、邮箱等，具体请查看代码[Verify.cs](https://github.com/Jaffoo/TBC.CommonLib/blob/master/TBF.CommonLib/Verify.cs)
 - 工具类，敏感信息脱敏、身份证相关方法、时间相关方法、反射、网络请求、md5、AES加密/解密、RSA加密/解密、HttpContext扩展方法、文件夹操作，具体请查看代码[Tools.cs](https://github.com/Jaffoo/TBC.CommonLib/blob/master/TBF.CommonLib/Tools.cs)