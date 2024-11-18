using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KringeGame.Creatures;

namespace KringeGame.Actions
{
    public abstract class CreatureAction
    {
        public string Title { get; protected set; }

        public abstract void Run(Creature performer, Room room);
    }

}
