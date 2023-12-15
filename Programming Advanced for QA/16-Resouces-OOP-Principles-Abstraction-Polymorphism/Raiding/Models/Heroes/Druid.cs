using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models.Heroes
{
    public class Druid : Healer
    {
        public Druid(string name) : base(name)
        { }

        public override int Power => 80;
    }
}
