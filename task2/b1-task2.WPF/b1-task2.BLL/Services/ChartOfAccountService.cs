using b1_task2.BLL.Models;
using b1_task2.DAL.Entities;
using b1_task2.DAL.Repositories;

namespace b1_task2.BLL.Services
{
    public class ChartOfAccountService : IService<ChartOfAccountDTO>
    {
        private readonly IRepository<ChartOfAccount> _chartOfAccountRepository;

        public ChartOfAccountService(IRepository<ChartOfAccount> chartOfAccountRepository)
        {
            _chartOfAccountRepository = chartOfAccountRepository;
        }
        public void Add(ChartOfAccountDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChartOfAccountDTO> GetAll()
        {
            var entities = _chartOfAccountRepository.GetAll();
            return entities.Select(entity => ConvertToDTO(entity));
        }

        public ChartOfAccountDTO GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        private ChartOfAccountDTO ConvertToDTO(ChartOfAccount entity)
        {
            ChartOfAccountDTO dto = new ChartOfAccountDTO
            {
                Id = entity.BankAccountNumber,
                Name = entity.Name,
                TypeAccount = entity.TypeAccount
            };
            return dto;
        }
    }
}
