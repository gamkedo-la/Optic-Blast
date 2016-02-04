using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TapToTeleport : MonoBehaviour {
	public GameObject focusAt;
	public Text printDebug;
	public Collider focusAtCollider;

	void Start() {
		focusAtCollider = focusAt.GetComponent<Collider>();
	}

	// Update is called once per frame
	void Update () {
		// printDebug.text = "" + Mathf.Round(Input.GetAxis("Mouse X")*10.0f);
		if(Mathf.Abs( Input.GetAxis("Mouse X") ) > 30.0f || Input.GetMouseButtonDown(1)) {
			Vector3 gotoPos = focusAt.transform.position;
			gotoPos.y = transform.position.y;
			transform.position = gotoPos;
			transform.rotation = Quaternion.identity;
		}
	}
}
