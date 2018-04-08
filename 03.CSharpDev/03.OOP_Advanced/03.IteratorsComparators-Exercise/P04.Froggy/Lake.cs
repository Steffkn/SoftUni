using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        IList<int> stones;

        public Lake(params int[] addStones)
        {
            this.stones = new List<int>(addStones);
        }

        public IEnumerator<int> GetEnumerator()
        {
            var jumps = new List<int>();
            var jumpsBackwards = new Stack<int>();
            for (int i = 0; i < this.stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    jumps.Add(this.stones[i]);
                }
                else
                {
                    jumpsBackwards.Push(this.stones[i]);
                }
            }

            jumps.AddRange(jumpsBackwards);

            foreach (int jump in jumps)
            {
                yield return jump;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
