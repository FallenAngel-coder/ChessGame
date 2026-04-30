using ChessGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Services.Interfaces.Factories
{
    public interface IViewModelFactory<Param>
    {
        BaseViewModel CreateViewModelWithParams(Param param);
    }
}
