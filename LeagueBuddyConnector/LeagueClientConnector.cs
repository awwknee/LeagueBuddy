using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using System.Net.WebSockets.Wamp;
using Timer = System.Timers.Timer;
using LeagueBuddyConnector.Models.LCU;

namespace LeagueBuddyConnector
{
    internal enum LeagueClientMessageCode
    {
        Subscribe = 5,
        Unsubscribe = 6,
        Event = 8
    }

    public class WebSocketEventArgs
    {
        [JsonPropertyName("uri")]
        public string Path { get; set; }
        [JsonPropertyName("eventType")]
        public string Type { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
    }

    public class LeagueClientConnector
    {
        public bool Connected { get; private set; }

        private HttpClient Client { get; set; }

        public event Action? OnConnected;
        public event Action? OnDisconnected;
        public event Action<WebSocketEventArgs>? OnWebsocketMessage;

        private readonly Timer pollTimer;

        private readonly bool riotClient = false;

        public LeagueClientConnector(bool riot)
        {
            riotClient = riot;
            pollTimer = new Timer
            {
                Interval = 5000
            };
            pollTimer.Elapsed += Connect;
            pollTimer.Start();
        }

        public void Stop()
        {
            pollTimer.Stop();
        }

        public async void Connect(object sender, EventArgs args)
        {
            if (Connected) return;

            Tuple<string, string> status = LeagueClientConnectorUtil.GetStatus(riotClient);

            if (status.Item1 == "" || status.Item2 == null) return;

            WampSubscriberClient<LeagueClientMessageCode> client = new();
            client.UseClientWebSocketOptions(options =>
            {
                options.RemoteCertificateValidationCallback = (_, _, _, _) => true;
                options.Credentials = new NetworkCredential("riot", status.Item1);
            });

            try
            {
                await client.ConnectAsync($"wss://127.0.0.1:{status.Item2}/");
            }
            catch
            {
                client.Dispose();
                // Websocket will throw an error if we try to connect to the client too quickly. We should wait a few seconds and then reconnect.
                return;
            }

            await client.SubscribeAsync("OnJsonApiEvent");

            Client = new(new HttpClientHandler()
            {
                SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls12,
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            });
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("riot:" + status.Item1)));
            Client.BaseAddress = new("https://127.0.0.1:" + status.Item2);
            Client.DefaultRequestHeaders.Add("Accept", "application/json");

            Connected = true;
            OnConnected?.Invoke();

            await Task.Run(async () =>
            {
                while (client.State == WebSocketState.Open)
                {
                    try
                    {
                        var response = await client.ReceiveAsync();
                        if (response == null) return;
                        HandleMessage(response);
                    }
                    catch (WebSocketException ex)
                    {
                        // Client closed and websocket did not finish closing properly
                        if (client.State == WebSocketState.Aborted) break;
                    }
                }
            });

            Connected = false;
            OnDisconnected?.Invoke();
            client.Dispose();
            Client.Dispose();
        }

        private void HandleMessage(WampMessage<LeagueClientMessageCode> response)
        {
            try
            {
                JsonElement[] payload = (JsonElement[])(response.Elements[0]);
                var data = payload[1].Deserialize<WebSocketEventArgs>();
                OnWebsocketMessage?.Invoke(data);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }

        }

        public async Task<string> Get(string url)
        {
            if (!Connected) throw new InvalidOperationException("Not connected to LCU");
            var res = await Client.GetAsync(url);
            var stringContent = await res.Content.ReadAsStringAsync();

            if (res.StatusCode == HttpStatusCode.NotFound) return null;
            return stringContent;
        }

        public async void Observe(string url, Action<object> handler)
        {
            OnWebsocketMessage += data =>
            {
                if (data.Path == url) handler(data.Data);
            };

            if (Connected)
            {
                handler(await Get(url));
            }
            else
            {
                async void connectHandler()
                {
                    OnConnected -= connectHandler;
                    handler(await Get(url));
                }

                OnConnected += connectHandler;
            }
        }
    }
}