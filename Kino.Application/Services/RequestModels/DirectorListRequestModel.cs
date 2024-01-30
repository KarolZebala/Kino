using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.RequestModels
{
    public class DirectorListRequestModel
    {
        public string? SearchString { get; set; }
        public int? PageSize { get; set; } = 50;
        public int? PageIndex { get; set; } = 0;
    }
}
