using Essensys.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Essensys.Application.Users.Commands
{
    public class VerifyCNPCommand : IRequest<bool>
    {
        public string CNP { get; set; }
    }

    public class VerifyCNPCommandHandler : IRequestHandler<VerifyCNPCommand, bool>
    {
        private readonly IIdentityService _Identity;
        public VerifyCNPCommandHandler(IIdentityService identity)
        {
            _Identity = identity;
        }
        public async Task<bool> Handle(VerifyCNPCommand request, CancellationToken cancellationToken)
        {
            string userID=await _Identity.GetUserId(request.CNP);
            if (userID == null)
                return false;
            return true;
        }
    }
}
