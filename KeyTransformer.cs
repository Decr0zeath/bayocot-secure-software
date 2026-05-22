using System.Text;

namespace bayocot_secure_software
{
    public static class KeyTransformer
    {
        // Produces a 16-byte AES-128 key from the shared key (0..198 given p=199).
        public static byte[] ToAesKey(int sharedKey)
        {
            string s = sharedKey.ToString();
            string pattern;

            switch (s.Length)
            {
                case 1:
                    pattern = s + "C";       // e.g. "1C"
                    break;
                case 2:
                    pattern = s + "DD";      // e.g. "58DD"
                    break;
                case 3:
                    pattern = s + "F";       // e.g. "109F"
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(sharedKey),
                        "Shared key must be 1-3 digits (0..998).");
            }

            // Repeat pattern until we have at least 16 chars, then take the first 16.
            var sb = new StringBuilder();
            while (sb.Length < 16) sb.Append(pattern);
            string keyString = sb.ToString().Substring(0, 16);

            return Encoding.ASCII.GetBytes(keyString);
        }

        public static string ToDisplayString(byte[] key)
        {
            return Encoding.ASCII.GetString(key);
        }
    }
}
