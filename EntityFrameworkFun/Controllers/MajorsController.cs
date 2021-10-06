using EntityFrameworkFun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkFun.Controllers
{
    public class MajorsController
    {
        //we need to have an instance of context so can access the database
        private readonly EdDbContext _context; //context instance, variable
                                                           //readonly: modifier that for this var don't have to give value rn
                                                           //but only place can set value is constructor
                                                           //would have to initialize a constant right here so diff
                                                           //doesn't have to be a prooperty because nobody outside of class accessing
                                                           
        //add controller right away give context its value
        public MajorsController()
        {
            _context = new EdDbContext();
        }
        
        public List<Major> GetAll()
        {
            return _context.Majors.ToList();
        }

        public Major GetByPk(int Id)
        {
            return _context.Majors.Find(Id); //can only use find on PK
        }

        public Major GetByCode(string Code)
        {
            return _context.Majors.SingleOrDefault(maj => maj.Code == Code); //if don't find 1, returns default, for class is null, if just single throws exc
                                                      //if find more than one, throws exceptions for both sing and singleordefault
                                                      //lambda: only want an instance where code matches code passed in, usually boolean
        }

        public bool Create(Major major)
        {
            major.Id = 0; //forces 0 into ID no matter what was there before (**don't do this professionally, this will change user input)
            _context.Majors.Add(major); //does not add to db, need to call save changes
            var rowsAffected = _context.SaveChanges(); //don't need collection, just applies to whole db, if not # you anticipate,
                                                       //something went wrong
            if(rowsAffected != 1)
            {
                throw new Exception("Create failed.");
            }
            return true;
        }

        public bool Change(int Id, Major major) //pass in id value with instance want to change, ensure user changing right one
                                                //another natural check is to make sure instace passing thru not null
        {
            if (Id != major.Id) 
            {
                throw new Exception("Ids don't match.");
            }
            //major.Update=DateTime.Now; >>if had/want an updated column that system can manage on its own
            _context.Entry(major).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //info for EF to wrap around instance, if gets here, treat as been changed
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Change failed.");
            }
            return true;
        }

        public bool Remove(int Id)
        {
            var major = _context.Majors.Find(Id);
            if (major == null)
            {
                return false;
            }
            _context.Majors.Remove(major); //has to read before remove
            _context.SaveChanges();
            return true;
        }
    }
}
