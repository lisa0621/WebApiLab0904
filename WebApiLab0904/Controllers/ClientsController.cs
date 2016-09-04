using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiLab0904.Models;

namespace WebApiLab0904.Controllers
{
    [RoutePrefix("clients")]
    public class ClientsController : ApiController
    {
        private FabricsEntities db = new FabricsEntities();

        public ClientsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: api/Clients
        [Route("")]
        public IHttpActionResult GetClient()
        {
            return Ok(db.Client);
        }

        // GET: api/Clients
        [Route("get3")]
        public IHttpActionResult GetClient3()
        {
            return Ok("測試");
        }

        // GET: api/Clients
        [Route("get4")]
        public HttpResponseMessage GetClient4()
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("測試", Encoding.GetEncoding("Big5"))
            };
        }

        // GET: api/Clients
        [Route("get1")]
        public HttpResponseMessage GetClient1()
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ObjectContent<IQueryable<Client>>(db.Client,
                GlobalConfiguration.Configuration.Formatters.JsonFormatter),
                ReasonPhrase = "VERY_OK"
            };
        }

        // GET: api/Clients
        [Route("get2")]
        public HttpResponseMessage GetClient2()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.Client);
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        [Route("{id}", Name = "GetClientById")]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // GET: api/Clients/5
        [Route("{id}/orders")]
        [Route("~/ClientOrders/{id}")]
        public IHttpActionResult GetClientOrders(int id)
        {
            var orders = db.Order.Where(p => p.ClientId == id);

            return Ok(orders);
        }

        // GET: api/Clients/5
        [Route("{id}/orders/{*date:datetime}")]
        public IHttpActionResult GetClientOrders(int id, DateTime date)
        {
            var orders = db.Order.Where(p => p.ClientId == id
            && p.OrderDate.Value.Year == date.Year
            && p.OrderDate.Value.Month == date.Month
            && p.OrderDate.Value.Day == date.Day);

            return Ok(orders);
        }

        // GET: api/Clients/5
        [Route("{id}/orders/pending")]
        public IHttpActionResult GetClientOrdersPending(int id)
        {
            var orders = db.Order.Where(p => p.ClientId == id
            && p.OrderStatus == "P");

            return Ok(orders);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        [Route("")]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Client.Add(client);
            db.SaveChanges();

            //Location要正確
            return CreatedAtRoute("GetClientById", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Client.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Client.Count(e => e.ClientId == id) > 0;
        }
    }
}