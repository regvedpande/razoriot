using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestEmployeeManagement.Models
{
    public class ErrorLogModel
    {
        public int ErrorLogId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        public DateTime ErrorDate { get; set; }
        public int? UserId { get; set; }
    }
}