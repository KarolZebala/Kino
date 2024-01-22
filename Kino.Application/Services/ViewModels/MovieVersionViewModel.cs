using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.ViewModels
{
    public class MovieVersionViewModel
    {
        public long MovieVersionId { get; set; }
        public int Duration { get; set; }
        public string? SoundVersion { get; set; }
        public string? ImageVersion { get; set; }
        public string? LanguageVerion { get; set; }
        public bool HasSubstitles { get; set; }
    }
}
