using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models.Heroes
{
    public class Paladin : Healer
    {
        public Paladin(string name) : base(name)
        { }

        public override int Power => 100;
    }
}
