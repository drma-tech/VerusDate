﻿using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Mediator;
using VerusDate.Shared.Core;

namespace VerusDate.Api.Core
{
    public static class FunctionHelper
    {
        /// <summary>
        /// Cria uma instancia de classe mediator do tipo Query
        /// </summary>
        /// <typeparam name="I">IN = classe mediator</typeparam>
        /// <typeparam name="O">OUT = classe de retorno</typeparam>
        /// <param name="req">HttpRequest</param>
        /// <returns></returns>
        public static I BuildRequestQuery<I, O>(this HttpRequest req) where I : MediatorQuery<O>, new() where O : class
        {
            var obj = new I();

            obj.SetIds(req.GetUserId());
            obj.SetParameters(req.Query);

            return obj;
        }

        /// <summary>
        /// Cria uma instancia de classe mediator do tipo Command
        /// </summary>
        /// <typeparam name="I">IN = classe mediator</typeparam>
        /// <param name="req">HttpRequest</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public static async Task<I> BuildRequestCommand<I>(this HttpRequest req, CancellationToken cancellationToken) where I : CosmosBase
        {
            var obj = await JsonSerializer.DeserializeAsync<I>(req.Body, null, cancellationToken);

            //bool.TryParse(req.Query["enable_seed"], out bool enable_seed);

            //if (!enable_seed)
            obj.SetIds(req.GetUserId());

            return obj;
        }
    }
}