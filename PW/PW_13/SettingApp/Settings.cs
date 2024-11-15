using System;
using System.Collections.Generic;

namespace PW_13
{
    internal class Settings
    {
        private static Settings instance;
        private Dictionary<string, string> settings;

        private Settings() => settings = new Dictionary<string, string>();

        public static Settings GetInstance()
        {
            if (instance == null)
            {
                instance = new Settings();
            }
            return instance;
        }

        public string GetSetting(string key)
        {
            if (settings.ContainsKey(key))
            {
                return settings[key];
            }
            else
            {    
                return null;
            }
        }

        public void SetSetting(string key, string value)
        {
            if (settings.ContainsKey(key))
            {
                settings[key] = value;
            }
            else
            {
                settings.Add(key, value);
            }            
        }
                
        public void PrintSettings()
        {
            Console.WriteLine("Текущие настройки:");
            foreach (var kvp in settings)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
