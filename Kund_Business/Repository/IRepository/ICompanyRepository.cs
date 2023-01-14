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
        public CompanyDTO Create(CompanyDTO objDTO);
        public CompanyDTO Update(CompanyDTO objDTO);
        public int Delete(int id);
        public CompanyDTO Get(int id);
        public IEnumerable<CompanyDTO> GetAll();
    }
}
