using InterestCalculator.Domain.Commands;
using InterestCalculator.Domain.Handlers;
using InterestCalculator.Domain.Notifications;
using InterestCalculator.Test.Domain.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace InterestCalculator.Test.Domain.Handlers
{
    class InterestCalculatorHandlerTests
    {
        private InterestCalculatorHandler _handler;

        [SetUp]
        public void Setup() =>
            _handler = new InterestCalculatorHandler(new FakeInterestRateService());

        [Test]
        [Category("Handlers")]
        public async Task DadoUmComandoInvalidoSemValorParaCalculoESemQuantidadeDeMesesORetornoDeveSerDeFalhaComNotificacoes()
        {
            var commandInvalid = new CalculateInterestCommand();
            var commandResult = await _handler.Handle(commandInvalid, default);
            Assert.False(commandResult.Sucess && ((Notifiable)commandResult.Data).Notifications.Count == 2);
        }

        [Test]
        [Category("Handlers")]
        public async Task DadoUmComandoValidoComValorParaCalculoEComQuantidadeDeMesesORetornoDeveSerDeSucessoEResultadoFinalCentoECincoReaisComDezCentavos()
        {
            var commandValid = new CalculateInterestCommand(100m, 5);
            var commandResult = await _handler.Handle(commandValid, default);
            Assert.True(commandResult.Sucess && (decimal)commandResult.Data == 105.10m);
        }

        [Test]
        [Category("Handlers")]
        public async Task DadoUmComandoValidoComValorParaCalculoEComQuantidadeDeMesesORetornoDeveSerDeSucessoEResultadoFinalCentoECincoReaisComOnzeCentavos()
        {
            var commandValid = new CalculateInterestCommand(100.0123m, 5);
            var commandResult = await _handler.Handle(commandValid, default);
            Assert.True(commandResult.Sucess && (decimal)commandResult.Data == 105.11m);
        }

        [Test]
        [Category("Handlers")]
        public async Task DadoUmComandoValidoComValorParaCalculoEComQuantidadeDeMesesORetornoDeveSerDeSucessoEResultadoFinalCentoECincoReaisComUmCentavo()
        {
            var commandValid = new CalculateInterestCommand(100.0123m, 0);
            var commandResult = await _handler.Handle(commandValid, default);
            Assert.True(commandResult.Sucess && (decimal)commandResult.Data == 100.01m);
        }

        [Test]
        [Category("Handlers")]
        public async Task DadoUmComandoValidoComValorParaCalculoEComQuantidadeDeMesesORetornoDeveSerDeSucessoEResultadoFinalZeroReais()
        {
            var commandValid = new CalculateInterestCommand(0m, 5);
            var commandResult = await _handler.Handle(commandValid, default);
            Assert.True(commandResult.Sucess && (decimal)commandResult.Data == 0.00m);
        }

        [Test]
        [Category("Handlers")]
        public async Task DadoUmComandoValidoComValorParaCalculoEComQuantidadeDeMesesPoremComOServicoDeTaxaJurosOfflineORetornoDeveSerDeSucessoEResultadoFinalCemReais()
        {
            var commandValid = new CalculateInterestCommand(100m, 5);
            _handler = new InterestCalculatorHandler(new FakeInterestRateService(yourServiceIsOnline: false));
            var commandResult = await _handler.Handle(commandValid, default);
            Assert.True(commandResult.Sucess && (decimal)commandResult.Data == 100.00m);
        }
    }
}