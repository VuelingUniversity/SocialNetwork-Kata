using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_Kata.Core.Interfaces
{
    public interface IMemberProfile
    {
        string City { get; set; }
        string Country { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        int MemberId { get; set; }
    }
}