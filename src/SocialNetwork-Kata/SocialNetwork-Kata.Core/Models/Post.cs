using SocialNetwork_Kata.Core.Interfaces;
using SocialNetwork_Kata.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_Kata.Core.Models
{
    public class Post : IPost
    {
        public Post(IMember member, string message)
        {
            Id = IdGenerator.GetId<IPost>();
            Member = member;
            Message = message;
            Date = DateTime.Now;
            Likes = 0;
        }
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
