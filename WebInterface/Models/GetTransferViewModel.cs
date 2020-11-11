using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebInterface.Models
{
    public class GetTransferViewModel
    {
        [Required]
        public string CNP { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
