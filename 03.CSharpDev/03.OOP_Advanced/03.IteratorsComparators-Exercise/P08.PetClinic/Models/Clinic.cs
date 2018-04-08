namespace P08.PetClinic.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Clinic : IEnumerable<Room>
    {
        private IList<Room> rooms;
        private int roomsCount;

        public Clinic(string name, int roomsCount)
        {
            this.Name = name;
            this.RoomsCount = roomsCount;
            this.rooms = new List<Room>(roomsCount);
            for (int i = 0; i < roomsCount; i++)
            {
                this.rooms.Add(new Room());
            }
        }

        public int RoomsCount
        {
            get => this.rooms.Count;
            private set
            {
                if (value % 2 == 0)
                {
                    throw new InvalidOperationException("Invalid Operation!");
                }

                this.roomsCount = value;
            }
        }

        public string Name { get; set; }

        public IEnumerator<Room> GetEnumerator()
        {
            int midpoint = roomsCount / 2;
            int currentIndex = midpoint;
            int counter = 1;
            bool isLeft = true;

            while (currentIndex > -1)
            {
                yield return this.rooms[currentIndex];
                if (isLeft)
                {
                    currentIndex = midpoint - counter;
                    isLeft = false;
                }
                else
                {
                    isLeft = true;
                    currentIndex = midpoint + counter;
                    counter++;
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Accomodate(Pet accomodatePet)
        {
            if (accomodatePet == null)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            foreach (var room in this)
            {
                if (room.IsEmpty)
                {
                    room.AddPet(accomodatePet);
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            for (int i = roomsCount / 2; i < this.rooms.Count; i++)
            {
                if (!this.rooms[i].IsEmpty)
                {
                    this.rooms[i].RemovePet();
                    return true;
                }
            }

            for (int i = 0 / 2; i < roomsCount / 2; i++)
            {
                if (!this.rooms[i].IsEmpty)
                {
                    this.rooms[i].RemovePet();
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            foreach (var room in this)
            {
                if (room.IsEmpty)
                {
                    return true;
                }
            }

            return false;
        }

        public void Print()
        {
            foreach (var room in this.rooms)
            {
                Console.WriteLine(room);
            }
        }

        public void Print(int roomNumber)
        {
            Console.WriteLine(this.rooms[roomNumber - 1]);
        }
    }
}
