using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [Produces("application/json")] //specifies the expected type of responses
    [Route("api/[controller]/[action]")] //specifies the route to access the api methods
    [ApiController] //specifies that this object is used to serve HTTP API responses
    public class SampleDataController : ControllerBase //controller does NOT support views
    {
        //a response with an object and a default status code
        public ObjectResult ObjectActionResult()
        {
            return new ObjectResult(new { Name = "ObjectActionResult" });
        }

        //200 with an object if formatting succeeds
        public OkObjectResult OkObjectActionResult()
        {
            return new OkObjectResult(new { Name = "OkObjectActionResult" });
        }

        //200 with an object if formatting succeeds
        public OkObjectResult OkWithObjectActionResult()
        {
            return Ok(new { Name = "OkWithObjectActionResult" });
        }

        // empty 200 without object and formatting
        public OkResult OkEmptyWithoutObject()
        {
            return Ok();
        }

        //return 201 created status code along with the path of the created resource and the actual object
        public CreatedResult CreatedActionResult()
        {
            return Created(new Uri("/Home/Index", UriKind.Relative), new { Name = "CreatedActionResult" });
        }

        //return 201 created status code along with the controller, action, route values and the actual object that is created
        public CreatedAtActionResult CreatedAtActionActionResult()
        {
            return CreatedAtAction("IndexWithId", "Home", new { id = 2, area = "" },
                   new { Name = "CreatedAtActionActionResult" });
        }

        //return 201 created status code along with the route name, route value, and the actual object that is created
        public CreatedAtRouteResult CreatedAtRouteActionResult()
        {
            return CreatedAtRoute("default", new { Id = 2, area = "" }, new { Name = "CreatedAtRouteActionResult" });
        }

        //return 202 accepted which means info in accepted for processing, and you can return a Uri for more info about processing and an object containing pertinent data
        public AcceptedResult AcceptedActionResult()
        {
            return Accepted(new Uri("/Home/Index", UriKind.Relative), new { Name = "AcceptedActionResult" });
        }

        //return 202 accepted which means info in accepted for processing, and you can return controller and action name along with route values
        //for more info about processing and an object containing pertinent data
        public AcceptedAtActionResult AcceptedAtActionActionResult()
        {
            return AcceptedAtAction("IndexWithId", "Home", new { Id = 2, area = "" },
                   new { Name = "AcceptedAtActionActionResult" });
        }

        //return 202 accepted which means info in accepted for processing, and you can return route name along with route values
        //for more info about processing and an object containing pertinent data
        public AcceptedAtRouteResult AcceptedAtRouteActionResult()
        {
            return AcceptedAtRoute("default", new { Id = 2, area = "" }, new { Name = "AcceptedAtRouteActionResult" });
        }

        //returns 204 no content status code response
        public NoContentResult NoContentActionResult()
        {
            return NoContent();
        }

        //returns an empty 400 response
        public BadRequestResult BadRequestActionResult()
        {
            return BadRequest();
        }

        //returns 400 with an object containing error detail 
        // as object or as Model State Dictionary
        public BadRequestObjectResult BadRequestObjectActionResult()
        {
            return BadRequest(new { Name = "BadRequestObjectActionResult" });
        }

        //returns and empty 404 response
        public NotFoundResult NotFoundActionResult()
        {
            return NotFound();
        }

        //returns 404 with an object containing pertinent info
        public NotFoundObjectResult NotFoundObjectActionResult()
        {
            return NotFound(new { Id = 2, error = "There was no item with an id of 2." });
        }

        //returns UnsupportedMediaType (415) response
        public UnsupportedMediaTypeResult UnsupportedMediaTypeActionResult()
        {
            return new UnsupportedMediaTypeResult();
        }

        //returns a response with specified status code
        public StatusCodeResult StatusCodeActionResult()
        {
            return StatusCode(404);
        }

        //returns a response with specified status code along with an object
        public ObjectResult StatusCodeWithObject()
        {
            return StatusCode(404, new { Name = "StatusCodeWithObject" });
        }






    }
}
