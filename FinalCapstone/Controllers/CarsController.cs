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
using FinalCapstone.Models;

namespace FinalCapstone.Controllers
{
    [RoutePrefix("api/cars")]
    public class CarsController : ApiController
    {
        private CarContext db = new CarContext();


        [Route("Make/{Make}")]
        [HttpGet]
        public IQueryable<Car> GetByMake(string Make)
        {
            var Makes = db.Cars.Where(c => c.Make.Contains(Make));
            return Makes;
        }

        [Route("Model/{Model}")]
        [HttpGet]
        public IQueryable<Car> GetByModel(string Model)
        {
            var Models = db.Cars.Where(c => c.Model.Contains(Model));
            return Models;
        }
        [Route("Year/{Year}")]
        [HttpGet]
        public IQueryable<Car> GetByYear(int Year)
        {
            var Years = db.Cars.Where(c => c.Year.Equals(Year));
            return Years;
        }
        [Route("Color/{Color}")]
        [HttpGet]
        public IQueryable<Car> GetByColor(string Color)
        {
            var Colors = db.Cars.Where(c => c.Color.Contains(Color));
            
            return Colors;
           
        }

        // GET: api/Cars
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.ID)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.ID }, car);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.ID == id) > 0;
        }
    }
}