using SocialNetwork_Kata.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_Kata.Core.Models
{
    public class Member : IMember
    {
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

        private List<IMember> _friends;
        private List<IMember> _pending;
        private List<IPost> _posts;
        private Member(int id, MemberProfile profile)
        {
            Id = id;
            Profile = profile;
            _friends = new List<IMember>();
            _pending = new List<IMember>();
            _posts = new List<IPost>();
        }

        // Adds a friend request for this member. from - the member making the friend request 
        public void AddFriendRequest(IMember from)
        {
            if (_pending.Any(m => m.Id == from.Id))
                return;
            if (from.Id != this.Id)
            {
                _pending.Add(from);
                from.AddFriendRequest(this);
            }
        }

        // Confirms a pending friend request
        public void ConfirmFriend(IMember member)
        {

        }

        // Removes a pending friend request
        public void RemoveFriendRequest(IMember member)
        {
            var friend = _pending.FirstOrDefault(f => f.Id == member.Id);
            if (friend != null)
            {
                _pending.Remove(member);
                member.RemoveFriendRequest(this);
            }
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

        public static IMember CreateMember(int id, string name, string lastName, string city, string country)
        {
            return new Member(id, new MemberProfile
            {
                MemberId = id,
                Firstname = name,
                Lastname = lastName,
                City = city,
                Country = country
            });
        }
    }
}
