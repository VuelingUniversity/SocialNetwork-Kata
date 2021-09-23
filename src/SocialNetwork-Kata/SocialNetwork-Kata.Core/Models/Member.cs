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
            if (from.Id != Id)
            {
                _pending.Add(from);
            }
        }

        // Confirms a pending friend request
        public void ConfirmFriend(IMember member)
        {
            if (_pending.Contains(member))
            {
                _friends.Add(member);
            }
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
            if (level != 1)
            {
                return null;
            }
            return Friends;
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
}