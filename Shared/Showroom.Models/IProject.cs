namespace Showroom.Models
{
    public interface IProject
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        ProjectType ProjectType { get; set; }

        string OwnerId { get; set; }

        string ProjectPath { get; set; }

        string ProjectThumbnail { get; set; }

        double Rating { get; set; }

        int Views { get; set; }
    }
}