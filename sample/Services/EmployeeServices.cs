using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using sample.EmployeeDTO;
using sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample.Services
{
    public class EmployeeServices
    {
        private readonly IMongoCollection<EmployeeMember> _employee;
        // private readonly IMongoCollection<EmployeeDTO> employees;

        //public EmployeeServices(IConfiguration config)
        //{
        //    var Client = new MongoClient(config.GetConnectionString("ConnectionString")/*"mongodb://localhost:27017"*/);
        //    var Database = Client.GetDatabase(config.GetConnectionString("DataBaseName"));
        //    _employee = Database.GetCollection<EmployeeMember>(config.GetConnectionString("EmployeesCollectionName"));
        //}

        public EmployeeServices(IDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("sampledatabase");
            _employee = db.GetCollection<EmployeeMember>("employee");
        }


        internal async Task<bool> CreateEmployeeRecord(EmployeeMember newEmployeeDetails)
        {
            var isCreated = false;
            try
            {
                await _employee.InsertOneAsync(newEmployeeDetails);
                isCreated = true;
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "Create Employee record failed.");
            }
            return isCreated;
        }



        public async Task<IEnumerable<EmployeeMember>> GetAllEmployees()
        {
            IEnumerable<EmployeeMember> allEmployees = null;
            try
            {
                var result = _employee.Find(x => true);
                allEmployees = result.ToEnumerable();
            }
            catch (Exception ex)
            {
               // logger.LogError(ex, "Get all employees failed.");
            }
            return allEmployees;
        }






        internal async Task<EmployeeMember> GetEmployeeById(string id)
        {
            EmployeeMember foundEmployee = null;
            try
            {
                var result = await _employee.FindAsync(employee =>ObjectId.Parse(id).Equals(employee._id));
                foundEmployee = result.FirstOrDefault();
            }
            catch (Exception ex)
            {
               
            }
            return foundEmployee;
        }



        internal async Task<bool> UpdateEmployeeRecord(string id, EmployeeMember updatedEmployeeDTO)
        {
            var isUpdated = false;
            try
            {
                var foundEmployee = GetEmployeeByFirstName(id).Result;

                //foundEmployee.FirstName = updatedEmployeeDTO.FirstName;
                foundEmployee.LastName = updatedEmployeeDTO.LastName;
                foundEmployee.Gender = updatedEmployeeDTO.Gender;
                foundEmployee.Position= updatedEmployeeDTO.Position;
                foundEmployee.DOB = updatedEmployeeDTO.DOB;
                foundEmployee.Address = updatedEmployeeDTO.Address;

                await _employee.ReplaceOneAsync(emp => id.Equals(emp.FirstName), foundEmployee);
                isUpdated = true;
            }
            catch (Exception ex)
            {
               // logger.LogError(ex, "Upadte Employee failed.");
            }
            return isUpdated;
        }

        internal async Task<bool> DeleteEmployeeRecord(string name)
        {
            var isDeleted = false;
            try
            {
                await _employee.DeleteOneAsync(emp => name.Equals(emp.FirstName));
                isDeleted = true;
            }
            catch (Exception ex)
            {
               // logger.LogError(ex, "Delete Employee failed.");
            }
            return isDeleted;
        }

        internal async Task<EmployeeMember> GetEmployeeByFirstName(string name)
        {
            EmployeeMember foundEmployee = null;
            try
            {
                var result = await _employee.FindAsync(employee => name.Equals(employee.FirstName));
                foundEmployee = result.FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return foundEmployee;
        }




        //public IList<EmployeeMember> GetEmployeeMembers() =>
        //    _employee.Find(sub => true).ToList();

        //public EmployeeMember Find(string name) =>
        //    _employee.Find(sub => sub.Name == name).SingleOrDefault();

        //public void Update(EmployeeMember emp) =>
        //    _employee.ReplaceOne(sub => sub.Name == emp.Name, emp);

        //public void Delete(string name) =>
        //    _employee.DeleteOne(sub => sub.Name == name);
    }
}

