using System.Collections.Generic;
using TestProject.Models;

namespace WebApplication.ViewModels
{
    public  class ArtistViewModel : BaseViewModel
    {
        public ArtistViewModel()
        {
            ArtistsList = new List<Artist>();
        }
        public IEnumerable<Artist> ArtistsList { get; set; }
        public string SearchTerms { get; set; }
    }
}