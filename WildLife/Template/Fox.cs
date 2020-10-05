using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildLife.Common;

namespace WildLife.Template
{
    public class Fox:AnimalBaseTemplate
    {
        public Fox(AnimalKind kind, AnimalGender gender, int ageLimit = 3) : base(kind, gender, ageLimit)
        {
        }

        protected override bool IsFleeing()
        {
            return TheWorld.NearBy(AnimalKind.tiger);
        }

        //protected override bool IsMating()
        //{
        //    return TheWorld.NearBy(AnimalKind.fox) && TheWorld.GenderOfNearBy(AnimalKind.fox) != Gender;
        //}

        protected override bool IsEating()
        {
            return TheWorld.NearBy(AnimalKind.rabbit) || TheWorld.NearBy(AnimalKind.mouse);
        }
    }
}
