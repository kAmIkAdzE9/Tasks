using System;

namespace Post
{
    class Program
    {
        static void Main(string[] args)
        {
            Post post = new Post();
            post.Like();
            post.Like();
            post.Like();
            post.Like();
            Console.WriteLine(post.GetLikesNumber());
            post.LeaveComment("first comment");
            post.LeaveComment("second comment");
            foreach(string coment in post.GetComments()) {
                Console.WriteLine(coment);
            }
        }
    }
}
