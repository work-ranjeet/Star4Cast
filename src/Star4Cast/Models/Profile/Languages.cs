using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Profile
{
    public class Languages
    {
        public Languages()
        {
            //UserLanguageList = new List<UserLanguage>();
        }

        public Guid Id { get; set; }

        public int Status { get; set; } = 1;

        [MaxLength(100)]
        public string Language { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        public ICollection<UserLanguage> UserLanguageList { get; set; }
    }
}
