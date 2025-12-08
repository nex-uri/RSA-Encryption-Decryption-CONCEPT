using System.Numerics;

namespace RSA_Encryption___Decryption
{
    internal class decryption_message
    {
        private readonly char[] _char;
        private readonly long[] ascii_value;
        private long[] decrypted_arr;
        private char[] decrypted_char_arr;
        private string number;
        public int index;
        public int conv_index;
        public int trigger;

        public decryption_message()
        {
            _char =
            [
                // Digits (0-9)
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
    
                // Lowercase Letters (a-z)
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
    
                // Uppercase Letters (A-Z)
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',

                // Punctuation and Symbols 
                '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-',
                '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^',
                '_', '`', '{', '|', '}', '~', ' ' // Note: ' ' is the space character
            ];
            ascii_value =
            [
                // Digits Converted From (0-9)
                48, 49, 50, 51, 52, 53, 54, 55, 56, 57,
    
                // Lowercase Converted From (a-z)
                97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
                110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122,
    
                // Uppercase Converted From (A-Z)
                65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
                81, 82, 83, 84, 85, 86, 87, 88, 89, 90,

                // Punctuation and Symbols Converted From (!-' ')
                33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47,
                58, 59, 60, 61, 62, 63, 64, 91, 92, 93, 94, 95, 96, 123, 124, 125, 126, 32
            ];
            decrypted_arr = Array.Empty<long>();
            decrypted_char_arr = Array.Empty<char>();
            number = "";
            index = -1;
            conv_index = -1;
            trigger = -1;
        }

        private void IncreaseSize()
        {
            long[] new_size_arr = new long[decrypted_arr.Length + 1];
            for (int i = 0; i < decrypted_arr.Length; i++)
            {
                new_size_arr[i] = decrypted_arr[i];
            }
            decrypted_arr = new_size_arr;

            char[] char_new_size_arr = new char[decrypted_arr.Length + 1];
            decrypted_char_arr = char_new_size_arr;
        }
        public void add_arr(string data_arr)
        {
            Console.Clear();
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------");

            foreach (char c in data_arr)
            {
                if (char.IsWhiteSpace(c))
                {
                    index++;
                    IncreaseSize();

                    long converted_value = Convert.ToInt64(number);
                    decrypted_arr[index] = converted_value;
                    number = "";
                    trigger = 0;
                }
                else if (char.IsLetter(c))
                {
                    trigger = -2;
                    break;
                }
                else
                {
                    number += c;
                    trigger = 0;
                }
            }

            if (trigger == 0)
            {
                foreach (char c in number)
                {
                    if (char.IsLetter(c))
                    {
                        trigger = -1;
                        break;
                    }
                }

                if (trigger == 0)
                {
                    index++;
                    IncreaseSize();

                    long converted_value_end = Convert.ToInt64(number);
                    decrypted_arr[index] = converted_value_end;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[ERROR] \t");
                    Console.ResetColor();
                    Console.WriteLine($"Failed to add into an array variable.");
                }
            }
            else if (trigger == -2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[ERROR] \t");
                Console.ResetColor();
                Console.WriteLine($"Failed to add into an array variable.");
            }
            number = "";
            trigger = -1;
        }
        public void data_decryption_message(string prime_key_n, string decryption_key)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[LOG] \t\t");
            Console.ResetColor();
            Console.WriteLine($"Decrypting the message...");

            string prime_key_n_trimmed = prime_key_n.Trim();
            foreach (char c in prime_key_n_trimmed)
            {
                if (char.IsLetter(c))
                {
                    trigger = -1;
                    break;
                }
                else trigger = 0;
            }

            string decryption_key_trimmed = decryption_key.Trim();
            foreach (char c in decryption_key_trimmed)
            {
                if (char.IsLetter(c))
                {
                    trigger = -1;
                    break;
                }
                else trigger = 0;
            }

            if (trigger == 0)
            {
                long prime_key_converted = Convert.ToInt64(prime_key_n_trimmed);
                long decryption_key_converted = Convert.ToInt64(decryption_key_trimmed);

                trigger = -1;

                if (decryption_key_converted != 0)
                {
                    for (int i = 0; i < decrypted_arr.Length; i++)
                    {
                        decrypted_arr[i] = (long)BigInteger.ModPow(decrypted_arr[i], decryption_key_converted, prime_key_converted);

                        if (decrypted_arr[i] > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("[OK] \t\t");
                            Console.ResetColor();
                            Console.WriteLine($"A single encrypted block has been DECRYPTED into message values.");
                            trigger = 0;
                        }
                        else
                        {
                            trigger = -1;
                            break;
                        }
                    }

                    if (trigger == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("[LOG] \t\t");
                        Console.ResetColor();
                        Console.WriteLine($"Sending the data to another instance for an output.");
                        decrypt_message();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[ERROR] \t");
                        Console.ResetColor();
                        Console.WriteLine($"Failed to decrypt.");
                    }

                    trigger = -1;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[ERROR] \t");
                Console.ResetColor();
                Console.WriteLine($"Invalid Input.");
            }
        }
        private void decrypt_message()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[LOG] \t\t");
            Console.ResetColor();
            Console.WriteLine($"Converting of each ASCII value into a character.");

            foreach (long val in decrypted_arr)
            {
                bool found = false;
                for (int i = 0; i < ascii_value.Length; i++)
                {
                    if (ascii_value[i] == val)
                    {
                        conv_index++;
                        decrypted_char_arr[conv_index] = _char[i];

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[OK] \t\t");
                        Console.ResetColor();
                        Console.WriteLine($"A single character has been DECRYPTED.");

                        trigger = 0;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    trigger = -1;
                }
            }
            conv_index = -1;

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
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[ERROR] \t");
                Console.ResetColor();
                Console.WriteLine($"Failed to convert.");
            }

            trigger = -1;
        }
        private void SendData()
        {
            output_ed send_data = new output_ed(decrypted_char_arr);
        }
    }
}
