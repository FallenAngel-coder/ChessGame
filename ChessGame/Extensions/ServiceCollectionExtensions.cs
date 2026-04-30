using ChessGame.Model;
using ChessGame.Model.Abstractions;
using ChessGame.Model.Data;
using ChessGame.Model.MoveStrategies;
using ChessGame.Model.Rules;
using ChessGame.Services;
using ChessGame.Services.Abstractions;
using ChessGame.Services.DTO.Handlers;
using ChessGame.Services.DTO.Messages;
using ChessGame.Services.Implementations;
using ChessGame.Services.Implementations.Factories;
using ChessGame.Services.Implementations.Game;
using ChessGame.Services.Implementations.Network;
using ChessGame.Services.Implementations.Utils;
using ChessGame.Services.Interfaces;
using ChessGame.Services.Interfaces.Factories;
using ChessGame.Services.Interfaces.Utils;
using ChessGame.ViewModel;
using ChessGame.ViewModel.Game;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ChessGame.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all services that are not factories, strategies, rules or message handlers
        /// </summary>
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<INetworkService, TcpNetworkService>();
            services.AddSingleton<ISettingsService, SettingsService>();

            services.AddSingleton<IDtoResolver, DtoResolver>();
            services.AddSingleton<IMessageDispatcher, MessageDispatcher>();

            services.AddSingleton<ILobbyService, LobbyService>();
            services.AddSingleton<IGameService, GameService>();
            services.AddSingleton<IChessRulesService, ChessRulesService>();
            services.AddSingleton<IGameHistoryService, GameHistoryService>();
            services.AddSingleton<IMoveService, MoveService>();

            return services;
        }

        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddSingleton<IBoardFactory, BoardFactory>();
            services.AddSingleton<IGameStateFactory, GameStateFactory>();
            services.AddSingleton<IMoveFactory, MoveFactory>();
            services.AddSingleton<IPieceFactory, PieceFactory>();

            services.AddTransient<ISubPieceFactory, PawnFactory>();
            services.AddTransient<ISubPieceFactory, RookFactory>();
            services.AddTransient<ISubPieceFactory, KnightFactory>();
            services.AddTransient<ISubPieceFactory, BishopFactory>();
            services.AddTransient<ISubPieceFactory, QueenFactory>();
            services.AddTransient<ISubPieceFactory, KingFactory>();

            return services;
        }

        /// <summary>
        /// Registers all IMoveStrategy implementations
        /// </summary>
        public static IServiceCollection AddMoveStrategies(this IServiceCollection services)
        {
            var strategyType = typeof(IMoveStrategy);

            var strategies = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t =>
                    !t.IsAbstract &&
                    !t.IsInterface &&
                    strategyType.IsAssignableFrom(t))
                .ToList();

            foreach (var strategy in strategies)
            {
                services.AddSingleton(typeof(IMoveStrategy), strategy);
            }

            return services;
        }

        public static IServiceCollection AddEndGameRules(this IServiceCollection services)
        {
            services.AddSingleton<IEndGameRulePipeline, EndGameRulePipeline>();

            services.AddTransient<IEndGameRule, CheckmateRule>();
            services.AddTransient<IEndGameRule, StalemateRule>();
            services.AddTransient<IEndGameRule, RepetitionRule>();
            services.AddTransient<IEndGameRule, InsufficientMaterial>();

            return services;
        }

        public static IServiceCollection AddMessageHandlers(this IServiceCollection services)
        {
            services.AddTransient<IMessageHandler<DtoStartGame>, StartGameHandler>();
            services.AddTransient<IMessageHandler<DtoNormalMove>, NormalMoveHandler>();
            services.AddTransient<IMessageHandler<DtoDoubleMove>, DoubleMoveHandler>();
            services.AddTransient<IMessageHandler<DtoEnPassantMove>, DtoEnPassantMoveHandler>();
            services.AddTransient<IMessageHandler<DtoPromotionMove>, PromotionMoveHandler>();

            services.AddTransient<ISpecificDtoMoveFactory, DtoNormalMoveFactory>();
            services.AddTransient<ISpecificDtoMoveFactory, DtoPromotionMoveFactory>();
            services.AddTransient<ISpecificDtoMoveFactory, DtoDoubleMoveFactory>();
            services.AddTransient<ISpecificDtoMoveFactory, DtoEnPasssantMoveFactory>();
            services.AddTransient<IDtoMoveFactory, DtoMoveDispatcher>();

            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddSingleton<IViewModelFactory<LobbyParams>, LobbyViewModelFactory>();
            services.AddSingleton<IViewModelFactory<GameResult>, EndResultViewModelFactory>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<MenuViewModel>();
            services.AddTransient<EndResultViewModel>();
            services.AddTransient<SearchGameViewModel>();
            services.AddTransient<LobbyViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<GameViewModel>();

            return services;
        }
    }
}