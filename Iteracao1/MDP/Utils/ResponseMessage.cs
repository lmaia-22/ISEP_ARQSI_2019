using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ProjectIteration1.Models;
using ProjectIteration1.DTO;
using System.Net;

namespace ProjectIteration1.Utils
{
    public enum MessageType { OK, NOT_FOUND, CREATED, UPDATED, DELETED, BAD_FORMAT, INVALID_DATA };

    public class ResponseMessage
    {   
        public static ActionResult HttpResponse(int statusCode, MessageType errorType, string message, string content){
            string finalMessage = "{\"messageType\":\"" + errorType.ToString() + "\"," + 
                    "\"message\":\""+ message +"\"," +
                    "\"content\":" + content + "}";

            return new ContentResult()
                {
                    Content = finalMessage,
                    ContentType = "application/json; charset=utf-8",
                    StatusCode = statusCode
                };
        }

        public static ActionResult HttpResponse(int statusCode, MessageType errorType, string message){
            string finalMessage = "{\"messageType\":\"" + errorType.ToString() + "\"," + 
                    "\"message\":\""+ message +"\"," +
                    "\"content\":\"\"}";

            return new ContentResult()
                {
                    Content = finalMessage,
                    ContentType = "application/json; charset=utf-8",
                    StatusCode = statusCode
                };
        }
    }
}