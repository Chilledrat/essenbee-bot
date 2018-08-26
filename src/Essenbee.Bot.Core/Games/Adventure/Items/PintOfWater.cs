﻿namespace Essenbee.Bot.Core.Games.Adventure.Items
{
    public class PintOfWater : AdventureItem
    {
        public PintOfWater(IReadonlyAdventureGame game) : base(game)
        {
            ItemId = "water";
            Name = "pint of *water*";
            PluralName = "pin of *water*";
            IsPortable = false;
        }
    }
}
