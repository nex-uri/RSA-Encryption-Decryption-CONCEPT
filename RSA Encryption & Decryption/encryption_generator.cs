namespace RSA_Encryption___Decryption
{
    internal class encryption_generator
    {
        private readonly int receiver_prime_p;
        private readonly int receiver_prime_on;
        private int prime_e;

        public encryption_generator(int prime_key_p, int prime_key_on)
        {
            receiver_prime_p = prime_key_p;
            receiver_prime_on = prime_key_on;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SUCCESS: ");
            Console.ResetColor();
            Console.WriteLine($"The data has been SENT to the instance.");
            data_encryption_key_gen();
        }
        public int priv_prime_e
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
            Console.Write("LOG: ");
            Console.ResetColor();
            Console.WriteLine($"Generating encryption key...");

            for (int i = receiver_prime_p; i < receiver_prime_on; i++)
            {
                bool looped = true;
                int dividend = receiver_prime_on;
                int divisor = i;
                int quotient = 0;
                int remainder = 0;
                while (looped)
                {
                    quotient = dividend / divisor;
                    remainder = dividend % divisor;

                    dividend = divisor;
                    divisor = quotient;

                    if (divisor == 0 || remainder == 1 || remainder == 0)
                    {
                        looped = false;
                    }
                }

                if (remainder == 1)
                {
                    prime_e = i;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("SUCCESS: ");
                    Console.ResetColor();
                    Console.WriteLine($"The encryption key has been GENERATED.");
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("LOG: ");
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

        }
    }
}
