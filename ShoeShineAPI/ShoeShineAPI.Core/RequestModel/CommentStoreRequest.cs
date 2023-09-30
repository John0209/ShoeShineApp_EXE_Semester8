using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class CommentStoreRequest
    {
        public int CommentStoreId { get; set; }// Primary Key
        public string Content { get; set; } = string.Empty;
        // Foreign Key
        public Guid UserId { get; set; } // Table UserEntity
                                         //public int ProductId { get; set; } // Table ProductEntity
        public int StoreId { get; set; } // Table StoreEntity
        public int RatingId { get; set; }// Table Rating
        // Relationship
        public List<string>? ImageLinks { get; set; }
    }
}
