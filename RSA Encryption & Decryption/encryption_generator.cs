namespace RSA_Encryption___Decryption
{
    internal class encryption_generator
    {
        private readonly long[] receiver_data_arr;
        private readonly long receiver_prime_p;
        private readonly long receiver_prime_n;
        private readonly long receiver_prime_on;
        private long prime_e;

        public encryption_generator(long prime_key_p, long prime_key_on, long prime_key_n, long[] data_arr)
        {
            receiver_prime_p = prime_key_p;
            receiver_prime_n = prime_key_n;
            receiver_prime_on = prime_key_on;
            receiver_data_arr = data_arr;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[OK] \t\t");
            Console.ResetColor();
            Console.WriteLine($"The data has been SENT to the instance.");
            data_encryption_key_gen();
        }
        public long priv_prime_e
        {
            get
            {
                return prime_e;
            }
            set
            {
                prime_e = value;
            }
        }
        public void data_encryption_key_gen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[LOG] \t\t");
            Console.ResetColor();
            Console.WriteLine($"Generating encryption key...");

            for (long i = receiver_prime_p; i < receiver_prime_on; i++)
            {
                bool looped = true;
                long dividend = receiver_prime_on;
                long divisor = i;
                long quotient = 0;
                long remainder = 0;
                while (looped)
                {
                    quotient = dividend / divisor;
                    remainder = dividend % divisor;

                    dividend = divisor;
                    divisor = remainder;

                    if (remainder == 1 || remainder == 0)
                    {
                        looped = false;
                    }
                }

                if (remainder == 1)
                {
                    prime_e = i;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[SUCCESS] \t");
                    Console.ResetColor();
                    Console.WriteLine($"The encryption key has been GENERATED. {prime_e}");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[LOG] \t\t");
                    Console.ResetColor();
                    Console.WriteLine($"Sending the data to another instance in order to generate decryption key.");
                    SendData();
                    break;
                }
                else if (remainder == 0) continue;
            }
        }
        public void SendData()
        {
            decryption_generator send_data_e = new decryption_generator(prime_e, receiver_prime_on, receiver_prime_n, receiver_data_arr);
        }
    }
}
