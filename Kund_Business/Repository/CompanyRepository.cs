using AutoMapper;
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
            private readonly IMapper _mapper;

            public CompanyRepository(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public CompanyDTO Create(CompanyDTO objDTO)
            {
                var obj = _mapper.Map<CompanyDTO, Companies>(objDTO);

                var addedObj = _db.Company.Add(obj);
                _db.SaveChanges();

                return _mapper.Map<Companies, CompanyDTO>(addedObj.Entity);
            }

            public int Delete(int id)
            {
            var obj = _db.Company.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                _db.Company.Remove(obj);
                return _db.SaveChanges();
            }
            return 0;
        }

            public CompanyDTO Get(int id)
            {
            var obj = _db.Company.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Companies, CompanyDTO>(obj);
            }
            return new CompanyDTO();
        }

            public IEnumerable<CompanyDTO> GetAll()
            {
            return _mapper.Map<IEnumerable<Companies>, IEnumerable<CompanyDTO>>(_db.Company);
        }

            public CompanyDTO Update(CompanyDTO objDTO)
            {
            var objFromDb = _db.Company.FirstOrDefault(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.CompanyName = objDTO.CompanyName;
                _db.Company.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<Companies, CompanyDTO>(objFromDb);
            }
            return objDTO;
        }
        
    }
}
