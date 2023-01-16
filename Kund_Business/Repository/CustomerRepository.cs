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
using static Kund_Business.Repository.CustomerRepository;

namespace Kund_Business.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;

            public CustomerRepository(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<CustomerDTO> Create(CustomerDTO objDTO)
            {
                var obj = _mapper.Map<CustomerDTO, Customer>(objDTO);
                    obj.CreatedDate = DateTime.Now;
                var addedObj = _db.Customers.Add(obj);
                await _db.SaveChangesAsync();

                return _mapper.Map<Customer, CustomerDTO>(addedObj.Entity);
            }

            public async Task<int> Delete(int id)
            {
            var obj = await _db.Customers.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Customers.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
            }

            public async Task<CustomerDTO> Get(int id)
            {
                var obj = await _db.Customers.Include(u=>u.Companies).FirstOrDefaultAsync(u => u.Id == id);
                if (obj != null)
                {
                    return _mapper.Map<Customer, CustomerDTO>(obj);
                }
                return new CustomerDTO();
            }

            public async Task<IEnumerable<CustomerDTO>> GetAll()
            {
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(_db.Customers.Include(u => u.Companies));
            }

            public async Task<CustomerDTO> Update(CustomerDTO objDTO)
            {
                var objFromDb = await _db.Customers.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
                    if (objFromDb != null)
                    {
                        objFromDb.FirstName = objDTO.FirstName;
                        objFromDb.LastName = objDTO.LastName;
                        objFromDb.Desciption = objDTO.Desciption;
                        //objFromDb.CreatedDate = objDTO.CreatedDate;
                        objFromDb.ImageUrl = objDTO.ImageUrl;
                        objFromDb.CompaniesId = objDTO.CompaniesId;
                        _db.Customers.Update(objFromDb);
                        await _db.SaveChangesAsync();
                        return _mapper.Map<Customer, CustomerDTO>(objFromDb);
                    }
                return objDTO;
            }
    }
}
