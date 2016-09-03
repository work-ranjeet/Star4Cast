﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Identity
{
    public class UserList
    {
        internal static UserList Instance => new UserList();

        internal ApplicationUser[] Users { get; } = {
            new ApplicationUser()
            {
                FirstName = "Ranjeet",
                LastName = "Kumar",
                Dob = Convert.ToDateTime("02-28-1984"),
                Email = "er.ranjeetkumar@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "9535304488",
                PhoneNumberConfirmed = true,
                Gender = "M",
                UserName = "er.ranjeetkumar@gmail.com",
                Addresses = { new UserAddress()
                {
                    LineOne = "S1, Sai sanidhi Appartment",
                    LineTwo = "@nd A Cross, 3rd Main, NS Palaya, BTM 2nd Stage",
                    CityOrTown = "Bangalore",
                    StateOrProvince = "Karnatka",
                    ZipOrPostalCode = "560067",
                    Country = "India",
                    Addressee = "Near Orchid International School, Lake Road"
                }}
            }
        };
    }
}
