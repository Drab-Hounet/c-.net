using System;
using System.Linq;

namespace helloWorld
{
    class Message
    {
        private int hourMorning;
        private int hourAfternoon;
        private int hourEvening;
        private DateTime date;
        private String userName;

        public Message(int hourMorning, int hourAfternoon, int hourEvening, DateTime date, String username)
        {
            this.hourMorning = hourMorning;
            this.hourAfternoon = hourAfternoon;
            this.hourEvening = hourEvening;
            this.date = date;
            this.userName = username;
        }

        public Message(DateTime date, String username)
        {
            hourMorning = 8;
            hourAfternoon = 13;
            hourEvening = 18;
            this.date = date;
            userName = username;
        }

        public String GetUser
        {
            get
            {
                String nameFormatted = "";
                String[] name = userName.Split('.');

                foreach (String nameSplitted in name)
                {
                    if (nameFormatted.Equals(""))
                    {
                        nameFormatted = UpperFirstLetter(nameSplitted);
                    }
                    else
                    {
                        nameFormatted = nameFormatted + " " + UpperFirstLetter(nameSplitted);
                    }
                    Console.WriteLine(nameFormatted);
                }

                return nameFormatted;
            }
        }

        private String UpperFirstLetter(String name)
        {
            char[] letters = name.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new String(letters);
        }

        public String GetHelloMessage
        {
            get
            {
                String type = getTypeHourOfDay(date);
                String messageToSend = "erreur";
                switch (type)
                {
                    case "morning":
                        messageToSend = "Bonjour";
                        break;
                    case "afternoon":
                        messageToSend = "Bon aprés midi";
                        break;
                    case "evening":
                        messageToSend = "Bonne soirée";
                        break;
                    case "weekend":
                        messageToSend = "Bon week-end";
                        break;
                }
                return messageToSend + " " + GetUser;
            }
        }

        public String getTypeHourOfDay(DateTime date)
        {
            String type = "erreur";

            if ((int)date.DayOfWeek > 5 || (date.DayOfWeek.Equals(DayOfWeek.Friday) && date.Hour >= hourEvening))
            {
                type = "weekend";
            }
            else if ((int)date.DayOfWeek <= 5)
            {
                if (date.Hour >= hourMorning && date.Hour <= hourAfternoon)
                {
                    type = "morning";
                }
                else if (date.Hour > hourAfternoon && date.Hour <= hourEvening)
                {
                    type = "afternoon";
                }
                else
                {
                    type = "evening";
                }
            }
            return type;
        }

    }
}
