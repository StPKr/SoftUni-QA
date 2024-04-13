using Raiding.Contracts;

namespace Raiding.Models;

public abstract class BaseHero : IHero
{
    public BaseHero(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public abstract int Power { get; }

    public virtual string CastAbility()
    {
        return $"{this.GetType().Name} - {this.Name}";
    }
}
