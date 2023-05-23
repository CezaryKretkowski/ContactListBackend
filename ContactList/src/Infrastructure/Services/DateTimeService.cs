using ContactList.Application.Common.Interfaces;

namespace ContactList.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
