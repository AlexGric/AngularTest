using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DogId { get; set; }
    }
}
