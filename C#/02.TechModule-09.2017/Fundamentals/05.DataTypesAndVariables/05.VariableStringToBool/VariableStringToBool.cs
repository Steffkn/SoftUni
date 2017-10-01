namespace _05.VariableStringToBool
{
    using System;

    public class VariableStringToBool
    {
        static void Main()
        {
            string stringBoolValue = Console.ReadLine();
            bool boolValue = Convert.ToBoolean(stringBoolValue);

            if (boolValue)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
