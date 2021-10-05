using EntityFrameworkFun.Models;
using System;
using System.Linq;

namespace EntityFrameworkFun
{
    class Program
    {
        static void Main(string[] args)
        {
            var _context = new EdDbContext();
            //now can use the DB
            var majors = _context.Majors.ToList();
            foreach(var m in majors)
            {
                Console.WriteLine($"{m.Description}");
            }

        }
    }
}
