using Microsoft.AspNetCore.Identity;
using POST.Data;
using POST.Models;

namespace POST.Repositories
{
    public interface IUserRepository
    {
        public Task<IdentityResult> SignUpAsync(SignupModel model);
        public Task<string> SigninAsync(SigninModel model);

        public Task<UserModel> GetUserAsync(string email);

    }
}
