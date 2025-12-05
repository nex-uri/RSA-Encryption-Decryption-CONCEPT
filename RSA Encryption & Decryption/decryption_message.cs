using System.Numerics;

namespace RSA_Encryption___Decryption
{
    internal class decryption_message
    {
        private readonly long receiver_prime_d;
        private readonly long receiver_prime_n;
        private readonly long[] receiver_encrypted_arr;
        private long[] decrypted_arr;

        public decryption_message(long decryption_key, long prime_key_n, long[] data_arr)
        {
            receiver_prime_d = decryption_key;
            receiver_prime_n = prime_key_n;
            receiver_encrypted_arr = data_arr;
        }
        public void data_decryption_message(long decryption_key)
        {
            int trigger = -1;

            Console.WriteLine("\n---------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[LOG] \t\t");
            Console.ResetColor();
            Console.WriteLine($"Decrypting the message...");

            if (decryption_key == receiver_prime_d && receiver_prime_d != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[OK] \t\t");
                Console.ResetColor();
                Console.WriteLine($"The inputted decryption key MATCHES with the system-made key.");

                for (int i = 0; i < receiver_encrypted_arr.Length; i++)
                {
                    decrypted_arr[i] = (long)BigInteger.ModPow(receiver_encrypted_arr[i], receiver_prime_d, receiver_prime_n);

                    if (decrypted_arr[i] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[OK] \t\t");
                        Console.ResetColor();
                        Console.WriteLine($"A single character has been DECRYPTED.");
                        trigger = 0;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[ERROR] \t\t");
                        Console.ResetColor();
                        Console.WriteLine($"Failed to decrypt.");
                        trigger = -1;
                        break;
                    }
                }

                if (trigger == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[SUCCESS] \t");
                    Console.ResetColor();
                    Console.WriteLine($"The message has been DECRYPTED.");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[LOG] \t\t");
                    Console.ResetColor();
                    Console.WriteLine($"Sending the data to another instance for an output.");
                    SendData();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[ERROR] \t");
                Console.ResetColor();
                Console.WriteLine($"The inputted decryption key DOES NOT MATCH with the system-made key.");
            }
        }
        public void SendData()
        {
            message_value send_data = new message_value(decrypted_arr);
        }
    }
}
