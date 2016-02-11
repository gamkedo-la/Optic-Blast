using UnityEngine;
using System.Collections;

public class moveWithPlayer : MonoBehaviour {
	public Transform followGO;
	Vector3 offset;

	void Start() {
		offset = transform.position - followGO.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = followGO.position + offset;
	
	}
}
