using UnityEngine;
using System.Collections;

public class WanderAI : MonoBehaviour {
	float maxDistFrom = -1;
	Vector3 vel = Vector3.zero;

	void Start() {
		StartCoroutine(AIUpdate());
	}

	void newDir() {
		vel = Random.onUnitSphere;
	}

	IEnumerator AIUpdate() {
		while(true) {
			yield return new WaitForSeconds(0.5f);
			if(maxDistFrom < 0.0f) {
				if(MoveAtPlayer.playerRef == null) {
					continue;
				}
				maxDistFrom = Vector3.Distance( MoveAtPlayer.playerRef.transform.position, transform.position );
			}
			newDir();
		}
	}

	// Update is called once per frame
	void Update () {
		if(Physics.Raycast(transform.position, vel, 6.0f)) {
			newDir();
		}

		transform.position += vel * Time.deltaTime * 10.0f;

		if(MoveAtPlayer.playerRef) {
			if(transform.position.y < MoveAtPlayer.playerRef.transform.position.y) {
				Vector3 stayGrounded = transform.position;
				stayGrounded.y = MoveAtPlayer.playerRef.transform.position.y;
				transform.position = stayGrounded;
			}
			if(transform.position.y >= MoveAtPlayer.playerRef.transform.position.y + 20.0f) {
				Vector3 stayGrounded = transform.position;
				stayGrounded.y = MoveAtPlayer.playerRef.transform.position.y + 20.0f;
				transform.position = stayGrounded;
			}
			if(maxDistFrom > 0.0f && Vector3.Distance(MoveAtPlayer.playerRef.transform.position, transform.position) > maxDistFrom) {
				Vector3 vDiff = transform.position - MoveAtPlayer.playerRef.transform.position;
				transform.position = MoveAtPlayer.playerRef.transform.position + vDiff.normalized * maxDistFrom;
			}
		}
	}
}
