﻿using System;

namespace GuessTheNumberBLL
{
    public interface IGuessService
    {
        bool AskForReplay();

        bool SetCurrentValue(string currentValueString);

        bool SetMaxValue(string maxValueString);

        bool SetMinValue(string minValueString);

        void SetRandomValue();

        void processValues();

        event Action OnWin;

        event Action OnToLow;

        event Action OnToHigh;

        bool HasWin { get; }

        int TryCounter { get; set; }
    }
}