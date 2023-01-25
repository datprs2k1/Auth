using AutoMapper;
using POST.Data;
using POST.Models;

namespace POST.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ApplicationUser, UserModel>();
        }
    }
}
