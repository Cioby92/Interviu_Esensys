using Essensys.Application.Common.Enums;
using Essensys.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebInterface.Models
{
    public class TransferViewModel
    {
        [Required]
        [Display(Name ="IBAN")]
        public string Iban { get; set; }
        [Required]
        [Remote(action:"VerifyCNP", controller:"ExternalValidate",ErrorMessage ="CNP does not exist")]
        public string CNP { get; set; }
        [Required]
        public float Ammount { get; set; }
        [Required]
        public Currency SourceCurrency { get; set; }
        [Required]
        public Currency DestinationCurrency { get; set; }
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept terms and condittion")]
        public bool TermsAndCondition { get; set; }
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must be at least 18 years old")]
        public bool Over18 { get; set; }
    }
}
