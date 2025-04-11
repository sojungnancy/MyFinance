using backend.Models;
using backend.Models.DTOs;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;


namespace backend.Models.DTOs
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }= string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Memo { get; set; }
        public int UserId { get; set; }
}
}
