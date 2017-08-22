using System;

namespace helloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            String userName = Environment.UserName;
            DateTime date = new DateTime(2017, 8, 23, 13, 30, 45);

            //Message message = new Message(8,10,18, date, username);
            //Message message = new Message(date, userName);
            Message message = new Message(date, userName);


            Console.WriteLine("Date with milliseconds: {0:dd/MM/yyy HH:mm:ss}", date);

            String input;
            do
            {
                Console.WriteLine(message.GetHelloMessage);
                Console.WriteLine("Veuillez saisir 'exit' pour quitter et valider avec la touche \"Entrée\"");
                input = Console.ReadLine();
            } while (!input.Equals("exit"));

        }


    }
}
