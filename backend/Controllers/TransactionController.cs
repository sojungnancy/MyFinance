using backend.Models;
using backend.Models.DTOs;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepo _repo;

        public TransactionController(ITransactionRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDto dto)
        {
            var transaction = new Transaction
            {
                Amount = dto.Amount,
                Type = dto.Type,
                Category = dto.Category,
                Date = dto.Date,
                Memo = dto.Memo,
                UserId = dto.UserId
            };
            

            var created = await _repo.AddTransactionAsync(transaction);
            return Ok(new { message = "Transaction created", id = created.id });
        }
    }
}
