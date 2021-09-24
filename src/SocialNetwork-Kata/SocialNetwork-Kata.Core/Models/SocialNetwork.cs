using System.Collections.Generic;

namespace SocialNetwork_Kata.Core.Models
{
    public class SocialNetwork : ISocialNetwork
    {
        // Adds a new member and returns the added member
        public IMember AddMember(string firstName, string lastName, string city, string country)
        {
            return null;
        }

        // Returns the member with the id
        public IMember FindMemberById(int id)
        {
            return null;
        }

        // Returns a list of members by searching all fields in the profile
        public IEnumerable<IMember> FindMember(string search)
        {
            return null;
        }

        // Total number of members currently in the social network
        public int MemberCount { get { return 0; } }
    }
}
