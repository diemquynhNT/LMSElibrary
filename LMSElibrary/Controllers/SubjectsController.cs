﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectService.Data;
using SubjectService.Model;
using SubjectService.Service;

namespace SubjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService isp;

        public SubjectsController(ISubjectService _isp)
        {
            isp = _isp;
        }

        [HttpGet("list")]
        public List<Subject> SubjectListAsync()
        {
                var subjectList = isp.GetSubjectListAsync();
                return subjectList;
        }
        [HttpGet("GetById")]
        public Task<Subject> GetSubjectByIdAsync(string Id)
        {
            return isp.GetSubjectByIdAsync(Id);
        }


        [HttpGet("SearchSubject")]
        public Task<Subject> SearchSubject(string keyword)
        {
            var sub = isp.GetSubjectByIdAsync(keyword);
            if (sub == null)
                return isp.GetSubjectByName(keyword);
            return sub;
        }

        [HttpGet("GetTopic")]
        public List<Topic> GetTopic(string Id)
        {
            return isp.GetTopicsSubject(Id);
        }

        [HttpPost("AddTopic")]
        public async Task<ActionResult> AddTopic([FromForm] string name, [FromForm] string id)
        {
           
            try
            {
                await isp.AddTopic(name,id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("EditTopic")]
        public async Task<ActionResult> EditTopic([FromForm] string name, string id, string idtopic)
        {
           

            try
            {
                await isp.EditTopic(name, id,idtopic);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
