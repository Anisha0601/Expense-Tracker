using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TrackerExpenseAPI.Models;

namespace TrackerExpenseAPI.Controllers
{
    public class TotalExpenseController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/TotalExpense
        public IQueryable<TotalExpense> GetTotalExpenses()
        {
            return db.TotalExpenses;
        }

        // GET: api/TotalExpense/5
        [ResponseType(typeof(TotalExpense))]
        public IHttpActionResult GetTotalExpense(int id)
        {
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            if (totalExpense == null)
            {
                return NotFound();
            }

            return Ok(totalExpense);
        }

        // PUT: api/TotalExpense/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTotalExpense(int id, TotalExpense totalExpense)
        {
            

            if (id != totalExpense.Id)
            {
                return BadRequest();
            }

            db.Entry(totalExpense).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotalExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TotalExpense
        [ResponseType(typeof(TotalExpense))]
        public IHttpActionResult PostTotalExpense(TotalExpense totalExpense)
        {
           

            db.TotalExpenses.Add(totalExpense);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = totalExpense.Id }, totalExpense);
        }

        // DELETE: api/TotalExpense/5
        [ResponseType(typeof(TotalExpense))]
        public IHttpActionResult DeleteTotalExpense(int id)
        {
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            if (totalExpense == null)
            {
                return NotFound();
            }

            db.TotalExpenses.Remove(totalExpense);
            db.SaveChanges();

            return Ok(totalExpense);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TotalExpenseExists(int id)
        {
            return db.TotalExpenses.Count(e => e.Id == id) > 0;
        }
    }
}