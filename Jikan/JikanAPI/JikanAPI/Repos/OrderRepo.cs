using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos
{
    public class OrderRepo
    {
        private JikanDbContext context;

        public OrderRepo(JikanDbContext context)
        {
            this.context = context;
        }
    }
}
