using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_Kata.Core.Interfaces
{
    public interface IMember
    {
        IEnumerable<IMember> Friends { get; }
        int Id { get; }
        IEnumerable<IMember> Pending { get; }
        IEnumerable<IPost> Posts { get; }
        IMemberProfile Profile { get; }

        void AddFriendRequest(IMember from);

        IPost AddPost(string message);

        void ConfirmFriend(IMember member);

        IEnumerable<IPost> GetFeed();

        IEnumerable<IMember> GetFriends(int level = 1, IList<int> filter = null);

        void RemoveFriend(IMember member);

        void RemoveFriendRequest(IMember member);

        void RemovePost(int id);
    }
}