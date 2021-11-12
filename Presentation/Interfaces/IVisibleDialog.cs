namespace Showroom.Presentation.Interfaces
{
    public interface IVisibleDialog
    {
        bool IsVisible { get; set; }

        void Hide();

        void Show();
    }
}
