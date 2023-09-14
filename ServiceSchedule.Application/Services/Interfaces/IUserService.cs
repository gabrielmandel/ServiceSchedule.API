using ServiceSchedule.Application.Models.UserModels.Requests;
using ServiceSchedule.Application.Models.UserModels.Responses;
using ServiceSchedule.Domain.User;
using System.Linq.Expressions;

namespace ServiceSchedule.Application.Services.Interfaces
{
    public interface IUserService
    {
        GetUserListResponse GetAll();

        Task<GetUserListResponse> Get(GetUserListRequest request);

        Task<GetUserResponse> GetByIDAsync(object id);

        Task InsertAsync(PostUserRequest entity);

        Task DeleteAsync(object id);

        Task DeleteAsync(User entity);

        Task UpdateAsync(User entity);

        User? Login(PostUserLoginRequest request);
    }
}
