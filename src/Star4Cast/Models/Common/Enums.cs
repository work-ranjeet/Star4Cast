using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Common
{
    public enum Role
    {
        SuperAdmin = 1,
        Admin,
        Talent,
        Casting,
        GUsers,
        Approver,
        Activeter,
        UserMnagment
    }

    public enum BloodGroup
    {
        DontKnow = 0,
        APositive,
        ANegative,
        BPositive,
        BNegative,
        ABPositive,
        ABNegative,
        OPositive,
        ONegative

    }

    public enum MariedStatus
    {
        NeverMarried = 0,
        Married,
        Divorced,
        AwaitingDivorce
    }

    public enum BodyType
    {
        Others = 0,
        Average,
        Slim,
        Athletic,
        Heavy
    }

    public enum SkinColor
    {
        Others = 0,
        VeryFair,
        Fair,
        Wheatish,
        Dark,
        Brown,
        Olive,
        Tanned

    }

    public enum EyeColor
    {
        Others = 0,
        Black,
        Brown,
        Blue,
        Green,
        Grey,
        Hazel
    }

    public enum HairLength
    {
        None = 0,
        Short,
        Medium,
        Long
    }

    public enum HairType
    {
        Straight,
        Wavy,   // लहरदार
        Curly,
        Afro,   //अफ्रीकी
        Bald    //गंजा
    }

    public enum HairColor
    {
        Others = 0,
        Auburn, // सुनहरा भूरा रंग
        Black,
        Blonde, // गोरा
        Brown,
        Grey,
        Red
    }

    public enum StatusEnum
    {
       Active,
       NotActive
    }

}
