using Kund_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kund_Business.Repository.IRepository
{
    public interface ICompanyRepository
    {
        public Task<CompanyDTO> Create(CompanyDTO objDTO);
        public Task<CompanyDTO> Update(CompanyDTO objDTO);
        public Task<int> Delete(int id);
        public Task<CompanyDTO> Get(int id);
        public Task<IEnumerable<CompanyDTO>> GetAll();
    }
}
