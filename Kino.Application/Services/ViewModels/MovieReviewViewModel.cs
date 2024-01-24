using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.ViewModels
{
    public class MovieReviewViewModel
    {
        public long MovieReviewId { get; set; }
        public long MovieId { get; set; }
        public string? Author { get; set; }
        public string? Type { get; set; }
        public string? Content { get; set; }
        public int Grade { get;  set; }
    }
}
