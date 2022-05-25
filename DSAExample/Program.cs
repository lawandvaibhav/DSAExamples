// -----------------------------------------------------------------------
//   <copyright file=Program.cs>
//      Copyright © 2022. All Rights Reserved.
//   </copyright>
// -----------------------------------------------------------------------
//  <Author>Vaibhav Lawand</Author>

using System.Reflection;
using DSAExample.Helpers;
using DSAExample.Interfaces;

namespace DSAExample
{
    internal class Example
    {
        #region Public Properties

        public ISupportExample Instance { get; }

        public string Key { get; }

        #endregion Public Properties

        #region Internal Constructors

        internal Example(string key, ISupportExample instance)
        {
            Key = key;
            Instance = instance;
        }

        #endregion Internal Constructors
    }

    internal class Program
    {
        #region Private Fields

        private const string Yes = "Y";

        #endregion Private Fields

        #region Private Methods

        private static void AskUserToContinueOrExit(bool isValidInput)
        {
            string askUserToContinueOrExit = isValidInput ? Constants.ValidChoiceMessage : Constants.InvalidChoiceMessage;
            Console.WriteLine($"\n\n{askUserToContinueOrExit}");
        }

        private static bool DoesUserWantToContinue()
        {
            return Console.ReadLine().Equals(Yes, StringComparison.OrdinalIgnoreCase);
        }

        private static List<Example> GetAllExamples()
        {
            var allExamples = new List<Example>();

            var type = typeof(ISupportExample);
            var types = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            int index = 1;
            string description = "";

            foreach (var item in types)
            {
                ISupportExample instance = (ISupportExample)Activator.CreateInstance(item);

                var methodInfo = item.GetMethod(nameof(ISupportExample.Run));
                var propertyInfo = item.GetProperty(nameof(ISupportExample.Description));

                if (propertyInfo != null)
                {
                    description = propertyInfo.GetValue(instance)?.ToString();
                }

                allExamples.Add(new Example($"{index++}. {description}", instance));
            }

            return allExamples;
        }

        private static void Main(string[] args)
        {
            var allExamples = GetAllExamples();
            ShowAllExamples(allExamples);

            do
            {
                Console.WriteLine(Constants.SelectExampleToRun);
                bool isInputValid = ValidateUserInput(allExamples.Count, out int inputChoice);

                if (isInputValid)
                {
                    ShowHorizontalLine();
                    allExamples[inputChoice - 1].Instance.Run();
                    ShowHorizontalLine();
                }

                AskUserToContinueOrExit(isInputValid);
            }
            while (DoesUserWantToContinue());
        }

        private static void ShowAllExamples(List<Example> allExamples)
        {
            foreach (var item in allExamples)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine(Constants.HorizontalLine);
        }

        private static void ShowHorizontalLine()
        {
            Console.WriteLine(Constants.HorizontalLine);
        }

        private static bool ValidateUserInput(int count, out int inputChoice)
        {
            bool isChoiceValid = int.TryParse(Console.ReadLine(), out inputChoice);
            if (isChoiceValid && inputChoice > 0 && inputChoice <= count)
                return true;

            return false;
        }

        #endregion Private Methods
    }
}
