using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Profile
{
    public class Accents
    {
        public Guid Id { get; set; }

        [MaxLength(150)]
        public string Accent { get; set; }

        public int Status { get; set; } = 1;

        public ICollection<UserAsents> UserAsentsList { get; set; }
    }
}
