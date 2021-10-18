using Psyent.DataAccess;
using Psyent.DataModels;
using Psyent.Models;
using Psyent.Services.CustomExceptions;
using Psyent.Services.Mapper;
using Psyent.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Psyent.Services.Services
{
    public class MentorService : IMentorService
    {
        private readonly IRepository<Mentor> _mentorRepository;
        
        public MentorService(IRepository<Mentor> mentorRepository)
        {
            _mentorRepository = mentorRepository;
        }

        public string AddMentor(MentorModel mentor)
        {
            var mentorModel = MentorMapper.MentorModelToMentorModel(mentor);
            _mentorRepository.Add(mentorModel);

            return "Mentor successfully added";
        }

        public string DeleteMentor(int mentorId)
        {
            var mentor = _mentorRepository.GetAll().SingleOrDefault(x => x.Id == mentorId);
            if (mentor == null)
            {
                throw new MentorException($"Mentor with id:{mentorId}, was not found");
            }
            _mentorRepository.Delete(mentor);

            return "Note deleted successfully";
        }

        public List<MentorModel> GetAllMentors()
        {
            return (List<MentorModel>)_mentorRepository.GetAll().Select(mentor => MentorMapper.MentorModelToMentorModel(mentor)).ToList();
        }

        public MentorModel GetMentorDetails(int mentorId)
        {
            var mentor = _mentorRepository.GetAll().SingleOrDefault(x => x.Id == mentorId);
            if (mentor == null)
            {
                throw new MentorException($"Mentor with id:{mentorId} was not found"); 
            }
            var mentorModel = MentorMapper.MentorModelToMentorModel(mentor);

            return mentorModel;
        }

        public void UpdateMentor(MentorModel mentor)
        {
            var mentorDetails = _mentorRepository.GetAll().SingleOrDefault(x => x.Id == mentor.Id);
            if (mentorDetails == null)
            {
                throw new MentorException("Mentor was not found");
            }

            var mappedMentor = MentorMapper.MentorModelToMentorModel(mentor);
            _mentorRepository.Update(mappedMentor);
        }
    }
}
