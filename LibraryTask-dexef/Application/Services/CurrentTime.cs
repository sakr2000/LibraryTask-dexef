using LibraryTask_dexef.Application.Common.Interfaces;

namespace LibraryTask_dexef.Application.Services
{

    public class CurrentTime : ICurrentTime
    {
        public DateTime GetCurrentTime() => DateTime.UtcNow;
    }
}