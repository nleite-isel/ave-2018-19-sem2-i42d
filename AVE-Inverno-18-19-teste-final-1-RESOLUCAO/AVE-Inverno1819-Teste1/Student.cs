
using System.Collections.Generic;

namespace AVEInverno1819Teste1
{
    public class Student 
    {
        public Student(School school)
        {
            this.School = school;
        }
        public Student(int nr, School school) 
        {
            this.Nr = nr; this.School = school;
        }
        // IEnumerable
        public IEnumerable<int> Values { get; set; }

        // 4)
        [Validation("CheckNumberLessThan50000")]
        public int Nr { get; set; }

        public School School { get; set; }

        public override string ToString()
        {
            //return string.Format("[Student: Nr = {0}, School = {1}]",
                                 //Nr, School);
            return string.Format("[Student: Nr = {0}, School = {1}, Values = {2}]",
                                 Nr, School, Values != null ? "[" + string.Join(",", Values) + "]" : "[]");
        }
    }
}