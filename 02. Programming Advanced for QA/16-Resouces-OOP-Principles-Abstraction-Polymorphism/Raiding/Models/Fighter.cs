using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class Fighter : BaseHero
    {
        public Fighter(string name) : base(name)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {this.Power} damage";
            // we don't have property Power here but it's inherited from the BaseHero class
        }
    }
}
