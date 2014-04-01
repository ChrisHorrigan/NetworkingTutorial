using UnityEngine;
using System;
using System.Collections;
//AUTHORITATIVE SPAWN CODE
public class Authoritative : MonoBehaviour {
	public Transform playerPrefab;
	public ArrayList playerScripts = new ArrayList();
	
	void OnServerInitialized()
	{
		SpawnPlayer(Network.player);
	}
	void OnPlayerConnected(NetworkPlayer player)
	{
		SpawnPlayer(player);
	}
	void SpawnPlayer(NetworkPlayer player)
	{
			string tempPlayerString = player.ToString ();
			int playerNumber = Convert.ToInt32(tempPlayerString);
			Transform newPlayerTransform = (Transform)Network.Instantiate (playerPrefab, transform.position, transform.rotation, playerNumber);
			playerScripts.Add (newPlayerTransform.GetComponent ("CubeScriptAuthoritative"));//that's the authoritative movement script
			NetworkView theNetworkView = newPlayerTransform.networkView;
			theNetworkView.RPC ("SetPlayer", RPCMode.AllBuffered, player);
	}

}
