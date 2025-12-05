namespace RSA_Encryption___Decryption
{
    internal class output_ed
    {
        private readonly long receiver_prime_d;
        private readonly long[] receiver_encrypted_arr;

        public output_ed(long decryption_key, long[] data_arr)
        {
            receiver_prime_d = decryption_key;
            receiver_encrypted_arr = data_arr;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[OK] \t\t");
            Console.ResetColor();
            Console.WriteLine($"The data has been SENT to the instance.");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            enc_data_output();
        }
        public void enc_data_output()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\t===================================Output===================================\n");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.Write("[ENCRYPTED MESSAGE] \t");
            Console.ResetColor();
            for (int i = 0; i < receiver_encrypted_arr.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(receiver_encrypted_arr[i]);
                Console.ResetColor();
            }
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[DECRYPTION KEY] \t");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{receiver_prime_d}");
            Console.ResetColor();
        }
    }
}
