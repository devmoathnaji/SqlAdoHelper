using System;

namespace SQLHelper
{
    internal class Program
    {
        private static void Main(string[] args)
        {

        }
    }

    public class UsersViewMode
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
