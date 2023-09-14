using Raizen.JDC.Letters.Infra.Data;
using ServiceSchedule.Domain.User;
using ServiceSchedule.Infra.Data.Context;

namespace ServiceSchedule.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ServiceScheduleContext context) : base(context)
        {
            
        }
    }
}
