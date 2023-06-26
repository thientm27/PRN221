
using BusinessObject.Models;

namespace Repositories
{
    public interface IHrAccountRepository 
    {
        public Hraccount Login(string email, string password);
    }
}
