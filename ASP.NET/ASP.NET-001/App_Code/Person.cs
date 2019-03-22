using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Person 的摘要说明
/// </summary>
public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    string _name;

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public int Age { get; set; }
}