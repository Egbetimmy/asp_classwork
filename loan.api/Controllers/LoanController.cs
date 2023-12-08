using loan.api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace loan.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly loanContext _con;

        public LoanController(loanContext con) 
        { 
            _con = con;
        }
        // GET: api/<LoanController>
        [HttpGet("get-all-loans")]
        public IActionResult GetAllLoans()
        {
            return Ok(_con.Loans.ToList());
        }

        // GET api/<LoanController>/5
        [HttpGet("get-loan-by/{id}")]
        public IActionResult GetLoanById(int id)
        {
            var loan = _con.Loans.Where(x => x.Id == id);
            return Ok(loan);
        }

        // POST api/<LoanController>
        [HttpPost("add-loan")]
        public IActionResult Post([FromBody] Loan model)
        {
            _con.Loans.Add(model);
            var l = _con.SaveChanges();
            return Ok(model);
        }

        // PUT api/<LoanController>/5
        [HttpPut("update-loan/{id}")]
        public IActionResult UpdateLoan([FromBody] Loan model)
        {
            var loan = _con.Loans.Where(x => x.Id == model.Id).FirstOrDefault();
            if (loan != null)
            {
                loan.FullName = model.FullName;
                loan.LoanAmount = model.LoanAmount;
                _con.Update(loan);
                var l = _con.SaveChanges();
                if (l > 0) {
                    return Ok("Updated successful");
                }
                else
                {
                    return BadRequest("");
                }
            }
            else
            {
                return Ok("Loan not found");
            }
        }

        // DELETE api/<LoanController>/5
        [HttpDelete("Delete-loan/{id}")]
        public IActionResult DeleteLoan(int id)
        {
            return Ok();
        }
    }
}
