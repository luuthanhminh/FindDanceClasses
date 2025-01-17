﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace FindDanceClasses.Core.Helpers
{
    public class AppSettings
    {
        private static ISettings Settings => CrossSettings.Current;



        #region Token

        public static string Token
        {
            get => Settings.GetValueOrDefault(nameof(Token), string.Empty);
            set => Settings.AddOrUpdateValue(nameof(Token), value);
        }

        #endregion

        #region UserId

        public static string UserId
        {
            get => Settings.GetValueOrDefault(nameof(UserId), string.Empty);
            set => Settings.AddOrUpdateValue(nameof(UserId), value);
        }

        #endregion

        #region DefaultListID

        public static int DefaultListID
        {
            get => Settings.GetValueOrDefault(nameof(DefaultListID), 0);
            set => Settings.AddOrUpdateValue(nameof(DefaultListID), value);
        }

        #endregion


        #region IsConnected

        public static bool IsConnected
        {
            get => Settings.GetValueOrDefault(nameof(IsConnected), false);
            set => Settings.AddOrUpdateValue(nameof(IsConnected), value);
        }

        #endregion





    }
}
