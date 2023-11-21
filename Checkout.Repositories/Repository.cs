using Microsoft.Extensions.Logging;


namespace Repositories
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;
        public Repository(ILogger<Repository> logger)
        {
            _logger = logger;
        } 
    }
}
 