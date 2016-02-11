using UnityEngine;
using System.Collections;

public class DestroyThisIfOnVR : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Application.isEditor == false) {
			Destroy(gameObject);
		}
	}
}
