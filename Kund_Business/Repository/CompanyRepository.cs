using AutoMapper;
using Kund_Business.Repository.IRepository;
using Kund_DataAccess;
using Kund_DataAccess.Data;
using Kund_Models;
using Microsoft.EntityFrameworkCore;
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

            public async Task<CompanyDTO> Create(CompanyDTO objDTO)
            {
                var obj = _mapper.Map<CompanyDTO, Companies>(objDTO);
                var addedObj = _db.Company.Add(obj);
                await _db.SaveChangesAsync();

                return _mapper.Map<Companies, CompanyDTO>(addedObj.Entity);
            }

            public async Task<int> Delete(int id)
            {
            var obj = await _db.Company.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Company.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
            }

            public async Task<CompanyDTO> Get(int id)
            {
                var obj = await _db.Company.FirstOrDefaultAsync(u => u.Id == id);
                if (obj != null)
                {
                    return _mapper.Map<Companies, CompanyDTO>(obj);
                }
                return new CompanyDTO();
            }

            public async Task<IEnumerable<CompanyDTO>> GetAll()
            {
            return _mapper.Map<IEnumerable<Companies>, IEnumerable<CompanyDTO>>(_db.Company);
            }

            public async Task<CompanyDTO> Update(CompanyDTO objDTO)
            {
                var objFromDb = await _db.Company.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
                    if (objFromDb != null)
                    {
                        objFromDb.CompanyName = objDTO.CompanyName;
                        _db.Company.Update(objFromDb);
                        await _db.SaveChangesAsync();
                        return _mapper.Map<Companies, CompanyDTO>(objFromDb);
                    }
                return objDTO;
            }
    }
}
