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
        private List<IMember> _friends;
        private List<IMember> _pending;
        private List<IPost> _posts;
        public Member(int id, IMemberProfile profile)
        {
            Id = id;
            Profile = profile;
            _friends = new List<IMember>();
            _pending = new List<IMember>();
            _posts = new List<IPost>();
        }

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
    }

}
