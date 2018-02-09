namespace _03.CubicMessages
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class CubicMessages
    {
        static void Main()
        {
            string patern = @"^([0-9]+)([a-zA-Z]+)([\W0-9]*)$";
            var reg = new Regex(patern);
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Over!")
            {
                var n = int.Parse(Console.ReadLine());
                if (reg.IsMatch(input))
                {
                    var matches = reg.Matches(input);
                    var sb = new StringBuilder();
                    foreach (Match item in matches)
                    {
                        string before = item.Groups[1].Value;
                        string text = item.Groups[2].Value;
                        string after = item.Groups[3].Value;
                        if (text.Length != n)
                        {
                            break;
                        }

                        for (int i = 0; i < before.Length; i++)
                        {
                            int index = 0;
                            if (int.TryParse(before[i].ToString(), out index))
                            {
                                if (index > -1 && index < text.Length)
                                {
                                    sb.Append(text[index]);
                                }
                                else
                                {
                                    sb.Append(' ');
                                }
                            }
                        }

                        for (int i = 0; i < after.Length; i++)
                        {
                            int index = 0;
                            if (int.TryParse(after[i].ToString(), out index))
                            {
                                if (index > -1 && index < text.Length)
                                {
                                    sb.Append(text[index]);
                                }
                                else
                                {
                                    sb.Append(' ');
                                }
                            }
                        }

                        Console.WriteLine($"{text} == {sb.ToString()}");
                        sb.Clear();
                        break;
                    }

                }
            }
        }
    }
}
