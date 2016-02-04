﻿using UnityEngine;
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
		float distTo = vectDiff.magnitude;

		if(distTo < TapToTeleport.nearestDist) {
			TapToTeleport.nearestDist = distTo;
		}

		if(distTo < 0.5f) {
			TapToTeleport.playerHarm++;
			Destroyable destScript = GetComponent<Destroyable>();
			if(destScript) {
				destScript.Explode(false);
			}
		}
		Vector3 vectorDir = vectDiff.normalized;
		transform.position += vectorDir * moveSpeed * Time.deltaTime;
	}
}
