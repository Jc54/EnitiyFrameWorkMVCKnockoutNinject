using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitiyFrameWorkMVCKnockoutNinject.Models.Mappers.Interfaces
{
    public interface ISkillMapper
    {
        Skill MapFrom(Data.skill skill);

        IEnumerable<Skill> MapFrom(IEnumerable<Data.skill> skill);

        Data.skill MapFrom(Skill skill);
    }
}
