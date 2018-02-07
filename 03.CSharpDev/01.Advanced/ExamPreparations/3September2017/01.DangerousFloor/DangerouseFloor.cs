namespace _01.DangerousFloor
{
    using System;

    public class DangerouseFloor
    {
        static void Main()
        {
            char[,] matrix = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = input[j][0];
                }
            }

            string moveInput = Console.ReadLine();

            while (moveInput != "END")
            {
                var tockens = moveInput.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                char chessPease = tockens[0][0];
                var fromPosX = int.Parse(tockens[0][1].ToString());
                var fromPosY = int.Parse(tockens[0][2].ToString());

                var toPosX = int.Parse(tockens[1][0].ToString());
                var toPosY = int.Parse(tockens[1][1].ToString());

                bool isInside = fromPosX > -1 && fromPosX < 8 && fromPosY > -1 && fromPosY < 8;
                bool isToInside = toPosX > -1 && toPosX < 8 && toPosY > -1 && toPosY < 8;
                bool move = false;

                if (isInside && matrix[fromPosX, fromPosY] != chessPease)
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (isToInside && isInside && matrix[fromPosX, fromPosY] == chessPease)
                {
                    switch (chessPease)
                    {
                        case 'K':
                            if (Math.Abs(fromPosX - toPosX) > 1 || Math.Abs(fromPosY - toPosY) > 1)
                            {
                                Console.WriteLine("Invalid move!");
                                move = false;
                            }
                            else
                            {
                                move = true;
                            }
                            break;
                        case 'R':
                            if (fromPosX != toPosX && fromPosY != toPosY)
                            {
                                Console.WriteLine("Invalid move!");
                                move = false;
                            }
                            else
                            {
                                move = true;
                            }
                            break;
                        case 'P':
                            if (fromPosX - toPosX != 1)
                            {
                                Console.WriteLine("Invalid move!");
                                move = false;
                            }
                            else
                            {
                                move = true;
                            }
                            break;
                        case 'B':
                            if (Math.Abs(fromPosX - toPosX) != Math.Abs(fromPosY - toPosY))
                            {
                                Console.WriteLine("Invalid move!");
                                move = false;
                            }
                            else
                            {
                                move = true;
                            }
                            break;
                        case 'Q':
                            if (Math.Abs(fromPosX - toPosX) != Math.Abs(fromPosY - toPosY) && (fromPosX != toPosX && fromPosY != toPosY))
                            {
                                Console.WriteLine("Invalid move!");
                                move = false;
                            }
                            else
                            {
                                move = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Move go out of board!");
                }

                if (isInside && move)
                {
                    matrix[toPosX, toPosY] = matrix[fromPosX, fromPosY];
                    matrix[fromPosX, fromPosY] = 'x';
                }

                moveInput = Console.ReadLine();
            }
        }
    }
}
