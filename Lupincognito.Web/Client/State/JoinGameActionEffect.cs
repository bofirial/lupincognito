﻿using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace Lupincognito.Web.Client.State
{
    public class JoinGameActionEffect : Effect<JoinGameAction>
    {
        private readonly NavigationManager _navigationManager;

        public JoinGameActionEffect(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public override Task HandleAsync(JoinGameAction action, IDispatcher dispatcher)
        {
            _navigationManager.NavigateTo($"game/{action.Name}");

            return Task.CompletedTask;
        }
    }
}