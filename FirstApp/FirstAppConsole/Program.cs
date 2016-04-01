using System;

namespace FirstAppConsole
{
    internal class Program
    {
        private static int minValue;
        private static int maxValue;
        private static int currentValue;
        private static int valueToFind;
        private static int tryCounter;

        private static void Main(string[] args)
        {
            var randomGenerator = new Random();
            SetMinValue();

            SetMaxValue();

            valueToFind = randomGenerator.Next(minValue, maxValue);

            Console.WriteLine(@"Une valeur aléatoire à été sélectionnée. Essayez de la trouver.");

            PlayLoop();

            var replay = AskForReplay();

            if (replay)
            {
                tryCounter = 0;
                Main(args);
            }
        }

        private static bool AskForReplay()
        {
            var isInputOk = false;
            var result = false;

            while (!isInputOk)
            {
                Console.WriteLine("voulez vous rejouer ? (Y/N)");
                var replay = Console.ReadLine();

                var isYes = string.Equals(replay, "Y", StringComparison.OrdinalIgnoreCase);
                var isNo = string.Equals(replay, "N", StringComparison.OrdinalIgnoreCase);
                isInputOk = isNo || isYes;

                if (isInputOk)
                {
                    result = isYes ? isYes : false;
                }
            }

            return result;
        }

        private static bool PlayLoop()
        {
            var parseSuccess = false;
            while (currentValue != valueToFind)
            {
                Console.WriteLine(@"Saisir votre valeur.");
                var newValueAsString = Console.ReadLine();
                parseSuccess = int.TryParse(newValueAsString, out currentValue);

                if (!parseSuccess)
                {
                    Console.WriteLine(@"Merci de saisir un entier.\r\n");
                    continue;
                }

                var message = string.Empty;

                if (currentValue < valueToFind)
                {
                    message = "C'est plus grand !\r\n";
                }
                else if (currentValue > valueToFind)
                {
                    message = "C'est plus petit !\r\n";
                }
                else
                {
                    message = $"C'est gagné ! il vous aura fallu {tryCounter + 1} {(tryCounter > 1 ? "coups" : "coup")} \r\n";
                }
                tryCounter++;
                Console.WriteLine(message);
            }

            return parseSuccess;
        }

        private static bool SetMaxValue()
        {
            var parseSuccess = false;

            while (!parseSuccess)
            {
                Console.WriteLine(@"Saisir la valeur maximale:");
                var maxValueString = Console.ReadLine();
                parseSuccess = int.TryParse(maxValueString, out maxValue);

                if (!parseSuccess)
                {
                    Console.WriteLine("Veuillez saisir un entier.");
                }
            }

            return parseSuccess;
        }

        private static bool SetMinValue()
        {
            var parseSuccess = false;

            while (!parseSuccess)
            {
                Console.WriteLine(@"Saisir la valeur minimale:");
                var minValueString = Console.ReadLine();
                parseSuccess = int.TryParse(minValueString, out minValue);

                if (!parseSuccess)
                {
                    Console.WriteLine("Veuillez saisir un entier.");
                }
            }

            return parseSuccess;
        }
    }
}