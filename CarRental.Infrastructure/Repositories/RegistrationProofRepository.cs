using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;

namespace CarRental.Infrastructure.Repositories
{
    public class RegistrationProofRepository : IRegistrationProofRepository
    {
        private AppDbContext _appDbContext;
        public RegistrationProofRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(RegistrationProof r)
        {
            try
            {
                _appDbContext.RegistrationProof.Add(r);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<IEnumerable<RegistrationProof>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.RegistrationProof);

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.RegistrationProof.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<RegistrationProof> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.RegistrationProof.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(RegistrationProof r)
        {
            try
            {
                var rp = _appDbContext.RegistrationProof.FirstOrDefault(x => x.Id == r.Id);

                rp.FirstRegistrationDate = r.FirstRegistrationDate;
                rp.Plate = r.Plate;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch(Exception e)
            {
                await Task.FromException(e);
            }
        }
    }
}
