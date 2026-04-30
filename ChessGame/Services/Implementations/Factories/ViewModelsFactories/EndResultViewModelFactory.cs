using ChessGame.Model;
using ChessGame.Model.Data;
using ChessGame.Services.Interfaces.Factories;
using ChessGame.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Implementations.Factories
{
    public class EndResultViewModelFactory : IViewModelFactory<GameResult>
    {
        private readonly IServiceProvider _serviceProvider;
        public EndResultViewModelFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseViewModel CreateViewModelWithParams(GameResult param)
        {
            var vm = _serviceProvider.GetRequiredService<EndResultViewModel>();

            vm.Initialize(param);

            return vm;
        }
    }
}
