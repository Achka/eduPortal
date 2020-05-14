namespace Services.StandardResponses
{
	public class ApiOkResponse : ApiResponse
	{
		public object Result { get; }
		public ApiOkResponse(object result) : base(status: 200) => this.Result = result;
	}
}
