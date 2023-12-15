Person person = new Person("Teo", 40);

Console.WriteLine(person.Name);
//person.Name = "Test"; - won't work unless we have the set below
public class Person
{
    private string _name;
    private int _age;

    public Person(string name, int age)
    {
        this._name = name;
        this._age = age;

        this.IsOfLegalAge(this);
    }

    public string Name
    {
        get { return this._name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name is not valid");
            }
            this._name = value;
        }
        //- if we remove the setter we won't allow the property
        //to be changed; person.Name above won't work anymore
        //example of encapsulation
    }

    public int Age
    {
        get { return this._age; }
        set
        {
            if (value < 0 || value > 150)
            {
                throw new ArgumentException("Age must be a positive number");
            }
            this._age = value;
        }
    }

    public bool IsOfLegalAge(Person person)
    {
        return person.Age >= 18;
    }
}