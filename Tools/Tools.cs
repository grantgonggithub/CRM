/*----------------------------------------------------------------
Copyright (C) 2014 宏图会员管理系统（Grant 巩建春）

项目名称： 宏图会员管理系统
创建者：   grant (巩建春 emaill : nnn987@126.com ; QQ:406333743;Tel:+86 15619212255)
CLR版本：  4.0.30319.42000
时间：     2014/8/28 18:16:22

功能描述：本软件为本人业余时间所写，其所有源码都可以进行免费的学习交流，切勿用于商业用途

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Tools
{
   public class Tools
    {
       private readonly static string passWord = "gongjianchun!@#$%^&*()brysjhhrhl";
        /// <summary>
        /// 密码MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(String str)
        {
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
                pwd = pwd + s[i].ToString("X");
            return pwd;
        }

        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }
        public static string Encrypt(string clearText)
        {
           return Encrypt(clearText,passWord);
        }

        public static string Encrypt(string clearText, string Password)
        {
            byte[] clearBytes =
              System.Text.Encoding.Unicode.GetBytes(clearText);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
	            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            byte[] encryptedData = Encrypt(clearBytes,
                     pdb.GetBytes(32), pdb.GetBytes(16));


            return Convert.ToBase64String(encryptedData);
        }

        private static byte[] Decrypt(byte[] cipherData,
                                    byte[] Key, byte[] IV)
        {

            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms,
                alg.CreateDecryptor(), CryptoStreamMode.Write);
            // Write the data and make it do the decryption
            cs.Write(cipherData, 0, cipherData.Length);

            cs.Close();

            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }

        public static string Decrypt(string cipherText)
        {
            return Decrypt(cipherText, passWord);
        }

        public static string Decrypt(string cipherText, string Password)
        {

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
	            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            byte[] decryptedData = Decrypt(cipherBytes,
               pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }
    }
}
