using Domain.Dto.Customer;
using Services.Abstract.Base;

namespace Services.Abstract;

public interface ICustomerService : IBaseService<CustomerDto>
{
}