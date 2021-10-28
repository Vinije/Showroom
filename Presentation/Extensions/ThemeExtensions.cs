namespace Showroom.Presentation.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Showroom.Presentation.Themes;

    public static class ThemeExtensions
    {
        public static IServiceCollection AddThemeManager(this IServiceCollection collection)
        {
            return collection.AddSingleton<IThemeManager>(new ThemeManager());
        }
    }
}
