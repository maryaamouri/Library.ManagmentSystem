using AutoMapper;
using Libro.Domain.Transactions;
using Libro.Application.Common.Exceptions;
namespace Libro.Application.Transations
{
    public class TransationService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransationService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Guid id)
        {
            var transDto = GetByIdAsync(id);
            var trans = _mapper.Map<Transaction>(transDto);
            trans.DeleteTransaction();
            await _transactionRepository.SaveChangesAsync();
        }

        public async Task<TransactionDto> GetByIdAsync(Guid id)
        {
            var trans = await _transactionRepository.GetByIdAsync(id);
            if (trans is null)
                throw new NotFoundException(typeof(Transaction).Name, id);
            return _mapper.Map<TransactionDto>(trans);
        }

        public async Task<IList<TransactionDto>> GetListAsync()
        {
            var list = await _transactionRepository.GetAsync();
            if (list is null)
                throw new NotFoundException(typeof(Transaction).Name);
            return _mapper.Map<IList<TransactionDto>>(list);    
        }

        public async Task<TransactionDto> CreateAsync(TransactionRequest request)
        {
            if(request is null)
                throw new ArgumentNullException(nameof(request));
            var trans = await _transactionRepository.CreateAsync(_mapper.Map<Transaction>(request));
            await _transactionRepository.SaveChangesAsync();
            return _mapper.Map<TransactionDto>(trans);
        }

       public async Task<TransactionDto> UpdateAsync(Guid id, TransactionRequest request)
        {
            var transDto = GetByIdAsync(id);
            var trans = _mapper.Map<Transaction>(transDto);
            await _transactionRepository.UpdateAsync( trans);
            await _transactionRepository.SaveChangesAsync();
            return _mapper.Map<TransactionDto>(trans);
        }
    }
}
