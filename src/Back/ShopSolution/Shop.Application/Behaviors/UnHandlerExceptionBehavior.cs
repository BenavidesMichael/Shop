using MediatR;
using Microsoft.Extensions.Logging;

namespace Shop.Application.Behaviors
{
    public class UnHandlerExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnHandlerExceptionBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError("Application request error: {requestName} \n {request} \n {ex}", typeof(TRequest).Name, ex, request);
                throw;
            }
        }
    }
}