﻿using Essenbee.Bot.Core.Games.Adventure.Interfaces;

namespace Essenbee.Bot.Core.Games.Adventure.Commands
{
    public class Carrying : BaseAdventureCommand
    {
        public Carrying(IReadonlyAdventureGame game, params string[] verbs) : base (game, verbs)
        {
            CheckEvents = false;
        }

        public override void Invoke(IAdventurePlayer player, ChatCommandEventArgs e)
        {
            player.ChatClient.PostDirectMessage(player, player.Inventory.ListItems());
        }
    }
}
