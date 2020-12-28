using System.Collections.Generic;

namespace SnackHouse.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Snack> PreferSnacks { get; set; }
    }
}
