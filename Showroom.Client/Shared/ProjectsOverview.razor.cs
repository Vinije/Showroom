using System.Collections.Generic;

namespace Showroom.Client.Shared
{
    using Microsoft.AspNetCore.Components;
    using Showroom.Models;

    public partial class ProjectsOverview
    {
        [Parameter]
        public IEnumerable<IProject> Projects { get; set; }
    }
}
