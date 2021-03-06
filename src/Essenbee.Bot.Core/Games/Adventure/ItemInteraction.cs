﻿using Essenbee.Bot.Core.Games.Adventure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Essenbee.Bot.Core.Games.Adventure
{
    public class ItemInteraction : IInteraction
    {
        public List<string> Verbs { get; }
        public IReadonlyAdventureGame Game { get; }
        public IList<IAction> RegisteredInteractions { get; set; }

        public ItemInteraction(IReadonlyAdventureGame game, params string[] verbs)
        {
            Game = game;
            Verbs = verbs.ToList();
            RegisteredInteractions = new List<IAction>();
        }
        
        public bool IsMatch(string verb) => Verbs.Any(v => verb.Equals(v));

        public bool ShouldExecute() => true;
    }
}
