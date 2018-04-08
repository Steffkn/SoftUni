using System.Linq;
using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input = string.Empty;
            var type = Type.GetType("P01_HarvestingFields.HarvestingFields");
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input.ToLower())
                {
                    case "private":
                        foreach (var fieldInfo in fields.Where(f => f.IsPrivate))
                        {
                            PrintField(fieldInfo);
                        }
                        break;
                    case "protected":
                        foreach (var fieldInfo in fields.Where(f => f.IsFamily))
                        {
                            PrintField(fieldInfo);
                        }
                        break;
                    case "public":
                        foreach (var fieldInfo in fields.Where(f => f.IsPublic))
                        {
                            PrintField(fieldInfo);
                        }
                        break;
                    case "all":
                        foreach (var fieldInfo in fields)
                        {
                            PrintField(fieldInfo);
                        }
                        break;
                }
            }
        }

        public static void PrintField(FieldInfo fieldInfo)
        {
            var accessModifier = fieldInfo.IsFamily ? "protected" :
                fieldInfo.IsPrivate ? "private" :
                fieldInfo.IsPublic ? "public" :
                "somethingElse";
            Console.WriteLine($"{accessModifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
        }
    }
}
