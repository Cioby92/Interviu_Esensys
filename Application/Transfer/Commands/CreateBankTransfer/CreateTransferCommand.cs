using Essensys.Application.Common.Enums;
using Essensys.Application.Common.HttpClients;
using Essensys.Application.Common.Interfaces;
using Essensys.Application.Common.Models;
using Essensys.Domain.Entities;
using Essensys.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Essensys.Application.Transfer.Commands.CreateBankTransfer
{
    public class CreateTransferCommand : IRequest<int>
    {
        public string Iban { get; set; }
        public string CNP { get; set; }
        public float Ammount { get; set; }
        public string SourceCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public string DestinationUserID { get; set; }
        public string SourceUserID { get; set; }
    }
    public class CreateBankTransferCommandHandler : IRequestHandler<CreateTransferCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _Identity;
        private readonly IExchangeApiClient _exchangeApiClient;
        private readonly IDateTime _datetime;

        public CreateBankTransferCommandHandler(IApplicationDbContext context, IIdentityService identity, IExchangeApiClient exchangeApiClient, IDateTime dateTime)
        {
            _Identity = identity;
            _context = context;
            _exchangeApiClient = exchangeApiClient;
            _datetime = dateTime;
        }

        public async Task<int> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var entity = new Transaction
            {
                Ammount = request.Ammount,
                DestinationCurrency = request.DestinationCurrency.ToString(),
                SourceCurrency = request.SourceCurrency.ToString(),
                Expeditor_id = request.SourceUserID,
                Destinatar_id = await _Identity.GetUserId(request.CNP),
                Status="Pending"
            };
            ResponseRates ConversionRate = await _exchangeApiClient.GetExchangeRate(request.SourceCurrency, request.DestinationCurrency);
            ResponseRates CommisionRate = new ResponseRates();
            if (request.SourceCurrency != Currency.EUR.ToString())
                CommisionRate = await _exchangeApiClient.GetExchangeRate(Currency.EUR.ToString(), request.DestinationCurrency);
            else
                CommisionRate.Rates.Add(Currency.EUR.ToString(), 1);
            entity.FinalAmmount = GenerateTotalAmmount(request.Ammount, ConversionRate, CommisionRate);


            var token = new Token()
            {
                Transaction = entity,
                ExpirationDate = _datetime.Now.AddDays(10),
                Expired = false
            };
            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            token.TransactionID = entity.Id;
            _context.Tokens.Add(token);
            await _context.SaveChangesAsync(cancellationToken);
            return token.Id;
        }

        //Should be in another place
        private float GenerateTotalAmmount(float Ammount, ResponseRates ConversionRate, ResponseRates commisionRate)
        {
            float FinalSum = 0;
            FinalSum = Ammount * ConversionRate.Rates.First().Value;
            if (FinalSum > 100)
                FinalSum -= 1 * commisionRate.Rates.First().Value;
            else
                FinalSum -= (FinalSum / 100) * commisionRate.Rates.First().Value;

            return FinalSum;
        }
    }
}
