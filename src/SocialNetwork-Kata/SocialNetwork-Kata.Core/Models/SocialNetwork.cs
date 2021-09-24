using SocialNetwork_Kata.Core.Tools;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork_Kata.Core.Models
{
    public class SocialNetwork : ISocialNetwork
    {
        private readonly List<IMember> _members = new List<IMember>();
        // Adds a new member and returns the added member
        public IMember AddMember(string firstName, string lastName, string city, string country)
        {
            var id = IdGenerator.GetId<IMember>();

            var member = Member.CreateMember(id, firstName, lastName, city, country);
            _members.Add(member);
            return member;
        }

        // Returns the member with the id
        public IMember FindMemberById(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }

        // Returns a list of members by searching all fields in the profile
        public IEnumerable<IMember> FindMember(string search)
        {
            List<IMember> findedMembers = new List<IMember>();
            foreach (var member in _members)
            {
                if (member.Profile.Firstname == search)
                    findedMembers.Add(member);
                else if (member.Profile.Lastname == search)
                    findedMembers.Add(member);
                else if (member.Profile.City == search)
                    findedMembers.Add(member);
                else if (member.Profile.Country == search)
                    findedMembers.Add(member);
            }

            return findedMembers;
        }

        // Total number of members currently in the social network
        public int MemberCount { get { return _members.Count; } }
    }
}
