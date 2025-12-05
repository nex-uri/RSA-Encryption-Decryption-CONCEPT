using System.Numerics;

namespace RSA_Encryption___Decryption
{
    internal class encryption_message
    {
        private readonly long[] receiver_data_arr;
        private readonly long receiver_prime_e;
        private readonly long receiver_prime_d;
        private readonly long receiver_prime_n;
        private long[] encrypted_arr;

        public encryption_message(long encryption_key, long decryption_key, long prime_key_n, long[] data_arr)
        {
            receiver_data_arr = data_arr;
            receiver_prime_e = encryption_key;
            receiver_prime_d = decryption_key;
            receiver_prime_n = prime_key_n;

            encrypted_arr = new long[receiver_data_arr.Length];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SUCCESS: ");
            Console.ResetColor();
            Console.WriteLine($"The data has been SENT to the instance.");
            data_encryption_message();
        }
        public void data_encryption_message()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LOG: ");
            Console.ResetColor();
            Console.WriteLine($"Encrypting the message...");

            for (int i = 0; i < receiver_data_arr.Length; i++)
            {
                encrypted_arr[i] = (long)(BigInteger.ModPow(receiver_data_arr[i], receiver_prime_e, receiver_prime_n));

                if (encrypted_arr[i] > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("SUCCESS: ");
                    Console.ResetColor();
                    Console.WriteLine($"A single character has been ENCRYPTED.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ERROR: ");
                    Console.ResetColor();
                    Console.WriteLine($"Failed to encrypt.");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("LOG: ");
                    Console.ResetColor();
                    Console.WriteLine($"This application will forcefully close in 3 seconds...");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SUCCESS: ");
            Console.ResetColor();
            Console.WriteLine($"The message has been ENCRYPTED");
        }
    }
}
