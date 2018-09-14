using CognitiveServices.Models;
using CognitiveServicesAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CognitiveServicesAzure.Controllers
{
    public class EmoHelperAPIController : ApiController
    {
        private CognitiveServicesAzureContext db = new CognitiveServicesAzureContext();

        // POST: api/EmoHelperAPI
        [ResponseType(typeof(EmoPicture))]
        public IHttpActionResult PostEmoHelper(EmoPicture emoPicture)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            db.EmoPictures.Add(emoPicture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emoPicture.Id }, emoPicture);
        }

    }
}
