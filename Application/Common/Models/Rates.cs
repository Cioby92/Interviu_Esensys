using System;
using System.Collections.Generic;
using System.Text;

namespace Essensys.Application.Common.Models
{
   public class ResponseRates
    {
        public ResponseRates()
        {
            Rates = new Dictionary<string, float>();
        }
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string,float> Rates { get; set; }
    }
}
