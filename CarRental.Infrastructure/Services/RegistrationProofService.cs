using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public class RegistrationProofService : IRegistrationProofService
    {
        private readonly IRegistrationProofRepository _registrationProofRepository;
        public RegistrationProofService(IRegistrationProofRepository registrationProofRepository)
        {
            _registrationProofRepository = registrationProofRepository;
        }
        public async Task Add(CreateRegistrationProof r)
        {
            RegistrationProof registrationProof = null;
            try
            {
                registrationProof = new RegistrationProof()
                {
                    Id = r.Id,
                    FirstRegistrationDate = r.FirstRegistrationDate,
                    Plate = r.Plate,
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _registrationProofRepository.AddAsync(registrationProof);
        }

        public async Task<IEnumerable<RegistrationProofDTO>> BrowseAll()
        {
            var r = await _registrationProofRepository.BrowseAllAsync();

            return r.Select(x => new RegistrationProofDTO()
            {
                Id = x.Id,
                FirstRegistrationDate = x.FirstRegistrationDate,
                Plate = x.Plate,
            });
        }

        public async Task Delete(int id)
        {
            await _registrationProofRepository.DeleteAsync(id);

        }

        public async Task<RegistrationProofDTO> Get(int id)
        {
            var r = await _registrationProofRepository.GetAsync(id);

            if (r == null)
            {
                return null;
            }

            return MapDomain.mapRegistrationProofToDTO(r);
        }

        public async Task Update(UpdateRegistrationProof r, int id)
        {
            RegistrationProof registrationProof = null;
            try
            {
                registrationProof = new RegistrationProof()
                {
                    Id = id,
                    FirstRegistrationDate = r.FirstRegistrationDate,
                    Plate = r.Plate,
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _registrationProofRepository.UpdateAsync(registrationProof);
        }
    }
}
