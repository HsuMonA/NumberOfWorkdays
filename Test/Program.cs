namespace Test
{
    public class Program
    {
        private static int i;
        public static void Main(string[] args)
        {
            Test(new DateOnly(2022, 1, 1), new DateOnly(2022, 2, 1), expected: 21);
            Test(new DateOnly(2022, 1, 3), new DateOnly(2022, 1, 7), expected: 4);
            Test(new DateOnly(2022, 1, 7), new DateOnly(2022, 1, 7), expected: 0);
            Test(new DateOnly(2022, 1, 8), new DateOnly(2022, 1, 10), expected: 0);

            try
            {
                //the start date should not be later than the end date
                NumberOfWorkdays(new DateOnly(2022, 1, 18), new DateOnly(2022, 1, 10));

                var temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i++}\tFailed");
                Console.ForegroundColor = temp;
            }
            catch (Exception)
            {
                Console.WriteLine($"{i++}\tPassed");
            }

            // Feel free to add more test cases here to ensure your solution is correct
            Test(new DateOnly(2023, 5, 1), new DateOnly(2023, 5, 7), expected: 5);
        }

        private static void Test(DateOnly start, DateOnly end, int expected)
        {
            var workdays = NumberOfWorkdays(start, end);
            if (workdays == expected)
            {
                Console.WriteLine($"{i++}\tPassed\t{workdays}");
            }
            else
            {
                var temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i++}\tFailed (expected {expected}, actual {workdays})");
                Console.ForegroundColor = temp;
            }
        }

        /// <summary>
        /// This method should return the number of workdays (monday trough friday) between the specified dates
        /// You do not need to take holidays into account
        /// You may assume that the start and end dates are within a year of eachother
        /// The start date is included in the range, the end date is excluded
        /// Using external libraries (besides the .NET libraries) is not allowed
        /// Please implement your solution in this file only
        /// </summary>
        private static int NumberOfWorkdays(DateOnly start, DateOnly end)
        {
            if (start > end) // Check if start date is later than end date
            {
                throw new ArgumentException("start date cannot be later than end date");
            }
            var countWorkDays = 0;
            for (DateOnly i = start; i < end; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                {
                    countWorkDays++;
                }
            }
            return countWorkDays;
        }
    }
}
