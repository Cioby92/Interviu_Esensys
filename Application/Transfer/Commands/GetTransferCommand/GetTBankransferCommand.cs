using Essensys.Application.Common.Exceptions;
using Essensys.Application.Common.Interfaces;
using Essensys.Application.Transfer.Commands.CreateBankTransfer;
using Essensys.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Essensys.Application.Transfer.Commands.GetTransferCommand
{
    public class GetBankTransferCommand : IRequest<TransferModel>
    {
        public string CNP { get; set; }
        public string Token { get; set; }

    }
    public class GetBankTransferCommandHandler : IRequestHandler<GetBankTransferCommand, TransferModel>
    {
        private readonly IApplicationDbContext _applicationContext;
        private readonly IIdentityService _Identity;

        public GetBankTransferCommandHandler(IApplicationDbContext applicationDbContext, IIdentityService identity)
        {
            _Identity = identity;
            _applicationContext = applicationDbContext;
        }
        public async Task<TransferModel> Handle(GetBankTransferCommand request, CancellationToken cancellationToken)
        {
            Token token = await _applicationContext.Tokens.FirstOrDefaultAsync(x => x.Id == Int32.Parse(request.Token));
            if (token == null)
                return null;
            if (token.ExpirationDate < DateTime.Now)
                throw new TokenExpiredException($"Token {token.Id} is expired");
            Transaction transaction =await _applicationContext.Transactions.FirstOrDefaultAsync(x => x.Id == token.TransactionID);
            TransferModel returnModel = new TransferModel()
            {
                Id=transaction.Id,
                Ammount = transaction.Ammount,
                Destinatar_id = transaction.Destinatar_id,
                DestinationCurrency = transaction.DestinationCurrency,
                SourceCurrency = transaction.SourceCurrency,
                FinalAmmount = transaction.FinalAmmount,
                Status = transaction.Status
            };
           // returnModel.Iban = _applicationContext.Accounts.FirstOrDefaultAsync(x => x.UserId == token.Transaction.Destinatar_id).Result.IBAN;
       
            return returnModel;
        }
    }
}
