using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_Kata.Core.Interfaces
{
    public interface IPost
    {
        DateTime Date { get; set; }
        int Id { get; set; }
        int Likes { get; set; }
        IMember Member { get; set; }
        string Message { get; set; }
    }
}