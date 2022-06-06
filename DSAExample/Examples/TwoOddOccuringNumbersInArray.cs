// -----------------------------------------------------------------------
//   <copyright file=TwoOddOccuringNumbersInArray.cs>
//      Copyright © 2022. All Rights Reserved.
//   </copyright>
// -----------------------------------------------------------------------
//  <Author>Vaibhav Lawand</Author>

using DSAExample.Interfaces;

namespace DSAExample.Examples
{
    public class TwoOddOccuringNumbersInArray : ISupportExample
    {
        #region Public Properties

        public string Description => "Find Two Odd occuring numbers in array";

        #endregion Public Properties

        #region Public Methods

        public void Run()
        {
            int[] numbers = new int[10] { 2, 4, 2, 4, 5, 8, 5, 8, 4, 5 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]}    ");
            }

            int xorOfAll = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                xorOfAll ^= numbers[i];
            }

            int rightBit = xorOfAll & (~(xorOfAll - 1));
            int x = 0, y = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if ((numbers[i] & rightBit) != 0)
                {
                    x ^= numbers[i];
                }
                else
                {
                    y ^= numbers[i];
                }
            }

            Console.WriteLine($"\nTwo Numbers are {x} and {y}");
        }

        #endregion Public Methods
    }
}
