namespace Animals.Models;

public abstract class Animal
{
    private string name;
    private string favouriteFood;

    public Animal(string name, string favouriteFood)
    {
        this.name = name;
        this.favouriteFood = favouriteFood;
    }

    public virtual string ExplainSelf() // if not virtual we can't override in the Cat and Dog classes
    {
        return $"I am {this.name} and my favourite food is {this.favouriteFood}";
    }
}
