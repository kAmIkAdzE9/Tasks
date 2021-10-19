using System.Collections.Generic;

namespace Post
{
    class Post
    {

        List<string> comments;
        int likes;

        public Post() {
            comments = new List<string>();
            likes = 0;
        }

        public void Like() {
            likes++;
        }

        public int GetLikesNumber () {
            return likes;
        }

        public void LeaveComment(string comment) {
            comments.Add(comment);
        }

        public List<string> GetComments() {
            return comments;
        }
    }
}