using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitiyFrameWorkMVCKnockoutNinject.Data.Repository.Interfaces
{
    public interface ISkillsEFRepository
    {
        void Save(skill skill);
        skill Get(int id);
        IEnumerable<skill> GetAll();
        void Delete(skill skill);
    }
}
