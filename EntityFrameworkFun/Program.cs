using EntityFrameworkFun.Controllers;
using EntityFrameworkFun.Models;
using System;
using System.Linq;

namespace EntityFrameworkFun
{
    class Program
    {
        static void Main(string[] args)
        { 
        
        
        
        
        
        
        
        
        
        
        }

        static void X() { 
            Major major = null; //declare var so don't have to keep declaring
            //display all majors in major table
            var majorsCtrl = new MajorsController();

            var NewMajor = new Major()
            {
                Id = 0, Code = "MUSC", Description = "Music", MinSat = 1595  //anything we don't give a value will default, null
            };
            try
            {
                var rc1 = majorsCtrl.Create(NewMajor); //(rc =return code)
                if (!rc1)
                {
                    Console.WriteLine($"Create new major failed.");
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }

            NewMajor.Description = "Classical Music";
            majorsCtrl.Change(NewMajor.Id, NewMajor);

           var rc = majorsCtrl.Remove(NewMajor.Id);
            if (!rc)
            {
                Console.WriteLine($"Remove major failed.");
            }
      

    major = majorsCtrl.GetByCode("MATH");
            Console.WriteLine(major); //now this contains and instance of major from major class and will cw that from class
            //if (major.Code == null)
            //{
            //    Console.WriteLine("Major not found.");
            //} else 
            //Console.WriteLine($"{major.Code}");

            major = majorsCtrl.GetByPk(4);
            Console.WriteLine($"{major.Description}");


            var majors = majorsCtrl.GetAll();

            foreach (var m in majors)
            {
                Console.WriteLine($"{m.Description}");
            }


            //if want to make exception or cw for something not there

            //var majorsCtrl = new MajorsController();
            //var major = majorsCtrl.GetByPk(44444);
            //if (major == null)
            //{
            //    Console.WriteLine("Not Found.");
            //}
            //Console.WriteLine($"{major.Description}");






        }
    }
}
