using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	Vector3 lastPosition;
	//float minimumMovement = .05f;
	// Update is called once per frame
	void Update () {
		if (networkView.isMine)//this lets the server move the cube around
		{
			Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			float speed = 5;
			transform.Translate(speed * moveDir * Time.deltaTime);
//			if (Vector3.Distance(transform.position, lastPosition) > minimumMovement)//an RPC thing that is just for show
//			{
//				lastPosition = transform.position;
//				networkView.RPC("SetPosition", RPCMode.Others, transform.position);
//			}
		}
	}
	//just another RPC thing, not the main method that will be used here
//	[RPC]
//	void SetPosition(Vector3 newPosition)
//	{
//		transform.position = newPosition;
//	}
	void Awake()
	{
		if (!networkView.isMine)
			enabled = false;
	}
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
				if (stream.isWriting) {
						Vector3 pos = transform.position;
						stream.Serialize (ref pos);
				} else {
						Vector3 receivedPosition = Vector3.zero;
						stream.Serialize (ref receivedPosition);
						transform.position = receivedPosition;
				}
		}
}
