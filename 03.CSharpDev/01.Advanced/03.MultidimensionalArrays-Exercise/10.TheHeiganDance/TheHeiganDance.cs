namespace _10.TheHeiganDance
{
    using System;

    public class TheHeiganDance
    {
        private const int MaxRow = 15;
        private const int MaxCol = 15;
        private static double HeiganHealth = 3000000;
        private static int PlayerHealth = 18500;
        private static int PlayerRow = 7;
        private static int PlayerCol = 7;
        private const int PlagueCloudDMG = 3500;
        private const int EruptionDMG = 6000;

        static void Main()
        {
            double playerDmg = double.Parse(Console.ReadLine());
            bool isHitByCloud = false;
            string lastHitBy = string.Empty;
            while (true)
            {
                // P hit H
                HeiganHealth -= playerDmg;

                // P hit by Cloud x2
                if (isHitByCloud)
                {
                    PlayerHealth -= PlagueCloudDMG;
                    lastHitBy = "Plague Cloud";
                    isHitByCloud = false;
                }

                // if P !isDead
                if (IsPlayerAlive() && IsHeiganAlive())
                {
                    //   H cast Spell
                    var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string spellName = command[0];
                    int spellPosRow = int.Parse(command[1]);
                    int spellPosCol = int.Parse(command[2]);
                    if (IsPlayerInRange(spellPosRow, spellPosCol, PlayerRow, PlayerCol))
                    {
                        //   P tries to move
                        var moved = PlayerTryToMove(spellPosRow, spellPosCol);

                        //   ifDidntMove H hit P
                        if (!moved)
                        {
                            if (spellName.Equals("Cloud"))
                            {
                                PlayerHealth -= PlagueCloudDMG;
                                isHitByCloud = true;
                                lastHitBy = "Plague Cloud";
                            }
                            else
                            {
                                PlayerHealth -= EruptionDMG;
                                lastHitBy = "Eruption";
                            }
                        }
                    }

                }

                //   if H isDead 
                if (!IsHeiganAlive())
                {
                    Console.WriteLine("Heigan: Defeated!");
                    if (IsPlayerAlive())
                    {
                        Console.WriteLine("Player: {0}", PlayerHealth);
                    }
                    else
                    {
                        Console.WriteLine("Player: Killed by {0}", lastHitBy);
                    }
                    Console.WriteLine("Final position: {0}, {1}", PlayerRow, PlayerCol);

                    return;
                }

                //   if P isDead
                if (!IsPlayerAlive())
                {
                    Console.WriteLine("Heigan: {0:f2}", HeiganHealth);
                    Console.WriteLine("Player: Killed by {0}", lastHitBy);
                    Console.WriteLine("Final position: {0}, {1}", PlayerRow, PlayerCol);
                    return;
                }
            }
        }

        private static bool PlayerTryToMove(int spellPosRow, int spellPosCol)
        {
            int newRow = PlayerRow - 1;
            int newCol = PlayerCol + 1;

            // try to move up (col - 1)
            if (newRow > -1 && !IsPlayerInRange(spellPosRow, spellPosCol, newRow, PlayerCol))
            {
                PlayerRow = newRow;
                return true;
            }

            if (newCol < MaxCol && !IsPlayerInRange(spellPosRow, spellPosCol, PlayerRow, newCol))
            {
                PlayerCol = newCol;
                return true;
            }

            newRow = PlayerRow + 1;
            if (newRow < MaxRow && !IsPlayerInRange(spellPosRow, spellPosCol, newRow, PlayerCol))
            {
                PlayerRow = newRow;
                return true;
            }

            newCol = PlayerCol - 1;
            if (newCol > -1 && !IsPlayerInRange(spellPosRow, spellPosCol, PlayerRow, newCol))
            {
                PlayerCol = newCol;
                return true;
            }

            return false;
        }

        private static bool IsPlayerInRange(int spellPosRow, int spellPosCol, int playerRow, int playerCol)
        {
            if (Math.Abs(playerRow - spellPosRow) > 1 || Math.Abs(playerCol - spellPosCol) > 1)
            {
                return false;
            }
            return true;
        }

        private static bool IsHeiganAlive()
        {
            return HeiganHealth > 0;
        }

        private static bool IsPlayerAlive()
        {
            return PlayerHealth > 0;
        }
    }
}
