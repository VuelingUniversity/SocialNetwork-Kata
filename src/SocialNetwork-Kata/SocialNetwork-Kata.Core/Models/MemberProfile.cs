using SocialNetwork_Kata.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_Kata.Core.Models
{
    public class MemberProfile : IMemberProfile
    {
        // Id of the Member this profile belongs to
        public int MemberId { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public MemberProfile(int memberId, string firstName, string lastName, string city, string country)
        {
            MemberId = memberId;
            Firstname = firstName;
            Lastname = lastName;
            City = city;
            Country = country;
        }
    }
}