using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Identity
{
    public class Organization
    {
        public string Id { get; set; }

        [MaxLength(150)]
        public string OrgName { get; set; }

        [MaxLength(150)]
        public string OrgWebsite { get; set; }

        [MaxLength(150)]
        public string OrgDesiganation { get; set; }

        [MaxLength(150)]
        public string OrgType { get; set; }

        public int Status { get; set; } = 1;
       
        public List<Organization> OrgList { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


    }
}
