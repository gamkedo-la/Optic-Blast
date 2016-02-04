using UnityEngine;
using System.Collections;

public class LookToAim : MonoBehaviour {
	public GameObject focusAt;
	int lMask;

	void Start() {
		lMask = ~LayerMask.GetMask("Ignore Raycast");
	}

	// Update is called once per frame
	void Update () {
		RaycastHit rhInfo;
		if(Physics.Raycast(transform.position, transform.forward, out rhInfo, 10000.0f, lMask)) {
			focusAt.transform.position = rhInfo.point - transform.forward * 1.6f + Vector3.up*1.6f;
		}
	}
}
