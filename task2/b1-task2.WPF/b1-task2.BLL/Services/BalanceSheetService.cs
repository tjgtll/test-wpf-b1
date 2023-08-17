using b1_task2.BLL.Models;
using b1_task2.DAL.Entities;
using b1_task2.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1_task2.BLL.Services
{
    public class BalanceSheetService : IService<BalanceSheetDTO>
    {
        private readonly IRepository<BalanceSheet> _balanceSheetRepository;
        private readonly IRepository<BankAccountMovement> _bankAccountMovementRepository;

        public BalanceSheetService(
            IRepository<BalanceSheet> balanceSheetRepository,
            IRepository<BankAccountMovement> bankAccountMovementRepository)
        {
            _balanceSheetRepository = balanceSheetRepository;
            _bankAccountMovementRepository = bankAccountMovementRepository;
        }
        public void Add(BalanceSheetDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BalanceSheetDTO> GetAll()
        {
            var balance = _balanceSheetRepository.GetAll();
            IList<BalanceSheetDTO> result = new List<BalanceSheetDTO>();
            foreach (var item in balance)
            {
                result.Add(new BalanceSheetDTO()
                {
                    Id = item.Id.ToString(),
                    BankName = item.BankName,
                    StartDateTime = item.StartDateTime,
                    EndDateTime = item.EndDateTime,
                    FilePath = item.FilePath,
                    FileName = item.FileName,
                });
            }
            return result;
        }

        public BalanceSheetDTO GetById(Guid id)
        {
            var balance = _balanceSheetRepository.GetById(id);
            BalanceSheetDTO result = new BalanceSheetDTO()
            {
                Id              = balance.Id.ToString(),
                BankName        = balance.BankName,
                StartDateTime   = balance.StartDateTime,
                EndDateTime     = balance.EndDateTime,
                FilePath        = balance.FilePath,
                FileName        = balance.FileName,
                AccountMovement = GetBankAccountMovements(balance.Id)
            };
            return result;
        }

        private List<BankAccountMovementDTO> GetBankAccountMovements(Guid guid) 
        {
            var result = new List<BankAccountMovementDTO>();
            var accountMove  =_bankAccountMovementRepository.GetAll().Where(a => a.BalanceSheetId == guid);
            foreach (var item in accountMove)
            {
                result.Add(new BankAccountMovementDTO()
                {
                    OpeningBalanceActive = item.OpeningBalanceActive,
                    OpeningBalancePassive = item.OpeningBalancePassive,
                    TurnoverCredit = item.TurnoverCredit,
                    TurnoverDebit = item.TurnoverDebit,
                    СlosingBalanceActive = item.СlosingBalanceActive,
                    СlosingBalancePassive = item.СlosingBalancePassive,
                   BankAccountNumber  = item.BankAccountNumber
                });
            }
            return result;
        }
    }
}
