using EnitiyFrameWorkMVCKnockoutNinject.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnitiyFrameWorkMVCKnockoutNinject.Data.Repository
{
    public class SkillsEFRepository : ISkillsEFRepository
    {
        public void Save(skill skill)
        {
            if (skill.id > 0)
            {
                Update(skill);
            }
            else
            {
                Create(skill);
            }
        }

        private void Create(skill skill)
        {
            using (var obj = new SkillsDbEntities())
            {
                obj.skills.Add(skill);
                obj.SaveChanges();
            }
        }

        private void Update(skill skill)
        {
            using (var obj = new SkillsDbEntities())
            {

                var updatedSkill = obj.skills.First(s => s.id == skill.id);
                updatedSkill.skill_name = skill.skill_name;
                obj.SaveChanges();
            }
            
        }

        public skill Get(int id)
        {
            using (var obj = new SkillsDbEntities())
            {
                return obj.skills.ToList().FirstOrDefault(s => s.id == id);
            }
        }

        public IEnumerable<skill> GetAll()
        {
            using (var obj = new SkillsDbEntities())
            {
                return obj.skills.ToList();
            }
        }

        public void Delete(skill skill)
        {
            using (var obj = new SkillsDbEntities())
            {
                obj.sp_skill_delete(skill.id);
                obj.SaveChanges();
            }
        }
    }
}