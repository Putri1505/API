using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class PersonRepository_add : IPersonRepository
    {
        private readonly MyContext conn;
        public PersonRepository_add(MyContext conn)
        {
            this.conn = conn;
        }
        public int Delete(int nik)
        {
            Person person = null;
            int _isdeleted = 0;
            person = conn.Persons.Find(nik);
            if(person != null)
            {
                conn.Remove(person);
                conn.SaveChanges();
                _isdeleted = 1;
            }
            return _isdeleted;
        }
        public IEnumerable<Person> Get()
        {
            return conn.Persons.ToList();
        }

        public Person Get(int nik)
        {
            return conn.Persons.Where(p => p.NIK == nik).FirstOrDefault();
        }

        public int Insert(Person person)
        {
            conn.Persons.Add(person);
            var result = conn.SaveChanges();
            return result;
        }

        public int Update(Person person, int nik)
        {
            try
            {
                conn.Entry(person).State = EntityState.Modified;
                int result = conn.SaveChanges();
                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            } 
        }
    }
}
