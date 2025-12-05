namespace RSA_Encryption___Decryption
{
    internal class prime_keys_generator
    {
        private readonly long[] receiver_data_arr;
        private readonly static Random random = new Random();
        private List<long> prime_numbers_list = new List<long>();
        private long prime_p;
        private long prime_q;
        private long prime_n;
        private long prime_on;

        public prime_keys_generator(long[] arr)
        {
            if (arr is long[])
            {
                receiver_data_arr = arr;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[OK] \t\t");
                Console.ResetColor();
                Console.WriteLine($"The data has been SENT to the instance.");
                data_largest_value();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[ERROR] \t\t");
                Console.ResetColor();
                Console.WriteLine($"The data is invalid to a specified variable.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[LOG] \t\t");
                Console.ResetColor();
                Console.WriteLine($"This application will forcefully close in 3 seconds...");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
        public long priv_prime_p
        {
            get
            {
                return prime_p;
            }
            set
            {
                prime_p = value;
            }
        }
        public long priv_prime_q
        {
            get
            {
                return prime_q;
            }
            set
            {
                prime_q = value;
            }
        }
        public long priv_prime_n
        {
            get
            {
                return prime_n;
            }
            set
            {
                prime_n = value;
            }
        }
        public long priv_prime_on
        {
            get
            {
                return prime_on;
            }
            set
            {
                prime_on = value;
            }
        }
        public void data_largest_value()
        {
            if (receiver_data_arr.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[ERROR] \t");
                Console.ResetColor();
                Console.WriteLine($"The data is empty.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[LOG] \t\t");
                Console.ResetColor();
                Console.WriteLine($"This application will forcefully close in 3 seconds...");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            else
            {
                long biggest_value = receiver_data_arr[0];
                for (int i = 0; i < receiver_data_arr.Length; i++)
                {
                    if (biggest_value < receiver_data_arr[i])
                    {
                        biggest_value = receiver_data_arr[i];
                    }
                }
                data_prime_numbers_generator(biggest_value);
            }
        }
        public void data_prime_numbers_generator(long limit)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[LOG] \t\t");
            Console.ResetColor();
            Console.WriteLine($"Generating prime keys...");

            long max = limit * limit;
            bool[] isPrime = new bool[max + 1];
            for (int i = 2; i <= max; i++)
            {
                isPrime[i] = true;
            }

            for (int p = 2; p * p <= max; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= max; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
                else continue;
            }

            for (int i = 2; i <= max; i++)
            {
                if (isPrime[i] && i > limit * 5) //The "limit" is multiplied by 5 to ensure 
                {                                //that the encryption remains secure AT LEAST.
                    prime_numbers_list.Add(i);
                }
                else continue;
            }
            data_prime_keys_gen();
        }
        public void data_prime_keys_gen()
        {
            int prime_random = random.Next(0, prime_numbers_list.Count - 1);
            if (prime_random == 0)
            {
                prime_p = prime_numbers_list[prime_random];
                prime_q = prime_numbers_list[prime_random * 3];
            }
            else if (prime_random == prime_numbers_list.Count - 1)
            {
                prime_p = prime_numbers_list[prime_random / 3];
                prime_q = prime_numbers_list[prime_random];
            }
            else
            {
                prime_p = prime_numbers_list[prime_random];

                int prime_random_2 = random.Next(prime_random, prime_numbers_list.Count - 1);
                prime_q = prime_numbers_list[prime_random_2];
            }

            prime_n = prime_p * prime_q;
            prime_on = (prime_p - 1) * (prime_q - 1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[SUCCESS] \t");
            Console.ResetColor();
            Console.WriteLine($"The prime keys have been GENERATED. {prime_p} {prime_q} {prime_on}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[LOG] \t\t");
            Console.ResetColor();
            Console.WriteLine($"Sending the data to another instance in order to generate encryption key.");
            SendData();
        }
        public void SendData()
        {
            encryption_generator send_data_p = new encryption_generator(prime_p, prime_on, prime_n, receiver_data_arr);
        }
    }
}
