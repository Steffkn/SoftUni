﻿using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private int age;

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }

    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }

    public Person(int age) : this()
    {
        this.Age = age;
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
