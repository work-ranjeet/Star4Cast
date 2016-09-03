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
    public interface IUserDetail
    {
        Guid Id { get; set; }

        string About { get; set; }

        string ProfileAddress { get; set; }

        DateTime DateOfBirth { get; set; }

        int Age { get; set; }

        MariedStatus MaritalStatus { get; set; }

        BloodGroup BloodGroup { get; set; }

        string MotherTongue { get; set; }

        string Religion { get; set; }

        string HealthInfo { get; set; }

        string Disability { get; set; }

        DateTime DttmCreted { get; set; }

        DateTime DttmModified { get; set; }

    }

    public static class IUserDetailExtension
    {
        public static void ConfigureUserDetail<TUserDetail>(this EntityTypeBuilder<TUserDetail> builder)
                where TUserDetail : class, IUserDetail
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
