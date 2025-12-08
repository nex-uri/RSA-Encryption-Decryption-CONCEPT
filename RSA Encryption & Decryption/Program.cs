namespace RSA_Encryption___Decryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool looped1 = true;
            while (looped1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===================================RSA Encryption & Decryption===================================\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[HOW TO USE] ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("TYPE '1' to encrypt your desired message or TYPE '2' to decrypt your encrypted message.\n");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[1] ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Encryption");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[2] ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Decryption");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[3] ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Exit");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------------------------------------------------\n");
                Console.ResetColor();

                bool looped2 = true;
                while (looped2)
                {
                    Console.Write("Your Input: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input = Console.ReadLine();
                    Console.ResetColor();

                    if (input != null && input == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[OK] ");
                        Console.ResetColor();
                        Console.WriteLine("Valid Input. Using the encryption tool...\n\n");
                        Console.Clear();

                        bool looped3 = true;
                        while (looped3)
                        {
                            message_value message = new message_value();

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\t===================================RSA Encryption===================================\n");
                            Console.ResetColor();

                            Console.Write("Message Input: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string message_input = Console.ReadLine();
                            Console.ResetColor();
                            Console.Clear();

                            message.message(message_input);

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n---------------------------------------------------------------------------------------------------\n");
                            Console.ResetColor();

                            bool looped4 = true;
                            while (looped4)
                            {
                                Console.Write("Would you like to input your message again? (y/n)");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" (THESE DATA WILL NOT BE SAVED ONCE YOU TYPE 'n/N'.)");
                                Console.ResetColor();
                                Console.Write(": ");

                                Console.ForegroundColor = ConsoleColor.White;
                                string back_option = Console.ReadLine();
                                Console.ResetColor();

                                if (back_option != null && back_option == "y" || back_option == "Y")
                                {
                                    Console.Clear();
                                    looped4 = false;
                                }
                                else if (back_option != null && back_option == "n" || back_option == "N")
                                {
                                    Console.Clear();
                                    looped2 = false;
                                    looped3 = false;
                                    looped4 = false;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("[ERROR] ");
                                    Console.ResetColor();
                                    Console.WriteLine("Invalid Input. Please Try Again.\n\n");
                                }
                            }
                        }
                    }
                    else if (input != null && input == "2")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[OK] ");
                        Console.ResetColor();
                        Console.WriteLine("Valid Input. Using the decryption tool...\n\n");
                        Console.Clear();

                        bool looped3 = true;
                        while (looped3)
                        {
                            decryption_message decrypt = new decryption_message();

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\t===================================RSA Decryption===================================\n");
                            Console.ResetColor();

                            Console.Write("Encrypted Message (e.g. '10203920 2303923 0239320 ...'): ");
                            Console.ForegroundColor = ConsoleColor.White;

                            string enc_mes_input = Console.ReadLine();
                            Console.ResetColor();
                            Console.WriteLine();

                            Console.Write("Decryption Key (e.g. '10203920 2303923'): ");
                            Console.ForegroundColor = ConsoleColor.White;

                            string decr_key_input = Console.ReadLine();
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.Clear();

                            decrypt.add_arr(enc_mes_input);
                            decrypt.data_decryption_message(decr_key_input);

                            Console.WriteLine("\n---------------------------------------------------------------------------------------------------\n");

                            bool looped4 = true;
                            while (looped4)
                            {
                                Console.Write("Would you like to input your message again? (y/n): ");

                                Console.ForegroundColor = ConsoleColor.White;
                                string back_option = Console.ReadLine();
                                Console.ResetColor();

                                if (back_option != null && back_option == "y" || back_option == "Y")
                                {
                                    Console.Clear();
                                    looped4 = false;
                                }
                                else if (back_option != null && back_option == "n" || back_option == "N")
                                {
                                    Console.Clear();
                                    looped2 = false;
                                    looped3 = false;
                                    looped4 = false;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("[ERROR] ");
                                    Console.ResetColor();
                                    Console.WriteLine("Invalid Input. Please Try Again.\n\n");
                                }
                            }
                        }
                    }
                    else if (input != null && input == "3")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n---------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[OK] ");
                        Console.ResetColor();
                        Console.WriteLine("Valid Input. Exiting the program...");

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        looped1 = false;
                        looped2 = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[ERROR] ");
                        Console.ResetColor();
                        Console.WriteLine("Invalid Input. Please Try Again.\n\n");
                    }
                }
            }
        }
    }
}
