using SocialNetwork_Kata.Core.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

    public class Member : IMember
    {
        private List<IMember> _friends = new List<IMember>();
        private List<IMember> _pending = new List<IMember>();
        private List<IPost> _posts = new List<IPost>();

        // Id of member. Must be unique and sequential.
        public int Id { get; }

        // Member profile
        public IMemberProfile Profile { get; }

        // List of friends
        public IEnumerable<IMember> Friends { get { return _friends; } }

        // List of pending friend requests
        public IEnumerable<IMember> Pending { get { return _pending; } }

        // Members posts
        public IEnumerable<IPost> Posts { get { return _posts; } }

        public Member(int id, IMemberProfile profile)
        {
            Id = id;
            Profile = profile;
        }

        // Adds a friend request for this member. from - the member making the friend request

        public void AddFriendRequest(IMember from)
        {
            _pending.Add(from);
        }

        // Confirms a pending friend request
        public void ConfirmFriend(IMember member)
        {
            _friends.Add(member);
        }

        // Removes a pending friend request
        public void RemoveFriendRequest(IMember member)
        {
            int pendingId = _pending.FindIndex(pending => pending.Id == member.Id);
            _pending.RemoveAt(pendingId);
        }

        // Removes a friend
        public void RemoveFriend(IMember member)
        {
            int friendId = _friends.FindIndex(friend => friend.Id == member.Id);
            _friends.RemoveAt(friendId);
        }

        // Returns a list of all friends. level - depth (1 - friends, 2 - friends of friends ...)
        public IEnumerable<IMember> GetFriends(int level = 1, IList<int> filter = null)
        {
            return null;
        }

        // Adds a new post to members feed
        public IPost AddPost(string message)
        {
            IPost newPost = new Post(this, message);
            _posts.Add(newPost);
            return newPost;
        }

        // Removes the post with the id
        public void RemovePost(int id)
        {
            int postId = _posts.FindIndex(post => post.Id == id);
            _posts.RemoveAt(postId);
        }

        // Returns members feed as a list of posts. Should also return posts of friends.
        public IEnumerable<IPost> GetFeed()
        {
            return null;
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

        public MemberProfile(int memberId, string firstName, string lastName, string city, string country)
        {
            MemberId = memberId;
            Firstname = firstName;
            Lastname = lastName;
            City = city;
            Country = country;
        }
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

        public Post(IMember member, string message)
        {
            Id = IdGenerator.GetId<IPost>();
            Member = member;
            Message = message;
            Date = DateTime.Now;
            Likes = 0;
        }
    }
}