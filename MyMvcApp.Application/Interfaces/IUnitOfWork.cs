using System.Threading.Tasks;

namespace MyMvcApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task<int> CompleteAsync();
    }
}
