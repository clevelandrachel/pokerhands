﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    partial class Hand
    {
        public static Hand.Rank Score(Hand hand)
        {
            // Cascade through score methods until a match is found
            if (Hand.IsStraightFlush(hand))
            {
                return Hand.Rank.StraightFlush;
            }
        }

        private static bool IsStraightFlush(Hand hand)
        {
            int previousValue = hand[0].Value;
            char previousSuit = hand[0].Suit;

            for (int cardIndex = 1; cardIndex < 5; cardIndex++)
            {
                int currentValue = hand[cardIndex].Value;
                char currentSuit = hand[cardIndex].Suit;

                if (((currentValue - previousValue) != 1) || (previousSuit != currentSuit))
                {
                    // If the values aren't consecutive or the suits aren't the same
                    return false;
                }

                previousValue = currentValue;
                previousSuit = currentSuit;
            }

            return true;
        }
    }
}
