using SocialNetwork_Kata.Core.Interfaces;
using SocialNetwork_Kata.Core.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork_Kata.Core.Models
{
    public class SocialNetwork : ISocialNetwork
    {
        // Adds a new member and returns the added member
        private List<IMember> _memberList = new List<IMember>();
        public IMember AddMember(string firstName, string lastName, string city, string country)
        {
            var newId = IdGenerator.GetId<IMember>();
            IMemberProfile newProfile = new MemberProfile(firstName, lastName, city, country);
            IMember newMember = new Member(newId, newProfile);
            _memberList.Add(newMember);
            return newMember;
        }

        // Returns the member with the id
        public IMember FindMemberById(int id)
        {
            return _memberList.FirstOrDefault(x=>x.Id == id);
        }

        // Returns a list of members by searching all fields in the profile
        public IEnumerable<IMember> FindMember(string search)
        {
            return _memberList.Where(x => SearchInMember(x, search));
        }
        public bool SearchInMember(IMember member, string search)
        {
            return member.Profile.Firstname == search || member.Profile.Lastname == search ||
                member.Profile.City == search || member.Profile.Country == search;
        }
        // Total number of members currently in the social network
        public int MemberCount { get { return 0; } }
    }
    
}