using System;
namespace Fixtr.Model
{
    public struct /*class*/ Address
    {
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int Nr { get; set; }

        //public Address(string street, string postalCode, int nr) 
        //{
        //    Street = street;
        //    PostalCode = postalCode;
        //    Nr = nr; 

        //    //Console.WriteLine("[Address ctor] " + ToString());
        //}


        public override string ToString()
        {
            return string.Format("[Address: Street={0}, PostalCode={1}, Nr={2}]", Street, PostalCode, Nr);
        }
    }
}
