using EnitiyFrameWorkMVCKnockoutNinject.Business.Interfaces;
using EnitiyFrameWorkMVCKnockoutNinject.Data;
using EnitiyFrameWorkMVCKnockoutNinject.Models;
using EnitiyFrameWorkMVCKnockoutNinject.Models.Mappers.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnitiyFrameWorkMVCKnockoutNinject.Api
{
    public class SkillsController : ApiController
    {
        private ISkillService skillService;
        private ISkillMapper skillMapper;
        public SkillsController(ISkillService skillService, ISkillMapper skillMapper)
        {
            this.skillService = skillService;
            this.skillMapper = skillMapper;
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return skillMapper.MapFrom(skillService.GetAll());
        }


        public Skill GetSkill(int id)
        {
            var skill = skillMapper.MapFrom(skillService.Get(id));
            if (skill == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            return skill;
        }

        public HttpResponseMessage PutSkill(int id, Skill skill)
        {
            if (skill != null && ModelState.IsValid && id == skill.SkillId)
            {
                skillService.Save(skillMapper.MapFrom(skill));
                return Request.CreateResponse(HttpStatusCode.OK, skill);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostSkill(Skill skill)
        {
            if (skill.SkillName != string.Empty)
            {
                skillService.Save(skillMapper.MapFrom(skill));
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, skill);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = skill.SkillId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage DeleteSkill(int id)
        {
            Skill skill = skillMapper.MapFrom(skillService.Get(id));
            if (skill == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            skillService.Delete(skillMapper.MapFrom(skill));
            return Request.CreateResponse(HttpStatusCode.OK, skill);

        }

    }
}
