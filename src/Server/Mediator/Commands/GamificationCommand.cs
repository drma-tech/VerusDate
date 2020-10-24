using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;

namespace VerusDate.Server.Mediator.Commands
{
    #region ADD_DIAMOND

    public class GamificationAddDiamondCommand : IRequest<bool>
    {
        public string IdUser { get; set; }
        public short Qtd { get; set; }
    }

    public class GamificationAddDiamondHandler : IRequestHandler<GamificationAddDiamondCommand, bool>
    {
        private readonly IGamificationApp _app;

        public GamificationAddDiamondHandler(IGamificationApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(GamificationAddDiamondCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.AddDiamond(request.IdUser, request.Qtd, cancellationToken);
        }
    }

    #endregion ADD_DIAMOND

    #region ADD_FOOD

    public class GamificationExchangeFoodCommand : IRequest<bool>
    {
        public string IdUser { get; set; }
        public int QtdDiamond { get; set; }
    }

    public class GamificationExchangeFoodHandler : IRequestHandler<GamificationExchangeFoodCommand, bool>
    {
        private readonly IGamificationApp _app;

        public GamificationExchangeFoodHandler(IGamificationApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(GamificationExchangeFoodCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.ExchangeFood(request.IdUser, request.QtdDiamond, cancellationToken);
        }
    }

    #endregion ADD_FOOD
}