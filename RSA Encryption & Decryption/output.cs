namespace RSA_Encryption___Decryption
{
    internal class output_ed
    {
        private readonly long receiver_prime_d;
        private readonly long receiver_prime_n;
        private readonly long[] receiver_encrypted_arr;
        private readonly char[] receiver_decrypted_arr;

        public output_ed(long decryption_key, long prime_key_n, long[] data_arr)
        {
            receiver_prime_d = decryption_key;
            receiver_prime_n = prime_key_n;
            receiver_encrypted_arr = data_arr;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[OK] \t\t");
            Console.ResetColor();
            Console.WriteLine($"The data has been SENT to the instance.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            enc_data_output();
        }
        public output_ed(char[] decrypted_arr)
        {
            receiver_decrypted_arr = decrypted_arr;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[OK] \t\t");
            Console.ResetColor();
            Console.WriteLine($"The data has been SENT to the instance.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            dec_data_output();
        }

        private void enc_data_output()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\t===================================Output===================================\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[DISCLAIMER] ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("DO NOT share these to others in public as they may decrypt and retrieve your data.\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[ENCRYPTED MESSAGE] \t");
            Console.ResetColor();

            foreach (long c in receiver_encrypted_arr)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{c} ");
                Console.ResetColor();
            }

            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[PUBLIC KEY] \t\t");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{receiver_prime_n}\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[DECRYPTION KEY] \t");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{receiver_prime_d}");
            Console.ResetColor();
        }
        private void dec_data_output()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\t===================================Output===================================\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[DECRYPTED MESSAGE] \t");
            Console.ResetColor();

            foreach (char c in receiver_decrypted_arr)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(c);
                Console.ResetColor();
            }
        }
    }
}
