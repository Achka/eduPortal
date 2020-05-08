using System.Collections.Generic;

namespace Services.StandardResponses
{
	public class ApiBadRequestResponse : ApiResponse
	{
		public IEnumerable<string> Errors { get; }
		public ApiBadRequestResponse(IEnumerable<string> errors) : base(status: 400) {
			this.Errors = errors;
		}
	}
}
