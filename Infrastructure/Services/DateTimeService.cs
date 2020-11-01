using Essensys.Application.Common.Interfaces;
using System;

namespace Essensys.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
