using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DragonFly.Domain.Entities.ViewModel
{

    public interface IResponseModel
    {
        string Message { get; set; }

        bool DidError { get; set; }

        string ErrorMessage { get; set; }
    }

    public interface ISingleResponseModel<TModel> : IResponseModel
    {
        TModel Model { get; set; }
    }
    public class SingleResponseModel<TModel> : ISingleResponseModel<TModel>
    {
        public string Message { get; set; } = "";

        public bool DidError { get; set; }

        public string ErrorMessage { get; set; } = "";

        public TModel Model { get; set; }
    }

    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse(this IResponseModel response)
            => new ObjectResult(response)
            {
                StatusCode = (int)(response.DidError ? HttpStatusCode.InternalServerError : HttpStatusCode.OK)
            };

        public static IActionResult ToHttpCreatedResponse<TModel>(this ISingleResponseModel<TModel> response)
        {
            var status = HttpStatusCode.Created;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponseModel<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

    }

}
