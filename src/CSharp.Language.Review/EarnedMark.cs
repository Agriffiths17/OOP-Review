﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Language.Review
{
    public class EarnedMark : WeightedMark
    {
        public int Possible { get; private set; }
        private double _Earned;
        public double Earned
        {
            get { return _Earned; }
            set
            {
                if (value < 0 || value > Possible)
                    throw new Exception("Invalid earned mark assigned");
            }
        }
        public double Percent
        { get { return (Earned / Possible) * 100;  } }

        public double WeightedPercent
        { get { return Percent * Weight / 100; } }

        // This constructor calls another constructor
        // BEFORE it runs it's own body of instructions.
        // Hooking up constructors in this fashin is
        // known as "daisy-chaning" your constructor
        // calls.
        public EarnedMark(WeightedMark markableItem, int possible, double earned)
            :this (markableItem.Name, markableItem.Weight, possible,earned)
        {
        }

        public EarnedMark(string name, int weight, int possilbe, double earned)
            :base (name, weight)
        {
            if (Possible <= 0)
                throw new Exception("Invalid possible marks");
            Possible = Possible;
            Earned = earned;
        }
        // Changing the behaviour of the base class by overriding some method
        // is one way taht we accomplish polymorphism
        public override string ToString()
        {
            return string.Format("{0} ({1})\t - {2}% ({3}/{4}) \t- Weighted Mark {5}%",
                Name,
                Weight,
                Percent,
                Earned,
                Possible,
                WeightedPercent);
        }
    }
}
