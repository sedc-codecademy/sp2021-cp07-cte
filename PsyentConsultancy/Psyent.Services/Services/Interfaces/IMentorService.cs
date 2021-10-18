using Psyent.Models;
using System.Collections.Generic;

namespace Psyent.Services.Services.Interfaces
{
    public interface IMentorService
    {
        List<MentorModel> GetAllMentors();
        MentorModel GetMentorDetails(int mentorId);
        string AddMentor(MentorModel mentor);
        string DeleteMentor(int mentorId);
        void UpdateMentor(MentorModel mentor);
    }
}
