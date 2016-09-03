using Star4Cast.Models.Common;
using System;

namespace Star4Cast.Models.Profile
{
    public class PhysicalAppearance : IPhysicalAppearance
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public BodyType BodyType { get; set; }

        public SkinColor SkinColor { get; set; }

        public EyeColor EyeColor { get; set; }

        public int Chest { get; set; }

        public int West { get; set; }

        public HairLength HairLength { get; set; }

        public HairType HairType { get; set; }

        public HairColor HairColor { get; set; }

        public DateTime DttmCreted { get; set; } = DateTime.UtcNow;

        public DateTime DttmModified { get; set; } = DateTime.UtcNow;

        //public ApplicationUser User { get; set; }
    }
}
