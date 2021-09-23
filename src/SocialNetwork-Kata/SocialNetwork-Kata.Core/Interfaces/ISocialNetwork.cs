using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_Kata.Core.Interfaces
{
    public interface ISocialNetwork
    {
        int MemberCount { get; }

        IMember AddMember(string firstName, string lastName, string city, string country);

        IEnumerable<IMember> FindMember(string search);

        IMember FindMemberById(int id);
    }
}