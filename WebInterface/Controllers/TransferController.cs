using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essensys.Application.Common.Interfaces;
using Essensys.Application.Transfer.Commands.CreateBankTransfer;
using Essensys.Application.Transfer.Commands.GetTransferCommand;
using Essensys.Application.Users.Commands;
using Essensys.WebInterface.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Models;
using Essensys.Application.Common.Exceptions;

namespace WebInterface.Controllers
{
    public class TransferController : BaseController
    {
        ICurrentUserService _currentUserService;

        public TransferController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Transfer()
        {
            return View("TransferView");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            try
            {
                VerifyCNPCommand exist = new VerifyCNPCommand()
                {
                    CNP = model.CNP
                };
                bool CNPValid = await Mediator.Send(exist);
                if (!CNPValid)
                    ModelState.AddModelError("CNP", "CNP does not Exist");
                if (!TryValidateModel(model, nameof(model)))
                    return View("transferView", model);

                CreateTransferCommand cmd = new CreateTransferCommand()
                {
                    Ammount = model.Ammount,
                    CNP = model.CNP,
                    DestinationCurrency = model.DestinationCurrency.ToString(),
                    SourceCurrency = model.SourceCurrency.ToString(),
                    Iban = model.Iban,
                    SourceUserID = _currentUserService.UserId
                };
                int token=await Mediator.Send(cmd);
                SuccesTransferViewModel succesmodel = new SuccesTransferViewModel()
                {
                    Token = token,
                };
                return View("SuccesTransfer",succesmodel);
            }
            catch (Exception e)
            {
                return View("Error");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetTransfer()
        {
            return View("GetTransfer");
        }
        [HttpPost]
        public async Task<IActionResult> GetTransfer(GetTransferViewModel model)
        {
            if (!TryValidateModel(model, nameof(model)))
                return View("GetTransfer", model);
            try
            {
                TransferModel returnValues = await Mediator.Send(new GetBankTransferCommand() { CNP = model.CNP, Token = model.Token });
                ViewTransferViewModel returnModel = new ViewTransferViewModel()
                {
                    TransactionId = returnValues.Id,
                    Destinatar = returnValues.Destinatar_id,
                    DestinationCurrency = returnValues.DestinationCurrency,
                    FinalAmmount = returnValues.FinalAmmount,
                    InnitialAmmount = returnValues.Ammount,
                    SourceCurrency = returnValues.SourceCurrency
                };
                ViewBag.TokenExpired = false;
                return View("ViewTransfer", returnModel);
            }
            catch(Exception e) when (e.InnerException is TokenExpiredException)
            {
                ViewBag.TokenExpired = true;
                return View("ViewTransfer", new ViewTransferViewModel());
            }
    
        }
    }
}
