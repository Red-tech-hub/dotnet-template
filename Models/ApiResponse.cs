namespace MyWeatherApi.Models
{
    /// <summary>
    /// Standard API response wrapper for all API endpoints
    /// </summary>
    /// <typeparam name="T">Type of data being returned</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indicates if the request was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Message providing additional information about the response
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// The data returned by the API
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Creates a successful response with data
        /// </summary>
        public static ApiResponse<T> SuccessResponse(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// Creates a failure response with a message
        /// </summary>
        public static ApiResponse<T> ErrorResponse(string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = default
            };
        }
    }
}
