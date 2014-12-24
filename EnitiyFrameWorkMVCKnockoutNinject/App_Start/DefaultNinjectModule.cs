using EnitiyFrameWorkMVCKnockoutNinject.Business;
using EnitiyFrameWorkMVCKnockoutNinject.Business.Interfaces;
using EnitiyFrameWorkMVCKnockoutNinject.Data.Repository;
using EnitiyFrameWorkMVCKnockoutNinject.Data.Repository.Interfaces;
using EnitiyFrameWorkMVCKnockoutNinject.Models.Mappers;
using EnitiyFrameWorkMVCKnockoutNinject.Models.Mappers.Interfaces;
using Ninject.Modules;

namespace EnitiyFrameWorkMVCKnockoutNinject.App_Start
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {

            Bind<ISkillService>().To<SkillService>();
            Bind<ISkillsEFRepository>().To<SkillsEFRepository>();
            Bind<ISkillMapper>().To<SkillMapper>();
            
        }
    }
}