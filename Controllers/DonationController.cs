using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using share_a_plate_backend.Interfaces;

namespace share_a_plate_backend.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class DonationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService, IMapper mapper, IAuthorizationService authorizationService)
        {
            _donationService = donationService;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        // GET : Api/IDonation-List -> get all donations
        [Authorize]
        [HttpGet("IDonation-List")]
        public async Task<IActionResult> GetIndividualDonations()
        {
            try
            {
                var donations = await _donationService.GetIndividualDonations();
                if (donations == null)
                {
                    return NotFound("No donations found");
                }
                return Ok(donations);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // GET : Api/ODonation-List -> get all donations
        [Authorize]
        [HttpGet("ODonation-List")]
        public async Task<IActionResult> GetOrganizationDonations()
        {
            try
            {
                var donations = await _donationService.GetOrganizationDonations();
                if (donations == null)
                {
                    return NotFound("No donations found");
                }
                return Ok(donations);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
