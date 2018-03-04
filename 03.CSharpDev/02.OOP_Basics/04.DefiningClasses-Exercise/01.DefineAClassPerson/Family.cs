using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Family
{
    private List<Person> familyMembers;

    public List<Person> FamilyMembers
    {
        get => familyMembers;
        set => familyMembers = value;
    }

    public Family()
    {
        this.FamilyMembers = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.FamilyMembers.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.FamilyMembers.OrderByDescending(i => i.Age).First();
    }
}
