using WebSocketSharp;
using UnityEngine;

public class WS_Client : MonoBehaviour
{
    private WebSocket ws;
    public static string canOpenDoor;

    void Start()
    {
        canOpenDoor = "false";

        ws = new WebSocket("ws://localhost:8080");
        ws.OnMessage += (sender, e) =>
        {
            // Debug.Log("Messagge received from: " + ((WebSocket)sender).Url + ", Data: " + e.Data);
            canOpenDoor = e.Data;
        };
        ws.Connect();
    }
}
