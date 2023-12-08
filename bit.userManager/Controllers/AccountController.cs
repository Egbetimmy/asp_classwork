using bit.userManager.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bit.userManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountService;
        public AccountController(IAccount account)
        {
            _accountService = account;
        }

        [HttpGet("add-account-number")]
        public IActionResult getAccountNumber()
        {
            return Ok(_accountService.accountNumber("93645738829"));
        }
    }
}
