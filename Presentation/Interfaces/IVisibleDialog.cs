namespace Showroom.Presentation.Interfaces
{
    using Microsoft.AspNetCore.Components;

    public interface IVisibleDialog
    {
        bool IsVisible { get; set; }

        EventCallback AddProjectCloseEvent { get; set; }

        void Hide();

        void Show();
    }
}
