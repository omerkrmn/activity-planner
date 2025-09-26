using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        private const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize > 0 ? _pageSize : 1;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
