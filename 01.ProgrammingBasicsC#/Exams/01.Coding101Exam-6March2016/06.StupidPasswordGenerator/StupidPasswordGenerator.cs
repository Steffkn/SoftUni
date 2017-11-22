namespace _06.StupidPasswordGenerator
{
    using System;

    public class StupidPasswordGenerator
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());

            int minLetter = (int)'a' - 96;
            int maxLetter = minLetter + L;
            int[] password = { 1, 1, 1, 1, 2 };

            int[] newPassword = GenerateNewPass(password, N, L);
            bool stop = false;

            while (!stop)
            {
                newPassword = GenerateNewPass(password, N, L);

                stop = true;
                for (int i = 0; i < 5; i++)
                {
                    if (password[i] != newPassword[i])
                    {
                        stop = false;
                        break;
                    }

                }

                PrintPass(password);

                for (int y = 0; y < 5; y++)
                {
                    password[y] = newPassword[y];
                }

            }
        }

        static void PrintPass(int[] password)
        {
            Console.Write(string.Format("{0}{1}{2}{3}{4} ", password[0], password[1], (char)(password[2] + 96), (char)(password[3] + 96), password[4]));
        }

        static int[] GenerateNewPass(int[] pass, int N, int L)
        {
            int[] password = new int[5];

            for (int i = 0; i < 5; i++)
            {
                password[i] = pass[i];
            }

            if (password[4] + 1 > N)
            {
                if (password[3] + 1 > L)
                {
                    if (password[2] + 1 > L)
                    {
                        if (password[1] + 1 > N - 1 )
                        {
                            if (password[0] + 1 < N)
                            {
                                password[0] += 1;
                                password[1] = 1;
                                password[2] = 1;
                                password[3] = 1;
                                password[4] = Math.Max(password[0], password[1]) + 1;
                            }
                        }
                        else
                        {
                            password[1] += 1;
                            password[2] = 1;
                            password[3] = 1;
                            password[4] = Math.Max(password[0], password[1]) + 1;
                        }
                    }
                    else
                    {
                        password[2] += 1;
                        password[3] = 1;
                        password[4] = Math.Max(password[0], password[1]) + 1;
                    }
                }
                else
                {
                    password[3] += 1;
                    password[4] = Math.Max(password[0], password[1]) + 1;
                }
            }
            else
            {
                password[4] += 1;
            }

            return password;
        }
    }
}
