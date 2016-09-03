using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Star4Cast.Models.Common;
using Star4Cast.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Star4Cast.Models.Profile
{
    public interface IPhysicalAppearance
    {
        Guid Id { get; set; }

        int Height { get; set; }

        int Weight { get; set; }

        BodyType BodyType { get; set; }

        SkinColor SkinColor { get; set; }

        EyeColor EyeColor { get; set; }

        int Chest { get; set; }

        int West { get; set; }

        HairLength HairLength { get; set; }

        HairType HairType { get; set; }

        HairColor HairColor { get; set; }

        DateTime DttmCreted { get; set; }

        DateTime DttmModified { get; set; }
    }

    public static class IPhysicalAppearanceExtension
    {
        public static void ConfigurePhysicalAppearance<TPhysicalAppearance>(this EntityTypeBuilder<TPhysicalAppearance> builder)
                where TPhysicalAppearance : class, IPhysicalAppearance
        {
            var propertyMethod = builder.GetType()
                        .GetMethod("Property", new Type[] { typeof(string) })
                        .MakeGenericMethod(typeof(string));

            var requiredProps = builder.Metadata.GetProperties()
                .Where(p => p.ClrType == typeof(string))
                .Where(p => p.Name != nameof(IAddress.LineTwo));

            foreach (var item in requiredProps)
            {
                var propertyBuilder = ((PropertyBuilder)propertyMethod
                    .Invoke(builder, new object[] { item.Name }))
                    .IsRequired();
            }
        }
    }
}
