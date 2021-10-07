using EntityFrameworkFun.Controllers;
using EntityFrameworkFun.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkFun
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var majCtrl = new MajorsController();
            var majors = await majCtrl.GetAll(); //await bc we want list of majors using async
            majors.ForEach(m => Console.WriteLine(m));


            var major = await majCtrl.GetByPk(4); //when hover over var, should just be type not task to know doing it right
            Console.WriteLine(major);
        }


        static void XX() { 
            Student student = null;
            var studentsCtrl = new StudentsController();

            var NewStudent = new Student()
            {
                Id = 0,
                Firstname = "Elyse",
                Lastname = "Roth",
                StateCode = "NY",
                Sat = 1600,
                Gpa = 4.0m,
                MajorId = null
            };
            studentsCtrl.Create(NewStudent);

            var rs = studentsCtrl.Remove(NewStudent.Id);

            NewStudent.StateCode = "OH";
            studentsCtrl.Change(NewStudent.Id, NewStudent);


            var students = studentsCtrl.GetAll();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Firstname} {s.Lastname} | {s.StateCode} | {s.Sat}");
            }

            student = studentsCtrl.GetByPk(44);
            Console.WriteLine($"{student.Firstname} {student.Lastname} | {student.Sat} | {student.Gpa}");

            




        }

        static void X()
            {
                Major major = null; //declare var so don't have to keep declaring
                                    //display all majors in major table
                var majorsCtrl = new MajorsController();

                var NewMajor = new Major()
                {
                    Id = 0,
                    Code = "MUSC",
                    Description = "Music",
                    MinSat = 1595  //anything we don't give a value will default, null
                };
                try
                {
                    var rc1 = majorsCtrl.Create(NewMajor); //(rc =return code)
                    if (!rc1)
                    {
                        Console.WriteLine($"Create new major failed.");
                    }
                }
                catch (Exception ex)
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

               // major = majorsCtrl.GetByPk(4);
                Console.WriteLine($"{major.Description}");


                var majors = majorsCtrl.GetAll();

               // foreach (var m in majors)
               // {
                    //Console.WriteLine($"{m.Description}");
                //}


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

