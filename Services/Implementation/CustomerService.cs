using AutoMapper;
using Data.Repositories.Abstract;
using Domain.Dto.Customer;
using Domain.Dto.Pagination;
using Domain.Entity;
using Services.Abstract;

namespace Services.Implementation;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(CustomerDto entity)
    {
        var customer = _mapper.Map<Customer>(entity);
        await _customerRepository.AddAsync(customer);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<CustomerDto>>(customers);
        return result;
    }

    public async Task<CustomerDto> GetByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<PaginatedResult<CustomerDto>> GetPageAsync(PagedRequest query,
        CancellationToken cancellationToken)
    {
        var pagedCustomers = await _customerRepository.GetPagedData(query, cancellationToken);

        return _mapper.Map<PaginatedResult<CustomerDto>>(pagedCustomers);
    }

    public Task<bool> RemoveAsync(int id, int issuerId)
    {
        return _customerRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(CustomerDto entity)
    {
        var result = _mapper.Map<Customer>(entity);
        await _customerRepository.UpdateAsync(result);
    }
}