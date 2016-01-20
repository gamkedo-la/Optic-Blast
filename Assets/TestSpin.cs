using UnityEngine;
using System.Collections;

public class TestSpin : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right, 40.0f * Time.deltaTime);	
	}
}
