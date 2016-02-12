using UnityEngine;
using System.Collections;

public class TurnOnCameraIfNonEditor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera thisCam = GetComponent<Camera>();
		thisCam.enabled = (Application.isEditor == false);
	}
}
