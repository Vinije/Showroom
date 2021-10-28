namespace Showroom.Presentation.UserInterface
{
    using System.Threading.Tasks;

    public interface IProgressUpdater
    {
        bool IsFinished { get; set; }

        Task UpdateProgress(int value);
    }
}