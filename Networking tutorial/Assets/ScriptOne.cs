using UnityEngine;
using System.Collections;
//THE CONNECTION CODE
public class ScriptOne : MonoBehaviour {
	public string connectionIP = "127.0.0.1";
	public int connectionPort = 25001;

	void OnGUI()
	{
		if (Network.peerType == NetworkPeerType.Disconnected)//if you're not connected
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Disconnected");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Client Connect"))
			{
				Network.Connect(connectionIP, connectionPort);
			}
			if (GUI.Button(new Rect(10, 50, 120, 20), "Initialize Server"))
			{
				Network.InitializeServer(32, connectionPort, false);//max # of connections, port, NAT (network address translation)
			}
		}
		else if (Network.peerType == NetworkPeerType.Client)//if you're connected as client
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Client");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect"))
			{
				Network.Disconnect(200);//200 is the timeout number
			}
		}
		else if (Network.peerType == NetworkPeerType.Server)//if you are the server
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Server");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect"))
			{
				Network.Disconnect(200);
			}
		}
	}
}
