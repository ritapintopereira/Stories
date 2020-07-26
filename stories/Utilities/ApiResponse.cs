using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Stories.Utilities
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode">error code</param>
        /// <param name="message">error message</param>
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        /// <summary>
        /// Based on the error code returns the appropriate error message
        /// </summary>
        /// <param name="statusCode">error code</param>
        /// <returns>string that contains the error message</returns>
        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
            case StatusCodes.Status404NotFound:
                return "Resource not found";
            //here I could define more error codes but for now this one is enough
            default:
                return null;
        }
    }
}

}
