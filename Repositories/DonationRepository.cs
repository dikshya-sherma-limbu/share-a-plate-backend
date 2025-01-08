using AutoMapper;
using Microsoft.EntityFrameworkCore;
using share_a_plate_backend.Data;
using share_a_plate_backend.Interfaces;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        //ApplicationDbContext  for database operations
        private readonly ApplicationDbContext _context;
        // IMapper for mapping objects
        private readonly IMapper _mapper;

        // Constructor injection for dependencies
        public DonationRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<List<IndividualDonation>> GetIndividualDonationsRepo()
        {
            try
            {
                // fetch list of individual donations from the repository
                var individualDonations = await _context.IndividualDonations.ToListAsync();
                return individualDonations;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrganizationDonation>> GetOrganizationDonationsRepo()
        {
            try
            {
                var organizationDonations = await _context.OrganizationDonations.ToListAsync();
                return organizationDonations;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
