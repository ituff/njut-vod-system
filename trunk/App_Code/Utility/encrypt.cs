using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
///encryptcs 的摘要说明
/// </summary>
public class encryptcs
{
    public string Encrypt(string password)
    {
        ///获取Byte数组
        Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
        ///获取Hash值
        Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
        ///获取加密后的信息
        return BitConverter.ToString(hashedBytes);
    }
}