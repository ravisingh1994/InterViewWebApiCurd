using InterViewWebApiCurd.DB_Context;
using InterViewWebApiCurd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterViewWebApiCurd.Controllers
{
    public class CurdApiController : ApiController
    {
        MyCompanyEntities DB = new MyCompanyEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult getEmp()
        {

            List<Employee> emplist = DB.Employees.ToList();


            return Ok(emplist);

        }
        [HttpPost]
        public IHttpActionResult insetEmp(EmpModel obj)
        {

            Employee tab = new Employee();
            tab.Emp_code = obj.Emp_code;
            tab.Name = obj.Name;
            tab.id = obj.id;
            tab.DOB = obj.DOB;
            DB.Employees.Add(tab);
            DB.SaveChanges();


            return Ok();

        }
        [HttpGet]
        public IHttpActionResult EmpDetails(int id)
        {
            EmpModel empmodel = new EmpModel();
            var emp = DB.Employees.Where(m => m.id == id).FirstOrDefault();

            empmodel.id = emp.id;
            empmodel.Emp_code = emp.Emp_code;
            empmodel.Name = emp.Name;
            empmodel.DOB = emp.DOB;

            return Ok(empmodel);
        }
        [HttpPut]
        public IHttpActionResult EditEmp(EmpModel obj)
        {

            var res = DB.Employees.Where(m => m.id == obj.id).FirstOrDefault();
            if (res != null)
            {

                res.Emp_code = obj.Emp_code;
                res.Name = obj.Name;
                res.id = obj.id;
                res.DOB = obj.DOB;

                DB.SaveChanges();
            }



            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteEmp(int id)
        {


            var obj = DB.Employees.Where(m => m.id == id).FirstOrDefault();


            DB.Employees.Remove(obj);
            DB.SaveChanges();


            return Ok();

        }

       
    }
}