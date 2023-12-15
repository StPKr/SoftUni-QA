using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class Healer : BaseHero
    {
        public Healer(string name) : base(name)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {this.Power}";
            // we don't have property Power here but it's inherited from the BaseHero class
        }
    }
}
