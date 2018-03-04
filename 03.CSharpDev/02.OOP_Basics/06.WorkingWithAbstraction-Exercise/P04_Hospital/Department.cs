using System.Collections.Generic;
using System.Linq;

public class Department
{
    public string Name { get; set; }

    public List<Room> Rooms { get; set; }

    public Department(string name)
    {
        this.Name = name;
        this.Rooms = new List<Room>(20);
    }

    public Room GetFreeRoom()
    {
        if (this.Rooms.Count == 0)
        {
            this.Rooms.Add(new Room());
        }

        foreach (var room in Rooms)
        {
            if (room.HasSpace())
            {
                return room;
            }
        }

        if (this.Rooms.Count < 20)
        {
            var newRoom = new Room();
            this.Rooms.Add(newRoom);
            return newRoom;
        }

        return null;
    }

    public bool AddPatient(Room room, Patient person)
    {
        return room.AddPatient(person);
    }
}
