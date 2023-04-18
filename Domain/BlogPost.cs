using System;
using Nest;

namespace Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }

        [Keyword]
        public Guid CategoryId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; }

        public bool IsPublic { get; set; }

    }
}

