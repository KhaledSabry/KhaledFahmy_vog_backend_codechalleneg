using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionConsoleApp
{
    public static class QuestionClass
    {
        static List<string> NamesList = new List<string>()
        {
            "Jimmy",
            "jeffrey"
        };

        public static void TestQuestion()
        {

            foreach (var Current in NamesList)
            {
                Console.WriteLine(Current);
            }
        }
    }

}
