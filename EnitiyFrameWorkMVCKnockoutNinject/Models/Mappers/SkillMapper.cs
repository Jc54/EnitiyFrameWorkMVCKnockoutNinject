using EnitiyFrameWorkMVCKnockoutNinject.Models.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnitiyFrameWorkMVCKnockoutNinject.Models.Mappers
{
    public class SkillMapper : ISkillMapper
    {
        public Skill MapFrom(Data.skill skill)
        {
            return new Skill { SkillId = skill.id, SkillName = skill.skill_name };
        }
        public IEnumerable<Skill> MapFrom(IEnumerable<Data.skill> skills)
        {
            var listOfSkills = new List<Skill>();
            foreach (var skill in skills)
            {
                listOfSkills.Add(MapFrom(skill));
            }
            return listOfSkills;
        }
        public Data.skill MapFrom(Skill skill)
        {
            return new Data.skill { id = skill.SkillId, skill_name = skill.SkillName };
        }
    }
}