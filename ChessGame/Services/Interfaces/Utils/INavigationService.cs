using ChessGame.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Interfaces
{
    public interface INavigationService
    {
        BaseViewModel CurrentView { get; }
        event Action ViewChanged;
        void NavigateTo<T>() where T : BaseViewModel;
        void NavigateTo(BaseViewModel viewModel);
    }
}
