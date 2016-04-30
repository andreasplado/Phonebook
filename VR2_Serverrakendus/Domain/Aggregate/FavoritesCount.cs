using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregate
{
    public class FavoritesCount
    {
        public Favorite Favorite { get; set; }

        public int FavoritesCountValue { get; set; }
    }
}
