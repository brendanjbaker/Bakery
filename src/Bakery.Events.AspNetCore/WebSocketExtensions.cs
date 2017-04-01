using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static class WebSocketExtensions
{
	public async static Task SendTextAsync(this WebSocket webSocket, String text)
	{
		await SendTextAsync(webSocket, text, Encoding.UTF8);
	}

	public async static Task SendTextAsync(this WebSocket webSocket, String text, Encoding encoding)
	{
		var textBytes = encoding.GetBytes(text);

		await webSocket.SendAsync(new ArraySegment<Byte>(textBytes), WebSocketMessageType.Text, true, CancellationToken.None);
	}
}
