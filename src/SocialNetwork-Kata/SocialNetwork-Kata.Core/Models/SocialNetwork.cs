using SocialNetwork_Kata.Core.Interfaces;
using SocialNetwork_Kata.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_Kata.Core.Models
{
    public class SocialNetwork : ISocialNetwork
    {
        private List<IMember> _memberList = new List<IMember>();

        // Adds a new member and returns the added member
        public IMember AddMember(string firstName, string lastName, string city, string country)
        {
            int memberId = IdGenerator.GetId<IMember>();
            IMemberProfile profile = new MemberProfile(memberId, firstName, lastName, city, country);
            IMember newMember = new Member(memberId, profile);
            _memberList.Add(newMember);
            return newMember;
        }

        // Returns the member with the id
        public IMember FindMemberById(int id)
        {
            return _memberList.FirstOrDefault(member => member.Id == id);
        }

        // Returns a list of members by searching all fields in the profile
        public IEnumerable<IMember> FindMember(string search)
        {
            return _memberList.Where(member => SearchInAllProfileFields(member, search));
        }

        // Total number of members currently in the social network
        public int MemberCount { get { return _memberList.Count(); } }

        public bool SearchInAllProfileFields(IMember member, string search)
        {
            return member.Profile.Firstname.Equals(search) || member.Profile.Lastname.Equals(search)
                || member.Profile.Country.Equals(search) || member.Profile.City.Equals(search);
        }
    }
}