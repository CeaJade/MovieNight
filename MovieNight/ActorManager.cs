using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    class ActorManager
    {
        public static List<Actor> ActorList(string search)
        {
            return DalManager.GetActors(search);
        }
    }
}
