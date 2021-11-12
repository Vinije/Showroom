namespace Showroom.Models
{
    public class Project : IProject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProjectType ProjectType { get; set; }

        public string OwnerId { get; set; }

        public string ProjectPath { get; set; }

        public string ProjectThumbnail { get; set; }

        public double Rating { get; set; }

        public int Views { get; set; }
    }
}
