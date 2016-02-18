using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text>();

		switch(TapToTeleport.diedLastRound) {
		case 0:
			myText.text = "Success: AREA CLEARED";
			break;
		case 1:
			myText.text = "Failure: OVERRUN!";
			break;
		default:
			transform.parent.gameObject.SetActive(false);
			break;
		}
	}
}
