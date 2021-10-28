namespace Showroom.Presentation.Themes
{
    using System;
    using System.Collections.Generic;

    public class ThemeManager : IThemeManager
    {
        private const string DefaultTheme = "dark";

        public event Action<string> ThemeChanged;

        public ThemeManager()
        {
            Themes = new[] { "light", "dark" };
            CurrentTheme = DefaultTheme;
            CurrentThemeIndex = 1;
        }

        public string CurrentTheme { get; private set; }

        public int CurrentThemeIndex { get; private set; }

        public IEnumerable<string> Themes { get; set; }

        public void SwitchThemeNext()
        {
            CurrentTheme = CurrentTheme == DefaultTheme ? "light" : DefaultTheme;
            ThemeChanged?.Invoke(CurrentTheme);
        }

        public void SwitchTheme(string themeName)
        {
            CurrentTheme = themeName;
        }
    }
}
