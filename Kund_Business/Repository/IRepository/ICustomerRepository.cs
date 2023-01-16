using Kund_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kund_Business.Repository.IRepository
{
    public interface ICustomerRepository
    {
        public Task<CustomerDTO> Create(CustomerDTO objDTO);
        public Task<CustomerDTO> Update(CustomerDTO objDTO);
        public Task<int> Delete(int id);
        public Task<CustomerDTO> Get(int id);
        public Task<IEnumerable<CustomerDTO>> GetAll();
    }
}
