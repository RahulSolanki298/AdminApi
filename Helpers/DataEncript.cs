using System;
using System.Text;

namespace AdminApi.Helpers
{
    public static class DataEncript
    {
        public static string Key = "adef@@kfxcbv@";
        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            password+=Key;
            var passwordByte=Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordByte);
        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData))
            {
                return "";
            }
            var base64EncodeBytes=Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result=result.Substring(0, result.Length-Key.Length);

            return result;
        }
    }
}
