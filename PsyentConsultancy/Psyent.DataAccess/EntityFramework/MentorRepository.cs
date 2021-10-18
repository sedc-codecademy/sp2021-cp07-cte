using Psyent.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Psyent.DataAccess.EntityFramework
{
    public class MentorRepository : IRepository<Mentor>
    {
        private readonly PsyentDbContext _db;

        public MentorRepository(PsyentDbContext db)
        {
            _db = db;
        }

        public void Add(Mentor entity)
        {
            _db.Mentors.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Mentor entity)
        {
            Mentor mentor = _db.Mentors.SingleOrDefault(x => x.Id == entity.Id);
            if (mentor != null)
            {
                _db.Mentors.Remove(mentor);
                _db.SaveChanges();
            }
        }

        public List<Mentor> GetAll()
        {
            return _db.Mentors.ToList();
        }

        public void Update(Mentor entity)
        {
            Mentor mentor = _db.Mentors.SingleOrDefault(x => x.Id == entity.Id);
            if (mentor != null)
            {
                mentor.FirstName = entity.FirstName;
                mentor.LastName = entity.LastName;
                mentor.Description = entity.Description;
                mentor.Address = entity.Address;
                mentor.MentorType = entity.MentorType;
                mentor.AreaOfExpertise = entity.AreaOfExpertise;
                mentor.SessionAvailability = entity.SessionAvailability;
                mentor.YearsOfExperiance = entity.YearsOfExperiance;
                mentor.Price = entity.Price;
                mentor.Email = entity.Email;
                mentor.Facebook = entity.Facebook;
                mentor.Linkedin = entity.Linkedin;
                mentor.Twitter = entity.Twitter;
                mentor.Phone = entity.Phone;
                mentor.Mobile = entity.Mobile;
                mentor.Image = entity.Image;

                _db.SaveChanges();
    }
        }
    }
}
