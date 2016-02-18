using UnityEngine;
using System.Collections;

public class MoveAtPlayer : MonoBehaviour {
	public static Transform playerRef;
	private float moveSpeed = 3.0f;

	// Use this for initialization
	void Start () {
		if(playerRef == null) {
			playerRef = GameObject.FindWithTag("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vectDiff = playerRef.position - transform.position;
		float distTo = vectDiff.magnitude;

		if(distTo < TapToTeleport.nearestDist) {
			TapToTeleport.nearestDist = distTo;
		}

		if(distTo < 0.5f) {
			// TapToTeleport.playerHarm++;
			TapToTeleport.diedLastRound = 1;
			Application.LoadLevel("MenuScene");
			/*Destroyable destScript = GetComponent<Destroyable>();
			if(destScript) {
				destScript.Explode(false);
			}*/
		}
		Vector3 vectorDir = vectDiff.normalized;
		transform.position += vectorDir * moveSpeed * Time.deltaTime;
	}
}
