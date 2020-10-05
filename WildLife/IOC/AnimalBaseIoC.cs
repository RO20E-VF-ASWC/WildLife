using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildLife.Common;

namespace WildLife.IOC
{
    public class AnimalBaseIoC:AnimalBase
    {
        private Func<bool> IsEating;
        private Func<bool> IsFleeing;

        public AnimalBaseIoC(AnimalKind kind, AnimalGender gender, Func<bool> isEating, Func<bool> isFleeing, int ageLimit = 3) : base(kind, gender, ageLimit)
        {
            IsEating = isEating;
            IsFleeing = isFleeing;
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
            else if (TheWorld.NearBy(Kind) && TheWorld.GenderOfNearBy(Kind) != Gender)
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
    }
}
