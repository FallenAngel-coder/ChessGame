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
    public class LobbyViewModelFactory : IViewModelFactory<LobbyParams>
    {
        private readonly IServiceProvider _serviceProvider;
        public LobbyViewModelFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseViewModel CreateViewModelWithParams(LobbyParams param)
        {
            var lobbyVM = _serviceProvider.GetRequiredService<LobbyViewModel>();


            lobbyVM.ConfigureAsync(param);

            return lobbyVM;
        }
    }
}
