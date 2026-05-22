using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bayocot_secure_software
{
    public static class AesEncryption
    {
        public static byte[] EncryptBlock(byte[] plaintext16, byte[] key16)
        {
            if (plaintext16.Length != 16) throw new ArgumentException("Block must be 16 bytes.");
            if (key16.Length != 16) throw new ArgumentException("Key must be 16 bytes.");

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.None;
                aes.Key = key16;

                using (var enc = aes.CreateEncryptor())
                    return enc.TransformFinalBlock(plaintext16, 0, plaintext16.Length);
            }
        }

        // Encrypts each sub-message separately and returns the concatenated ciphertext bytes.
        public static byte[] EncryptMessage(List<string> blocks, byte[] key16)
        {
            var output = new List<byte>(blocks.Count * 16);
            foreach (string block in blocks)
            {
                byte[] pt = Encoding.ASCII.GetBytes(block);
                byte[] ct = EncryptBlock(pt, key16);
                output.AddRange(ct);
            }
            return output.ToArray();
        }

        public static string ToHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 3);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i > 0 && i % 16 == 0) sb.AppendLine();
                sb.Append(bytes[i].ToString("X2")).Append(' ');
            }
            return sb.ToString().TrimEnd();
        }

        public static byte[] DecryptBlock(byte[] ciphertext16, byte[] key16)
        {
            if (ciphertext16.Length != 16) throw new ArgumentException("Block must be 16 bytes.");
            if (key16.Length != 16) throw new ArgumentException("Key must be 16 bytes.");

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.None;
                aes.Key = key16;

                using (var dec = aes.CreateDecryptor())
                    return dec.TransformFinalBlock(ciphertext16, 0, ciphertext16.Length);
            }
        }

        public static string DecryptMessage(byte[] ciphertext, byte[] key16)
        {
            if (ciphertext.Length % 16 != 0)
                throw new ArgumentException("Ciphertext length must be a multiple of 16 bytes.");

            var sb = new StringBuilder();
            for (int i = 0; i < ciphertext.Length; i += 16)
            {
                byte[] block = new byte[16];
                Array.Copy(ciphertext, i, block, 0, 16);
                byte[] pt = DecryptBlock(block, key16);
                sb.Append(Encoding.ASCII.GetString(pt));
            }
            return sb.ToString();
        }
    }
}
