using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberBLL
{
    public class GtnBLL : IGuessService
    {
        private int minValue;
        private int maxValue;
        private Random randomGenerator = new Random();

        public int currentValue { get; set; }
        public int ValueToFind { get; private set; }
        public bool HasWin
        {
            get
            {
                return currentValue == ValueToFind;
            }
        }

        public int TryCounter{ get; set; }

        public event Action OnWin;
        public event Action OnToLow;
        public event Action OnToHigh;

        public bool AskForReplay()
        {
            throw new NotImplementedException();
        }
        
        public bool SetMaxValue(string maxValueString)
        {
            return int.TryParse(maxValueString, out maxValue);
        }

        public bool SetMinValue(string minValueString)
        {
            return int.TryParse(minValueString, out minValue);
        }

        public bool SetCurrentValue(string currentValueString)
        {
            int value;
            var result = int.TryParse(currentValueString, out value);
            currentValue = value;
            return result;
        }

        public void SetRandomValue()
        {
            ValueToFind = randomGenerator.Next(minValue, maxValue);
        }

        public void processValues()
        {
            TryCounter++;

            if (currentValue < ValueToFind)
            {
                OnToLow?.Invoke();
            }
            else if (currentValue > ValueToFind)
            {
                OnToHigh?.Invoke();
            }
            else
            {
                OnWin?.Invoke();
            }
        }
    }
}
