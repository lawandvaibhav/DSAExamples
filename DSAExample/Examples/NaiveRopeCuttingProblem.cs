// -----------------------------------------------------------------------
//   <copyright file=NaiveRopeCuttingProblem.cs>
//      Copyright © 2022. All Rights Reserved.
//   </copyright>
// -----------------------------------------------------------------------
//  <Author>Vaibhav Lawand</Author>

using DSAExample.Interfaces;

namespace DSAExample.Examples
{
    public class NaiveRopeCuttingProblem : ISupportExample
    {
        #region Public Properties

        public string Description => "Naive Rope Cutting Problem";

        #endregion Public Properties

        #region Public Methods

        public int GetNoOfPossibleWays(int totalRopeLength,
                                       int firstRopeLength,
                                       int secondRopeLength,
                                       int thirdRopeLength)
        {
            if (totalRopeLength == 0)
                return 0;

            if (totalRopeLength < 0)
                return -1;

            int firstRopeResult = GetNoOfPossibleWays(totalRopeLength - firstRopeLength,
                                                      firstRopeLength,
                                                      secondRopeLength,
                                                      thirdRopeLength);
            int secondRopeResult = GetNoOfPossibleWays(totalRopeLength - secondRopeLength,
                                                       firstRopeLength,
                                                       secondRopeLength,
                                                       thirdRopeLength);
            int thirdRopeResult = GetNoOfPossibleWays(totalRopeLength - thirdRopeLength,
                                                      firstRopeLength,
                                                      secondRopeLength,
                                                      thirdRopeLength);

            int result = Math.Max(Math.Max(firstRopeResult, secondRopeResult), thirdRopeResult);

            if (result == -1)
                return -1;

            return result + 1;
        }

        public void Run()
        {
            int totalRopeLength = 5;
            int firstRopeLength = 2;
            int secondRopeLength = 5;
            int thirdRopeLength = 1;

            Console.WriteLine($"Total Rope Length = {totalRopeLength}");
            Console.WriteLine($"Given rope lengths are {firstRopeLength}, {secondRopeLength}, and {thirdRopeLength}");

            int noOfPossibleWays = GetNoOfPossibleWays(totalRopeLength,
                                                       firstRopeLength,
                                                       secondRopeLength,
                                                       thirdRopeLength);

            Console.WriteLine($"\nNumber of possible ways are {noOfPossibleWays}");
        }

        #endregion Public Methods
    }
}
