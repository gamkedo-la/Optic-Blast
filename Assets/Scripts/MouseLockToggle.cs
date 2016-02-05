using UnityEngine;
using System.Collections;

public class MouseLockToggle : MonoBehaviour {

	void ToggleMouseLock() {
		if(Cursor.lockState == CursorLockMode.Locked) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = false;
		} else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = true;
		}
	}

	void Start() {
		ToggleMouseLock();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Minus)) {
			ToggleMouseLock();
		}	
	}
}
