using TransactionService.Models;

namespace TransactionService.Repositories
{
    public interface IOperacoesRepository
    {
        Task<IEnumerable<Operacao>> GetOperacoes();
        Task<Operacao> GetOperacao(int id);
        Task<Operacao> CreateOperacao(Operacao operacao);
        Task<Operacao> UpdateOperacao(Operacao operacao);
        Task DeleteOperacao(int id);
    }
}
