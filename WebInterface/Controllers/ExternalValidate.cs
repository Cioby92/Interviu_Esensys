using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essensys.Application.Common.Interfaces;
using Essensys.Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebInterface.Controllers
{
    public class ExternalValidate : BaseController
    {
        ICurrentUserService _currentUserService;
        public ExternalValidate(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [AcceptVerbs("GET","POST")]
        public async Task<IActionResult> VerifyCNP(string CNP)
        {
            VerifyCNPCommand cmd = new VerifyCNPCommand()
            {
                CNP = CNP
            };
            bool exist = await Mediator.Send(cmd);
            return Json(exist);

        }
    }
}
