using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TapToTeleport : MonoBehaviour {
	public GameObject focusAt;
	public Text printDebug;
	public Material viewBlocker;
	public RectTransform swipeIndicator;

	// suuupppeeeerrrr lazy hack, these don't even belong in this class, let along as static values
	public static int enemiesDefeated = 0; 
	public static int suppliesLost = 0;
	public static int diedLastRound = -1;

	int spawnersToKillMax = 0;

	public static float nearestDist = 12.0f;

	float jumpSwipeThreshold = 10.0f;
	float fadeTelePortRate = 3.4f;

	Color fadeBlocker;
	Collider focusAtCollider;

	Vector3 gotoPos;
	public static float jumpProcess = 0.0f;

	void LateUpdate() {
		Vector3 swipeFeedback = Vector3.one;
		swipeFeedback.y = nearestDist / 12.0f;
		swipeFeedback.y = Mathf.Clamp01(swipeFeedback.y);
		swipeIndicator.localScale = swipeFeedback;

		nearestDist = 12.0f;
	}

	void Start() {
		fadeBlocker = Color.black;
		focusAtCollider = focusAt.GetComponent<Collider>();

		OVRTouchpad.Create ();
		OVRTouchpad.TouchHandler += HandleTouchHandler;

		diedLastRound = 0;
		spawnersToKillMax = 0;
	}

	void HandleTouchHandler (object sender, System.EventArgs e)
	{
		OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
		OVRTouchpad.TouchEvent touchEvent = touchArgs.TouchType;

		if (touchEvent == OVRTouchpad.TouchEvent.Left) {
				teleportStart();
		}
	}

	void teleportStart() {
		if(jumpProcess == 0.0f) {
			jumpProcess = 0.01f;
			gotoPos = focusAt.transform.position;
			gotoPos.y = transform.position.y;
			if(Vector3.Distance(gotoPos, transform.position) < 10.0f) {
				transform.position = transform.position + (gotoPos - transform.position).normalized * 10.0f;
			}
		}
	}

	// Update is called once per frame
	void Update () {

		if(Destroyable.mustDestroyCount > spawnersToKillMax) {
			spawnersToKillMax = Destroyable.mustDestroyCount;
		}

		if( Application.isEditor && Input.GetButtonDown("Fire2") ) {
			teleportStart();
		}
		if(jumpProcess > 0.0f) {
			jumpProcess += Time.deltaTime * fadeTelePortRate;
			fadeBlocker.a = jumpProcess;
			viewBlocker.color = fadeBlocker;
			if(jumpProcess > 1.0f) {
				transform.position = gotoPos;
				if(Application.isEditor == false) {
					transform.rotation = Quaternion.identity;
				}
				jumpProcess = -0.99f;
			}
		}
		if(jumpProcess < 0.0f) {
			jumpProcess += Time.deltaTime * fadeTelePortRate;

			fadeBlocker.a = Mathf.Abs(jumpProcess);
			viewBlocker.color = fadeBlocker;
			if(jumpProcess > 0.0f) {
				jumpProcess = 0.0f;
			}
		}

		if(printDebug) {
			printDebug.text = "Enemies defeated: " + enemiesDefeated + "\n" +
				"Collateral Losses: " + suppliesLost + "\n" +
				// "You died: " + playerHarm + " times\n" +
				"Virus Spawners Left: "+ Destroyable.mustDestroyCount +"/"+ spawnersToKillMax +"\n" +
				"Hold: fire - Swipe forward: teleport";
		}
	}
}
