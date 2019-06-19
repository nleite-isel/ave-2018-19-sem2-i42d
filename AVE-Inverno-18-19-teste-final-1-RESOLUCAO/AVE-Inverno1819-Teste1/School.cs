using System;
namespace AVEInverno1819Teste1
{
    public class School
    {
        //public string Name { get; set; }
        public int Id { get; set; }

        //public School(string name)
        //{
        //    this.Name = name;
        //}

        public School(int id)
        {
            this.Id = id;
        }


        public override string ToString()
        {
            //return string.Format("[School: Name={0}]", Name);
            return string.Format("[School: Id={0}]", Id);
        }
    }
}
