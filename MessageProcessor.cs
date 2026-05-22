using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bayocot_secure_software
{
    public static class MessageProcessor
    {
        public const int BlockSize = 16;   // 16 chars * 8 bits = 128 bits
        public const char PadChar = '@';

        public static List<string> Chunk(string message)
        {
            var blocks = new List<string>();
            if (string.IsNullOrEmpty(message)) return blocks;

            for (int i = 0; i < message.Length; i += BlockSize)
            {
                int remaining = message.Length - i;
                string block = remaining >= BlockSize
                    ? message.Substring(i, BlockSize)
                    : message.Substring(i).PadRight(BlockSize, PadChar);
                blocks.Add(block);
            }
            return blocks;
        }

        // Reverse the '@' padding from the trailing end of the final block only.
        public static string Unpad(string message)
        {
            return message?.TrimEnd(PadChar) ?? string.Empty;
        }
    }
}
