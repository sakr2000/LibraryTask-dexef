using libraryTask_dexef.Application.Common.Interfaces;

namespace libraryTask_dexef.Application.Services
{

    public class CurrentTime : ICurrentTime
    {
        public DateTime GetCurrentTime() => DateTime.UtcNow;
    }
}