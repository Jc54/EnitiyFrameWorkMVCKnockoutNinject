using EnitiyFrameWorkMVCKnockoutNinject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitiyFrameWorkMVCKnockoutNinject.Business.Interfaces
{
    public interface ISkillService
    {
        void Save(skill skill);
        skill Get(int id);
        IEnumerable<skill> GetAll();
        void Delete(skill skill);
    }
}
