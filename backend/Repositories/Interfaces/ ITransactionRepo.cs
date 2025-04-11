using backend.Models;

namespace backend.Repositories.Interfaces
{
    public interface ITransactionRepo
    {
        Task<Transaction> AddTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllByUserIdAsync(int userId);
    }
}
