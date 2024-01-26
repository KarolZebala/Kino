using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.ViewModels
{
    public class MovieItemViewModel
    {
        public long MovieItemId { get; set; }
        public long MovieId { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxViewers { get; set; }
        public decimal BaseTicketPrice { get; set; }
        public decimal ActualTicketPrice { get; set; }
        public decimal PurchaseTicketPrice { get; set; }
    }
}
