namespace RSA_Encryption___Decryption
{
    internal class decryption_generator
    {
        private readonly long[] receiver_data_arr;
        private readonly long receiver_prime_e;
        private readonly long receiver_prime_n;
        private readonly long receiver_prime_on;
        private long prime_d;

        public decryption_generator(long encryption_key, long prime_key_on, long prime_key_n, long[] data_arr)
        {
            receiver_data_arr = data_arr;
            receiver_prime_e = encryption_key;
            receiver_prime_n = prime_key_n;
            receiver_prime_on = prime_key_on;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[OK] \t\t");
            Console.ResetColor();
            Console.WriteLine($"The data has been SENT to the instance.");
            data_decryption_key_gen();
        }
        public long priv_prime_d
        {
            get
            {
                return prime_d;
            }
            set
            {
                prime_d = value;
            }
        }
        public void data_decryption_key_gen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[LOG] \t\t");
            Console.ResetColor();
            Console.WriteLine($"Generating decryption key...");

            long a = receiver_prime_on;
            long b = receiver_prime_e;

            long x0 = 0; 
            long x1 = 1; 

            while (b != 0)
            {
                long quotient = a / b;
                long remainder = a % b;

                a = b;
                b = remainder;

                long temp_x = x1;

                x1 = x0 - quotient * x1;
                x0 = temp_x;
            }
            if (x0 < 0)
            {
                x0 += receiver_prime_on;
            }

            prime_d = x0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[SUCCESS] \t");
            Console.ResetColor();
            Console.WriteLine($"The decryption key has been GENERATED. {prime_d}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[LOG] \t\t");
            Console.ResetColor();
            Console.WriteLine($"Sending the data to another instance in order to encrypt the message.");
            Send_Data();
        }
        public void Send_Data()
        {
            encryption_message send_data = new encryption_message(receiver_prime_e, prime_d, receiver_prime_n, receiver_data_arr);
        }
    }
}
