﻿using Essenbee.Bot.Core.Games.Adventure.Interfaces;
using System.Collections.Generic;

namespace Essenbee.Bot.Core.Games.Adventure.Locations
{
    public class Forest2 : AdventureLocation
    {
        public Forest2(IReadonlyAdventureGame game) : base(game)
        {
            LocationId = Location.Forest2;
            Name = "Forest";
            ShortDescription = "in open forest";
            LongDescription = "in open forest near both a valley and a road.";
            Items = new List<AdventureItem>();
            ValidMoves = new List<PlayerMove> {
                new PlayerMove(Location.Valley, "valley", "west", "w", "down", "d", "east", "e"),
                new PlayerMove(Location.Forest, "forest", "south", "s"),
                new PlayerMove(Location.Road, "road", "n", "north"),
            };
        }
    }
}