using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Mediator.Queries.Profile;
using VerusDate.Shared.ModelQuery;

namespace VerusDate.Api.Function
{
    public class PublicFunction
    {
        private readonly IMediator _mediator;

        public PublicFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("PublicListDestaques")]
        public async Task<IActionResult> ListDestaques(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Public/ListDestaques")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = req.BuildRequestQuery<ProfileGetDestaquesCommand, List<ProfileSearch>>();

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result.Take(12));
            }
            catch (Exception ex)
            {
                log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }
    }
}