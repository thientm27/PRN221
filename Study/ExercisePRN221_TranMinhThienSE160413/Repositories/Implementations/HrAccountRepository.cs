
using BusinessObject.Models;
using DataAccessObject;

namespace Repositories.Implementations
{
    public class HrAccountRepository : IHrAccountRepository
    {
        public Hraccount Login(string email, string password)
        {
           return HraccountDao.Instance.Login(email, password);
        }
    }
}
