using GuessTheNumberBLL;
using System;

namespace FirstAppConsole
{
    internal class Program
    {
        private static IGuessService guessService;

        private static void Main(string[] args)
        {
            var randomGenerator = new Random();

            guessService = new GtnBLL();
            guessService.OnWin += GuessService_OnWin;
            guessService.OnToLow += GuessService_OnToLow;
            guessService.OnToHigh += GuessService_OnToHigh;

            SetMinValue();

            SetMaxValue();

            guessService.SetRandomValue();

            Console.WriteLine(@"Une valeur aléatoire à été sélectionnée. Essayez de la trouver.");

            PlayLoop();
        }

        private static void GuessService_OnToHigh()
        {
            Console.WriteLine("C'est plus petit !\r\n");
            PlayLoop();
        }

        private static void GuessService_OnToLow()
        {
            Console.WriteLine("C'est plus grand !\r\n");
            PlayLoop();
        }

        private static void GuessService_OnWin()
        {
            Console.WriteLine($"C'est gagné ! il vous aura fallu {guessService.TryCounter}\r\n");
            AskForReplay();
        }

        private static void AskForReplay()
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

            if(result)
            {
                guessService.TryCounter = 0;
                Main(null);
            }
        }

        private static void PlayLoop()
        {
            var parseSuccess = false;

            Console.WriteLine(@"Saisir votre valeur.");
            var newValueAsString = Console.ReadLine();
            parseSuccess = guessService.SetCurrentValue(newValueAsString);

            if (!parseSuccess)
            {
                Console.WriteLine(@"Merci de saisir un entier.\r\n");
                PlayLoop();
            }

            guessService.processValues();
        }

        private static bool SetMaxValue()
        {
            var parseSuccess = false;

            while (!parseSuccess)
            {
                Console.WriteLine(@"Saisir la valeur maximale:");
                var maxValueString = Console.ReadLine();
                parseSuccess = guessService.SetMaxValue(maxValueString);

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
                parseSuccess = guessService.SetMinValue(minValueString);

                if (!parseSuccess)
                {
                    Console.WriteLine("Veuillez saisir un entier.");
                }
            }

            return parseSuccess;
        }
    }
}