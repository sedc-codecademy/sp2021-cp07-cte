using Psyent.DataModels;
using Psyent.Models;

namespace Psyent.Services.Mapper
{
    public static class MentorMapper
    {
        public static MentorModel MentorModelToMentorModel(Mentor mentor)
        {
            return new MentorModel
            {
                Id = mentor.Id,
                FirstName = mentor.FirstName,
                LastName = mentor.LastName,
                Description = mentor.Description,
                Address = mentor.Address,
                MentorType = mentor.MentorType,
                AreaOfExpertise = mentor.AreaOfExpertise,
                SessionAvailability = mentor.SessionAvailability,
                YearsOfExperiance = mentor.YearsOfExperiance,
                Price = mentor.Price,
                Email = mentor.Email,
                Facebook = mentor.Facebook,
                Linkedin = mentor.Linkedin,
                Twitter = mentor.Twitter,
                Phone = mentor.Phone,
                Mobile = mentor.Mobile,
                Image = mentor.Image
            };
        }

        public static Mentor MentorModelToMentorModel(MentorModel mentor)
        {
            return new Mentor
            {
                Id = mentor.Id != 0 ? mentor.Id : 0,
                FirstName = mentor.FirstName,
                LastName = mentor.LastName,
                Description = mentor.Description,
                Address = mentor.Address,
                MentorType = mentor.MentorType,
                AreaOfExpertise = mentor.AreaOfExpertise,
                SessionAvailability = mentor.SessionAvailability,
                YearsOfExperiance = mentor.YearsOfExperiance,
                Price = mentor.Price,
                Email = mentor.Email,
                Facebook = mentor.Facebook,
                Linkedin = mentor.Linkedin,
                Twitter = mentor.Twitter,
                Phone = mentor.Phone,
                Mobile = mentor.Mobile,
                Image = mentor.Image
            };
        }
    }
}
