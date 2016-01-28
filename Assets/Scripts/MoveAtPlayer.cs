using UnityEngine;
using System.Collections;

public class MoveAtPlayer : MonoBehaviour {
	static Transform playerRef;
	private float moveSpeed = 6.0f;

	// Use this for initialization
	void Start () {
		if(playerRef == null) {
			playerRef = GameObject.FindWithTag("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vectDiff = playerRef.position - transform.position;
		if(vectDiff.magnitude < 0.0f) {
			//Application.LoadLevel(Application.loadedLevel
			Debug.Log("Player died");
		}
		Vector3 vectorDir = vectDiff.normalized;
		transform.position += vectorDir * moveSpeed * Time.deltaTime;
	}
}
