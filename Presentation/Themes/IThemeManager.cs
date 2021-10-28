namespace Showroom.Presentation.Themes
{
    using System;
    using System.Collections.Generic;

    public interface IThemeManager
    {
        event Action<string> ThemeChanged;

        int CurrentThemeIndex { get; }

        string CurrentTheme { get; }

        IEnumerable<string> Themes { get; set; }

        void SwitchTheme(string themeName);

        void SwitchThemeNext();
    }
}
