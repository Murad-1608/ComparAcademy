using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Share : BaseEntity
    {
        public int PostID { get; set; }
        public int SenderID { get; set; }
        public int RecipientID { get; set; }

        public Post Post { get; set; }
        public User Sender { get; set; }

    }
}
