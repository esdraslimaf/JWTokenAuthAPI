using AuthApi.Models;

namespace AuthApi.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            //SIMULAR O ACESSO AO BANCO
            var users = new List<User>()
            {
                new User(){Id=1,Username="esdras", Password="lima", Role="gerente"},
                new User(){Id=2, Username="lima", Password="lima",Role="funcionario"}

            };

            return users.FirstOrDefault(x => x.Username == username && x.Password == password)!;
        }
    }
}
