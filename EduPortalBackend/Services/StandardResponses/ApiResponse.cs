using Newtonsoft.Json;

namespace Services.StandardResponses
{
	public class ApiResponse
	{
		public int Status { get; }
		public string Title { get; }

		public ApiResponse(int status, string title = null) =>
			(this.Status, this.Title) = (status, title ?? GetDefaultTitleForStatus(status));

		private static string GetDefaultTitleForStatus(int status) =>
			status switch
			{
				404 => "Resource not found",
				500 => "An unhandled error occurred",
				_ => null
			};
	}
}
