using UnityEngine;
using System.Collections;

public class TapToTeleport : MonoBehaviour {
	public GameObject focusAt;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") /*|| Input.GetButtonDown("Mouse 1")*/) {
			transform.position = focusAt.transform.position;
			transform.rotation = Quaternion.identity;
		}
	}
}
