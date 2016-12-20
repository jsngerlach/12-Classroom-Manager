using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassroomManager.Api.Models
{
    public class Enrollment
    {
        public int ClassId { get; set; }
        public int StudentId { get; set; }

        //Navigation Property
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
    }
}