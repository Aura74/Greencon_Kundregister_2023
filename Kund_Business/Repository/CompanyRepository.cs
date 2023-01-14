using Kund_Business.Repository.IRepository;
using Kund_DataAccess;
using Kund_DataAccess.Data;
using Kund_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kund_Business.Repository.CompanyRepository;

namespace Kund_Business.Repository
{
    public class CompanyRepository :ICompanyRepository
    {
            private readonly ApplicationDbContext _db;

            public CompanyRepository(ApplicationDbContext db)
            {
                _db = db;
            }

            public CompanyDTO Create(CompanyDTO objDTO)
            {
            Companies company = new Companies()
                {
                    CompanyName = objDTO.CompanyName,
                    Id = objDTO.Id
                };

                _db.Company.Add(company);
                _db.SaveChanges();

                return new CompanyDTO()
                {
                    Id = company.Id,
                    CompanyName = company.CompanyName
                };
            }

            public int Delete(int id)
            {
                throw new NotImplementedException();
            }

            public CompanyDTO Get(int id)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<CompanyDTO> GetAll()
            {
                throw new NotImplementedException();
            }

            public CompanyDTO Update(CompanyDTO objDTO)
            {
                throw new NotImplementedException();
            }
        
    }
}
