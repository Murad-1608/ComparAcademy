using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Post : BaseEntity
    {
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public User User { get; set; }  
        public List<Share> Shares { get; set; }


    }
}
