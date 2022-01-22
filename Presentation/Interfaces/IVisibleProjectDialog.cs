namespace Showroom.Presentation.Interfaces
{
    using Showroom.Models;

    public interface IVisibleProjectDialog<in T> : IVisibleDialog where T : IProject
    {
        void Show(T project);
    }
}