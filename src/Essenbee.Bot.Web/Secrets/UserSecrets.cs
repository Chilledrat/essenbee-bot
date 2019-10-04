﻿namespace Essenbee.Bot
{
    public class UserSecrets
    {
        public string SlackApiKey { get; set; }
        public string DiscordToken { get; set; }
        public string TwitchUsername { get; set; }
        public string TwitchToken { get; set; }
        public string TwitchChannel { get; set; }
        public string ProjectAnswerKey { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string TwitchClientId { get; set; }
        public string BaseTwitchApiUrl { get; set; }

        public UserSecrets()
        {

        }
    }
}
