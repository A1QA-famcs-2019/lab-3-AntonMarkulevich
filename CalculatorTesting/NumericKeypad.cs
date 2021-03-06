﻿using CalculatorTesting.Config;
using System;
using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace CalculatorTesting
{
    public class NumericKeypad : BaseWindow
    {
        /// <summary>
        /// List of button objects.
        /// Index in list corresponds to numeric button value.
        /// </summary>
        private readonly List<Button> _buttons;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="window">Window.</param>
        public NumericKeypad(Window window) : base(window)
        {
            _buttons = new List<Button>();
            foreach (string id in ResourceManager.CalculatorKeypadNumericButtonsId)
                _buttons.Add(GetElement<Button>(SearchCriteria.ByAutomationId(id)));
        }

        /// <summary>
        /// Click number button.
        /// </summary>
        /// <param name="value">Button to click: Value from 0 to 9.</param>
        public void EnterNumber(int value)
        {
            if (!(value >= 0 && value <= 9))
                throw new ArgumentException("Value should be in closed range 0..9");
            _buttons[value].Click();

        }

        /// <summary>
        /// Enter number.
        /// </summary>
        /// <param name="value">Number to enter.</param>
        public void EnterNumber(string value)
        {
            foreach (char c in value)
                EnterNumber(c - '0');
        }

    }
}
