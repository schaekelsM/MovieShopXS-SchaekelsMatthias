using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Model
{
    public class MovieActor
    {
        public int MovieID { get; set; }
        public int ActorID { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Person Actor { get; set; }
    }
}
