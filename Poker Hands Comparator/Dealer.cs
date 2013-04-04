﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Poker_Hands_Comparator
{
    class Dealer
    {
        public Hand GetValidHandOrDieTrying()
        {
            while (true)
            {
                string handString = this.promptForHand();

                if (this.validateHand(handString))
                {
                    this.thankUser();
                    return Hand.ConstructFromUnsanitisedValidatedInput(handString);
                }

                this.chastiseUser();
            }
        }

        private string promptForHand()
        {
            Console.WriteLine("Enter hand");
            Console.Write("> ");
            return Console.ReadLine();
        }

        private void thankUser()
        {
            Console.WriteLine("A valid hand - thanks!");
            Console.WriteLine();
        }

        private void chastiseUser()
        {
            Console.WriteLine("That's not a valid hand and you know it. C'mon now.");
            Console.WriteLine();
        }

        private bool validateHand(string handString)
        {
            string validHandPattern = @"^([1-9TJQKA] *[CDHS] *){5}$";
            RegexOptions options = RegexOptions.IgnoreCase;

            Match match = Regex.Match(handString, validHandPattern, options);

            return match.Success;
        }
    }
}