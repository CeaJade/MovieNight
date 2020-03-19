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

        public static Actor AddActor(Actor actor)
        {
            return DalManager.InsertActor(actor);
        }

        public static Actor UpdateActor(Actor actor)
        {
            return DalManager.UpdateActor(actor);
        }

        public static Actor DeleteActor(Actor actor)
        {
            return DalManager.DeleteActor(actor);
        }
    }

   
}
