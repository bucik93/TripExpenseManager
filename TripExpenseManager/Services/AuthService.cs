using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripExpenseManager.Models;

namespace TripExpenseManager.Services
{
    public class AuthService
    {
        private const string LoggedInKey = "logged-in";
        private readonly IPreferences _preferences;
        private readonly DatabaseContext _context;

        public AuthService(DatabaseContext context)
        {
            _preferences = Preferences.Default;
            _context = context;
        }

        public bool IsSignedIn => Preferences.ContainsKey(LoggedInKey);

        public async Task<MethodResult> SignUpAsync(SignUpModel model)
        {
            var user = new User
            {
                Name = model.Name,
                UserName = model.UserName,
                Password = model.Password
            };

            if(await _context.AddItemAsync<User>(user)){

                SetUser(user);
                return MethodResult.Success();
            }

            return MethodResult.Fail(null);
        }
        public async Task<MethodResult> SignInAsync(SignInModel model)
        {           
            var users = await _context.GetFileteredAsync<User>(u =>u.UserName == model.UserName && u.Password  == model.Password);
            var user = users.FirstOrDefault();

            if(user is not null) 
            {
                SetUser(user);
                return MethodResult.Success();
            }
            return MethodResult.Fail("Incorrect credentials");
        }

        private void SetUser(User user)
        {
            var loggedUser = new LoggedInUser(user.Id, user.Name);
            
            _preferences.Set(LoggedInKey, loggedUser.ToJson());
        }
        public void SignOut()
        {
            _preferences.Remove(LoggedInKey);
        }
    }
}
