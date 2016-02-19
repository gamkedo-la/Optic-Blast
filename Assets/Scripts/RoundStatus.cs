using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundStatus : MonoBehaviour {
	public int forLev = 0;

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text>();
		int stagesWon = 0;
		bool winMessageEarned = false;

		if(forLev >= 0 && forLev <= 3) {
			winMessageEarned = TypeText.wonAlready[forLev];

			if(winMessageEarned) {
				myText.text = "Success: AREA CLEARED";
			} else {
				myText.text = "ATTENTION REQUIRED";
			}
		} else {
			for(int i = 0; i < 3; i++) {
				if(TypeText.wonAlready[i]) {
					stagesWon++;
				}
			}
			winMessageEarned = (stagesWon >= 3);
			if(winMessageEarned) {
				myText.text = "ULTIMATE VICTORY!";
			} else {
				myText.text = stagesWon + " of 3 cleared";
			}
		}

		/*switch(TapToTeleport.diedLastRound) {
		case 0:
			if(stagesWon >= 3) {
				myText.text = "ULTIMATE VICTORY!";
			} else {
				myText.text = "Success: AREA CLEARED";
			}
			break;
		case 1:
			myText.text = "Failure: OVERRUN!";
			break;
		default:
			transform.parent.gameObject.SetActive(false);
			break;
		}*/
	}
}
