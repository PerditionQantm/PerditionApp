using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour {

	public BoardLocation[,] ll_rooms;
	public GameObject[,] l_goRooms;
	public int iWidth = 5;
	public int iHeight = 4;

	public Transform trStart;

	public GameObject protoTile;
	public Sprite sprStation;
	public Sprite sprRoad;
	public Sprite sprHotel;
	public Sprite sprBank;
	public Sprite sprSheriff;
	public Sprite sprSaloon;
	public Sprite sprButcher;
	public Sprite sprJail;
	public Sprite sprStable;
	public Sprite sprLimits;
	public Sprite sprStore;

	public bool bVisible;
	
	void Start() {
		ll_rooms = new BoardLocation[iHeight, iWidth];
		l_goRooms = new GameObject[iHeight, iWidth];

		for (int i = 0; i < iHeight; i++) {
			for (int j = 0; j < iWidth; j++) {
				ll_rooms[i, j] = new BoardLocation("", true, Deception.ROOM_EXIT_FLAGS.NONE);
				Vector3 vectTemp = new Vector3(trStart.position.x, trStart.position.y, trStart.position.z);
			}
		}

		//Hard codiiiiiing
		ll_rooms[1, 0] = new BoardLocation("Station", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprStation);

		ll_rooms[0, 1] = new BoardLocation("Hotel", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprHotel);
		ll_rooms[1, 1] = new BoardLocation("North Road", true, Deception.ROOM_EXIT_FLAGS.SOUTH | Deception.ROOM_EXIT_FLAGS.EAST | Deception.ROOM_EXIT_FLAGS.NORTH, sprRoad);
		ll_rooms[2, 1] = new BoardLocation("Bank", false, Deception.ROOM_EXIT_FLAGS.EAST | Deception.ROOM_EXIT_FLAGS.WEST, sprBank);
		ll_rooms[3, 1] = new BoardLocation("Sheriff's Office", false, Deception.ROOM_EXIT_FLAGS.WEST | Deception.ROOM_EXIT_FLAGS.SOUTH, sprSheriff);

		ll_rooms[0, 2] = new BoardLocation("Saloon", false, Deception.ROOM_EXIT_FLAGS.NORTH | Deception.ROOM_EXIT_FLAGS.EAST | Deception.ROOM_EXIT_FLAGS.SOUTH, sprSaloon);
		ll_rooms[1, 2] = new BoardLocation("Crossroads", true, Deception.ROOM_EXIT_FLAGS.NORTH | Deception.ROOM_EXIT_FLAGS.EAST | Deception.ROOM_EXIT_FLAGS.SOUTH | Deception.ROOM_EXIT_FLAGS.WEST, sprRoad);
		ll_rooms[2, 2] = new BoardLocation("Butcher", false, Deception.ROOM_EXIT_FLAGS.SOUTH | Deception.ROOM_EXIT_FLAGS.WEST, sprButcher);
		ll_rooms[3, 2] = new BoardLocation("Gaol", false, Deception.ROOM_EXIT_FLAGS.NORTH | Deception.ROOM_EXIT_FLAGS.SOUTH, sprJail);

		ll_rooms[0, 3] = new BoardLocation("Stable", false, Deception.ROOM_EXIT_FLAGS.NORTH | Deception.ROOM_EXIT_FLAGS.EAST, sprStable);
		ll_rooms[1, 3] = new BoardLocation("City Limits", true, Deception.ROOM_EXIT_FLAGS.NORTH | Deception.ROOM_EXIT_FLAGS.EAST | Deception.ROOM_EXIT_FLAGS.WEST, sprLimits);
		ll_rooms[2, 3] = new BoardLocation("South Road", true, Deception.ROOM_EXIT_FLAGS.NORTH | Deception.ROOM_EXIT_FLAGS.EAST | Deception.ROOM_EXIT_FLAGS.WEST, sprRoad);
		ll_rooms[3, 3] = new BoardLocation("South-East Road", true, Deception.ROOM_EXIT_FLAGS.NORTH | Deception.ROOM_EXIT_FLAGS.EAST | Deception.ROOM_EXIT_FLAGS.WEST, sprRoad);
		ll_rooms[4, 3] = new BoardLocation("General Store", false, Deception.ROOM_EXIT_FLAGS.WEST, sprStore);

		GameObject newtile;
		for (int i = 0; i < iHeight; i++) {
			for (int j = 0; j < iWidth; j++) {
				if (ll_rooms[i, j].sName != "") {
					newtile = (GameObject)GameObject.Instantiate(protoTile, new Vector2(i, -j), Quaternion.identity);
					newtile.GetComponent<SpriteRenderer>().sprite = ll_rooms[i, j].sprTile;
					l_goRooms[i, j] = newtile;
					l_goRooms[i, j].transform.SetParent(trStart);
					//l_goRooms[i, j].transform.position = new Vector3(trStart.position.x + i, trStart.position.y + j, 0);
					//l_goRooms[i, j].transform.localScale = new Vector2(80, 80);

					if ((ll_rooms[i, j].iExits & Deception.ROOM_EXIT_FLAGS.NORTH) == Deception.ROOM_EXIT_FLAGS.NORTH) {
						newtile.GetComponent<Tile>().goUpLink.SetActive(true);
					}

					if ((ll_rooms[i, j].iExits & Deception.ROOM_EXIT_FLAGS.EAST) == Deception.ROOM_EXIT_FLAGS.EAST) {
						newtile.GetComponent<Tile>().goRightLink.SetActive(true);
					}

					if ((ll_rooms[i, j].iExits & Deception.ROOM_EXIT_FLAGS.SOUTH) == Deception.ROOM_EXIT_FLAGS.SOUTH) {
						newtile.GetComponent<Tile>().goDownLink.SetActive(true);
					}

					if ((ll_rooms[i, j].iExits & Deception.ROOM_EXIT_FLAGS.WEST) == Deception.ROOM_EXIT_FLAGS.WEST) {
						newtile.GetComponent<Tile>().goLeftLink.SetActive(true);
					}
				}
			}
		}
		trStart.position = new Vector2(trStart.position.x - 2, trStart.position.y + 1);
	}

	void Update() {
	
	}

	public void ShowMap() {
		trStart.gameObject.SetActive(true);
//		for (int i = 0; i < iHeight; i++) {
//			for (int j = 0; j < iWidth; j++) {
//				l_goRooms[i, j].gameObject.SetActive(true);
//			}
//		}
	}

	public void HideMap() {
		trStart.gameObject.SetActive(false);
//		for (int i = 0; i < iHeight; i++) {
//			for (int j = 0; j < iWidth; j++) {
//				l_goRooms[i, j].gameObject.SetActive(false);
//			}
//		}
	}
}
