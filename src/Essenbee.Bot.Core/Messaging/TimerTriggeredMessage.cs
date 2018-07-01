﻿using System;
using Essenbee.Bot.Core.Interfaces;

namespace Essenbee.Bot.Core.Messaging
{
    public class TimerTriggeredMessage : IAutoMessage
    {
        private DateTime _lastRun;

        public int Delay { get; set; }
        public string Message { get; set; }
        public ItemStatus Status { get; set; }

        public void Init(DateTime currentTime, ItemStatus status)
        {
            _lastRun = currentTime;
            Status = status;
        }

        public bool ShouldDisplay(DateTime currentTime)
        {
            return (_lastRun.AddMinutes(Delay) <= currentTime && 
                Status == ItemStatus.Active);
        }

        public string GetMessage(DateTime currentTime)
        {
            _lastRun = currentTime;
            return Message;
        }
    }
}
