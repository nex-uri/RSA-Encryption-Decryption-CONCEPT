using System.Reflection.PortableExecutable;

namespace RSA_Encryption___Decryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            message_value message = new message_value();
            message.message("Josh");

            //foreach (var debug in message.DEBUG_value_display())
            //{
            //    Console.WriteLine(debug);   
            //}

        }
    }
}
