using System.Numerics;

namespace bayocot_secure_software
{
    internal class DiffieHellman
    {
        // Per spec
        public const int P = 199;
        public const int G = 127;

        // Public value = g^privateKey mod p
        public static int ComputePublicValue(int privateKey)
        {
            return (int)BigInteger.ModPow(G, privateKey, P);
        }

        // Shared key = otherPublicValue^myPrivateKey mod p
        public static int ComputeSharedKey(int otherPublicValue, int myPrivateKey)
        {
            return (int)BigInteger.ModPow(otherPublicValue, myPrivateKey, P);
        }
    }
}
