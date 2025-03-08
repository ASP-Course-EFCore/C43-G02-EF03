using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Models
{
    class Course_Inst
    {
        public int Inst_Id { get; set; }
        public int Course_Id { get; set; }
        public int Evaluate { get; set; }
        public Course Course { get; set; } = null!;
        public Instructor Instructor { get; set; } = null!;
    }
}
