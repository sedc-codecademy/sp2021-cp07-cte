using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Psyent.Models;
using Psyent.Services.CustomExceptions;
using Psyent.Services.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Psyent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [HttpGet("getAllMentors")]
        //[Authorize]
        public ActionResult<List<MentorModel>> GetAllMentors()
        {
            return _mentorService.GetAllMentors();
        }

        [HttpPost("getMentorDetails")]
        public ActionResult<MentorModel> GetMentorDetails(int mentorId)
        {
            try
            {
                return _mentorService.GetMentorDetails(mentorId);
            }
            catch (MentorException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addMentor")]
        //[Authorize]
        public ActionResult<string> AddMentor([FromBody] MentorModel mentor)
        {
            try
            {
                return _mentorService.AddMentor(mentor);
            }
            catch (MentorException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deleteMentor")]
        //[Authorize]
        public ActionResult<string> DeleteMentor(int mentorId)
        {
            try
            {
                return _mentorService.DeleteMentor(mentorId);
            }
            catch (MentorException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updateMentor")]
        //[Authorize]
        public ActionResult UpdateMentor([FromBody] MentorModel mentor)
        {
            try
            {
                _mentorService.UpdateMentor(mentor);
                return Ok();
            }
            catch (MentorException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
