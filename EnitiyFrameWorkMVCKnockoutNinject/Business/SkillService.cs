using EnitiyFrameWorkMVCKnockoutNinject.Business.Interfaces;
using EnitiyFrameWorkMVCKnockoutNinject.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnitiyFrameWorkMVCKnockoutNinject.Business
{
    public class SkillService : ISkillService
    {
        private readonly ISkillsEFRepository skillsEFRepository;
        public SkillService(ISkillsEFRepository skillsEFRepository)
        {
            this.skillsEFRepository = skillsEFRepository;
        }

        public void Save(Data.skill skill)
        {
            skillsEFRepository.Save(skill);
        }

        public Data.skill Get(int id)
        {
            return skillsEFRepository.Get(id);
        }

        public IEnumerable<Data.skill> GetAll()
        {
            return skillsEFRepository.GetAll();
        }

        public void Delete(Data.skill skill)
        {
            skillsEFRepository.Delete(skill);
        }
    }
}