namespace RSA_Encryption___Decryption
{
    internal class message_value
    {
        private readonly char[] _char;
        private readonly int[] ascii_value;
        private int[] value;
        public int index;

        public message_value()
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
            value = Array.Empty<int>();
            index = -1;
        }

        public void IncreaseSize()
        {
            int[] new_size_arr = new int[value.Length + 1];
            for (int i = 0; i < value.Length; i++)
            {
                new_size_arr[i] = value[i];
            }
            value = new_size_arr;
        }
        public void DecreaseSize()
        {
            int[] new_size_arr = new int[value.Length - 1];
            for (int i = 0; i < new_size_arr.Length; i++)
            {
                new_size_arr[i] = value[i];
            }
            value = new_size_arr;
        }
        public void message(string input)
        {
            if (input is string)
            {
                foreach (char c in input)
                {
                    for (int i = 0; i < _char.Length; i++)
                    {
                        if (c == _char[i] && index < value.Length)
                        {
                            index++;
                            IncreaseSize();

                            value[index] = ascii_value[i];
                            break;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("LOG: ");
                Console.ResetColor();
                Console.WriteLine($"Sending the data to another instance in order to generate prime keys.");
                SendData();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERROR: ");
                Console.ResetColor();
                Console.WriteLine($"The inputted text does not support to any character from Windows.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("LOG: ");
                Console.ResetColor();
                Console.WriteLine($"This application will forcefully close in 3 seconds...");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
        public void SendData()
        {
            prime_keys_generator send_data = new prime_keys_generator(value);
        }
    }
}
