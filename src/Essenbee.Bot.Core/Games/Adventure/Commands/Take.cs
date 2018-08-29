﻿using Essenbee.Bot.Core.Games.Adventure.Interfaces;
using Essenbee.Bot.Core.Games.Adventure.Items;
using System.Linq;

namespace Essenbee.Bot.Core.Games.Adventure.Commands
{
    public class Take : BaseAdventureCommand
    {
        public Take(IReadonlyAdventureGame game, params string[] verbs) : base(game, verbs)
        {
        }

        public override void Invoke(AdventurePlayer player, ChatCommandEventArgs e)
        {
            var location = player.CurrentLocation;
            var item = e.ArgsAsList[1].ToLower();

            var locationItem = location.Items.FirstOrDefault(i => i.IsMatch(item));
            var containers = location.Items.Where(i => i.IsContainer && i.Contents.Count > 0).ToList();

            if (locationItem != null && player.Inventory.GetItems().Any(i => i.ItemId.Equals(locationItem.ItemId)))
            {
                player.ChatClient.PostDirectMessage(player.Id, $"You are already carrying a {item} with you.");
                return;
            }

            foreach (var container in containers)
            {
                foreach (var containedItem in container.Contents)
                {
                    if (containedItem.IsMatch(item) && containedItem.IsPortable)
                    {
                        player.Inventory.AddItem(containedItem);
                        container.Contents.Remove(containedItem);
                        player.ChatClient.PostDirectMessage(player.Id, $"You are now carrying a {item} with you.");

                        return;
                    }
                }
            }

            if (locationItem is null)
            {
                player.ChatClient.PostDirectMessage(player.Id, $"You cannot see a {item} here!");
                return;
            }

            if (!locationItem.IsPortable)
            {
                player.ChatClient.PostDirectMessage(player.Id, $"You cannot carry the {item} with you!");
                return;
            }

            if (ContainerRequired(locationItem) && !HasRequiredContainer(player, locationItem))
            {
                player.ChatClient.PostDirectMessage(player.Id, $"You have no way of carrying a {item} with you...");
                return;
            }

            player.ChatClient.PostDirectMessage(player.Id, $"You are now carrying a {item} with you.");

            if (locationItem.IsEndlessSupply)
            {
                CreateNewInstance(player, locationItem);
                return;
            }

            var success = ContainerRequired(locationItem)
                ? player.Inventory.AddItemToContainer(locationItem, locationItem.MustBeContainedIn)
                : player.Inventory.AddItem(locationItem);

            player.CurrentLocation.Items.Remove(locationItem);
        }

        private static bool ContainerRequired(AdventureItem locationItem) => locationItem.MustBeContainedIn != Item.None;

        private static bool HasRequiredContainer(AdventurePlayer player, AdventureItem locationItem) =>
            player.Inventory.GetItems().Any(i => i.ItemId == locationItem.MustBeContainedIn);
        
        private void CreateNewInstance(AdventurePlayer player, AdventureItem locationItem)
        {
            if (locationItem.MustBeContainedIn != Item.None)
            {
                player.Inventory.AddItemToContainer(ItemFactory.GetInstance(_game, locationItem.ItemId),
                    locationItem.MustBeContainedIn);
            }
            else
            {
                player.Inventory.AddItem(ItemFactory.GetInstance(_game, locationItem.ItemId));
            }
        }
    }
}
