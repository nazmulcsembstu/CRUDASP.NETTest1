using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_crud.Models;


namespace test_crud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Index
        public ActionResult Index()
        {
            using (CRUD_try_1Entities dbmodel = new CRUD_try_1Entities())
            {
                return View(dbmodel.Customers.ToList());
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (CRUD_try_1Entities dbmodel = new CRUD_try_1Entities())
            {
                return View(dbmodel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                using (CRUD_try_1Entities dbmodel = new CRUD_try_1Entities())
                {
                    dbmodel.Customers.Add(customer);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (CRUD_try_1Entities dbmodel = new CRUD_try_1Entities())
            {
                return View(dbmodel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                using (CRUD_try_1Entities dbmodel = new CRUD_try_1Entities())
                {
                    dbmodel.Entry(customer).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (CRUD_try_1Entities dbmodel = new CRUD_try_1Entities())
            {
                return View(dbmodel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (CRUD_try_1Entities dbmodel = new CRUD_try_1Entities())
                {
                    Customer customer = dbmodel.Customers.Where(x => x.Id == id).FirstOrDefault();
                    dbmodel.Customers.Remove(customer);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
