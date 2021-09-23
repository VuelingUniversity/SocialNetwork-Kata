using SocialNetwork_Kata.Core.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork_Kata.Core.Models
{
    public class SocialNetwork : ISocialNetwork
    {
        private List<Member> _memberList = new List<Member>();

        // Adds a new member and returns the added member
        public IMember AddMember(string firstName, string lastName, string city, string country)
        {
            var memberProf = new MemberProfile() { Firstname = firstName, Lastname = lastName, City = city, Country = country };
            var member = new Member(memberProf);
            _memberList.Add(member);
            return member;
        }

        // Returns the member with the id
        public IMember FindMemberById(int id)
        {
            var member = _memberList.Where(member => member.Id == id).FirstOrDefault();
            return member;
        }

        // Returns a list of members by searching all fields in the profile
        public IEnumerable<IMember> FindMember(string search)
        {
            var member = _memberList.Where(member => member.Profile.City == search
            || member.Profile.Country == search
            || member.Profile.Firstname == search
            || member.Profile.Lastname == search);
            return member;
        }

        // Total number of members currently in the social network
        public int MemberCount { get { return _memberList.Count(); } }
    }

    public class Member : IMember
    {
        // Id of member. Must be unique and sequential.
        public int Id { get; }

        // Member profile
        public IMemberProfile Profile { get; }

        // List of friends
        public IEnumerable<IMember> Friends { get { return null; } }

        // List of pending friend requests
        public IEnumerable<IMember> Pending { get { return null; } }

        // Members posts
        public IEnumerable<IPost> Posts { get { return null; } }

        // Adds a friend request for this member. from - the member making the friend request
        public void AddFriendRequest(IMember from)
        {
        }

        // Confirms a pending friend request
        public void ConfirmFriend(IMember member)
        {
        }

        // Removes a pending friend request
        public void RemoveFriendRequest(IMember member)
        {
        }

        // Removes a friend
        public void RemoveFriend(IMember member)
        {
        }

        // Returns a list of all friends. level - depth (1 - friends, 2 - friends of friends ...)
        public IEnumerable<IMember> GetFriends(int level = 1, IList<int> filter = null)
        {
            return null;
        }

        // Adds a new post to members feed
        public IPost AddPost(string message)
        {
            return null;
        }

        // Removes the post with the id
        public void RemovePost(int id)
        {
        }

        // Returns members feed as a list of posts. Should also return posts of friends.
        public IEnumerable<IPost> GetFeed()
        {
            return null;
        }

        public Member(MemberProfile profile)
        {
            this.Id = IdGenerator.GetId<Member>();
            this.Profile = profile;
            this.Profile.MemberId = this.Id;
        }
    }

    public class MemberProfile : IMemberProfile
    {
        // Id of the Member this profile belongs to
        public int MemberId { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Post : IPost
    {
        // Id of post. Must be unique and sequential.
        public int Id { get; set; }

        // Member that made this post
        public IMember Member { get; set; }

        // The post message
        public string Message { get; set; }

        // Date and time post was made
        public DateTime Date { get; set; }

        // Likes for post
        public int Likes { get; set; }
    }
}