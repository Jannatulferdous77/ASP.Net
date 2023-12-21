using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntoLayer.Controllers
{
    public class StudentController : ApiController
    {
        [HttpPost] // method
        [Route("api/student/add")] //route/url
        public HttpResponseMessage Create(StudentDTO obj) //user input with DTO format
        {
            try
            {
                var data = StudentService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new {message="Created Successfully"});
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("api/student/list")]
        public HttpResponseMessage GetAll() //user input with DTO format
        {
            try
            {
                var data = StudentService.GetAll();   
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
