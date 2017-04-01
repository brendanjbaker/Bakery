using Bakery.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

public static class EventStreamerExtensions
{
	public static async Task StreamAsync(this IEventStreamer eventStreamer, String topic, HttpContext httpContext)
	{
		var buffer = new ArraySegment<Byte>(new Byte[4096]);
		var webSocket = await httpContext.WebSockets.AcceptWebSocketAsync();

		await eventStreamer.StreamAsync(topic, httpContext.RequestAborted, async message =>
		{
			await webSocket.SendTextAsync(message);

			var receiveResult = await webSocket.ReceiveAsync(buffer, httpContext.RequestAborted);

			if (receiveResult.CloseStatus.HasValue)
				httpContext.Abort();
		});
	}

	public static async Task StreamAsync(this IEventStreamer eventStreamer, String topic, HttpContext httpContext, Func<Task<StatusCodeResult>> preflightFunction)
	{
		var preflightResponse = await preflightFunction();

		if (preflightResponse == null)
		{
			httpContext.Response.StatusCode = preflightResponse.StatusCode;

			return;
		}

		await eventStreamer.StreamAsync(topic, httpContext);
	}
}
