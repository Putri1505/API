using API.Context;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace API.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, int>
    {
        private readonly MyContext myContext;
        public PersonRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int Register(RegisterVM registerVM)
        {
            var cek = myContext.Persons.FirstOrDefault(p => p.Email == registerVM.Email);
            var result = 0;
            if (cek == null)
            {
                var person = new Person()
                {
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = registerVM.Email,
                    Phone = registerVM.Phone,
                    BirthDate = registerVM.BirthDate,
                    salary = registerVM.salary
                };
                myContext.Add(person);
                result = myContext.SaveChanges();
                var account = new Account()
                {
                    NIK = person.NIK,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password)
                };
                myContext.Add(account);
                result = myContext.SaveChanges();
                var education = new Education()
                {
                    Degree = registerVM.Degree,
                    GPA = registerVM.GPA,
                    Universityid = registerVM.Universityid
                };
                myContext.Add(education);
                result = myContext.SaveChanges();
                var profiling = new Profiling()
                {
                    NIK = person.NIK,
                    Educationid = education.Educationid
                };
                myContext.Add(profiling);
                result = myContext.SaveChanges();
                return result;
            } 
            return result;
        }
        public int LoginVM(LoginVM loginVM)
        {
            var result = 0;
            var resultSearch = myContext.Persons.FirstOrDefault(p => p.Email.Equals(loginVM.Email));
            if (resultSearch != null && BCrypt.Net.BCrypt.Verify(loginVM.Password, resultSearch.Account.Password))
            {
                return 1;
            }
            return result;
        }
        public IEnumerable<RegisterVM> GetAllProfile()
        {
            var all = (
            from p in myContext.Persons
            join a in myContext.Accounts on p.NIK equals a.NIK
            join pr in myContext.Profilings on a.NIK equals pr.NIK
            join e in myContext.Educations on pr.Educationid equals e.Educationid
            join u in myContext.Universities on e.Universityid equals u.Universityid
            select new RegisterVM
            {
                NIK = p.NIK,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Phone = p.Phone,
                BirthDate = p.BirthDate,
                salary = p.salary,
                Email = p.Email,
                Password = a.Password,
                Degree = e.Degree,
                GPA = e.GPA,
                Universityid = u.Universityid

            }).ToList();
            return all;
        }
        public RegisterVM GetProfileById(int nik)
        {
            var all = (
            from p in myContext.Persons
            join a in myContext.Accounts on p.NIK equals a.NIK
            join pr in myContext.Profilings on a.NIK equals pr.NIK
            join e in myContext.Educations on pr.Educationid equals e.Educationid
            join u in myContext.Universities on e.Universityid equals u.Universityid
            select new RegisterVM
            {
                NIK = p.NIK,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Phone = p.Phone,
                BirthDate = p.BirthDate,
                salary = p.salary,
                Email = p.Email,
                Password = a.Password,
                Degree = e.Degree,
                GPA = e.GPA,
                Universityid = u.Universityid

            }).ToList();
            return all.FirstOrDefault(p => p.NIK == nik);
        }
        public class Hashing
        {
            private static string GetRandomSalt()
            {
                return BCrypt.Net.BCrypt.GenerateSalt(12);
            }
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
            }
            public static bool ValidatePassword(string password, string correctHash)
            {
                return BCrypt.Net.BCrypt.Verify(password,correctHash);
            }
        }
    }
}