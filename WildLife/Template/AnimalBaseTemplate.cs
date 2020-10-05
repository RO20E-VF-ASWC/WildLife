using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildLife.Common;

namespace WildLife.Template
{
    public abstract class AnimalBaseTemplate:AnimalBase
    {
        public AnimalBaseTemplate(AnimalKind kind, AnimalGender gender, int ageLimit = 3) : base(kind, gender, ageLimit)
        {
        }

        public override void Act()
        {
            // 1.priority: Eating
            if (IsEating())
            {
                Hunt();
                Eat();
            }

            // 2.priority: Mating (with Fox of opposite gender)
            else if (IsMating())
            {
                Mate();
            }

            // 3.priority: Fleeing
            else if (IsFleeing())
            {
                Flee();
            }

            // 4.priority: Sleeping
            else if (Sleepy)
            {
                Sleep();
            }

            else
            {
                Idle();
            }
        }

        protected abstract bool IsFleeing();

        protected bool IsMating()
        {
            return TheWorld.NearBy(Kind) && TheWorld.GenderOfNearBy(Kind) != Gender;
        }

        protected abstract bool IsEating();
    }
}
