using UnityEngine;
using System.Collections;

public class Debug_Player : MonoBehaviour {

	public BoardLocation roomCurrent = null;
	public GameBoard boardMap;

	private bool bMoving = false;

	public Vector2 vLocation;
	
	void Start() {
		vLocation = new Vector2(0, 1);
	}

	void Update() {
		if (roomCurrent == null) {
			bMoving = true;
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if ((roomCurrent.iExits & Deception.ROOM_EXIT_FLAGS.WEST) == Deception.ROOM_EXIT_FLAGS.WEST) {
				vLocation = new Vector2(vLocation.x, vLocation.y - 1);
				bMoving = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if ((roomCurrent.iExits & Deception.ROOM_EXIT_FLAGS.EAST) == Deception.ROOM_EXIT_FLAGS.EAST) {
				vLocation = new Vector2(vLocation.x, vLocation.y + 1);
				bMoving = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if ((roomCurrent.iExits & Deception.ROOM_EXIT_FLAGS.NORTH) == Deception.ROOM_EXIT_FLAGS.NORTH) {
				vLocation = new Vector2(vLocation.x + 1, vLocation.y);
				bMoving = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if ((roomCurrent.iExits & Deception.ROOM_EXIT_FLAGS.SOUTH) == Deception.ROOM_EXIT_FLAGS.SOUTH) {
				vLocation = new Vector2(vLocation.x - 1, vLocation.y);
				bMoving = true;
			}
		}

		if (bMoving && boardMap.ll_rooms != null) {
			roomCurrent = boardMap.ll_rooms[(int)Mathf.Abs(vLocation.y), (int)Mathf.Abs(vLocation.x)];
			Debug.Log(this.roomCurrent.sName);
			bMoving = false;
		}

		this.transform.position = new Vector2(vLocation.y, vLocation.x);
	}
}
