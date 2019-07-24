using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomCMS.Infrastructure.Helper
{
    public class PasswordHelper
    {
        #region Convert Base64 Encode Format

        /// <summary>
        /// Encode String To Base64 format
        /// </summary>
        /// <param name="sData">sData</param>
        /// <returns></returns>
        public static string base64Encode(string sData) // Encode
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        #endregion

        #region Convert Bae64 Decode Format
        /// <summary>
        /// Decode Base64 To string
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string base64Decode(string sData) //Decode
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
        #endregion


        //Link Ref : https://www.aspsnippets.com/Articles/AES-Encryption-Decryption-Cryptography-Tutorial-with-example-in-ASPNet-using-C-and-VBNet.aspx
        #region Encrypt text using AES 

        /// <summary>
        /// This Method is use for Encrypt Cipher text or string using AES
        /// </summary>
        /// <param name="cipherText">CipherText or string to encrypt</param>
        /// <returns></returns>
        public static string Encrypt(string cipherText) // Encode
        {
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] clearBytes = Encoding.Unicode.GetBytes(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        cipherText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Encrypt" + ex.Message);
            }
        }
        #endregion

        #region Decrypt text using AES 

        /// <summary>
        /// This Method is use for Decrypt the Cipher text or string using AES
        /// </summary>
        /// <param name="cipherText">CipherText or string to Decrypt</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText) //Decode
        {
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Decrypt" + ex.Message);
            }
        }
        #endregion
    }
}
