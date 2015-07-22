using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour {

	public BoardLocation[,] ll_rooms;
	public int iWidth = 4;
	public int iHeight = 4;

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
	
	void Start() {
		ll_rooms = new BoardLocation[iHeight, iWidth];

		for (int i = 0; i < iHeight; i++) {
			for (int j = 0; j < iWidth; j++) {
				ll_rooms[i, j] = new BoardLocation("", true, Deception.ROOM_EXIT_FLAGS.NONE);
			}
		}

		//Hard codiiiiiing
		ll_rooms[0, 1] = new BoardLocation("Station", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprStation);

		ll_rooms[1, 0] = new BoardLocation("Hotel", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprHotel);
		ll_rooms[1, 1] = new BoardLocation("Road", true, Deception.ROOM_EXIT_FLAGS.SOUTH, sprRoad);
		ll_rooms[1, 2] = new BoardLocation("Bank", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprBank);
		ll_rooms[1, 3] = new BoardLocation("Sheriff's Office", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprSheriff);

		ll_rooms[2, 0] = new BoardLocation("Saloon", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprSaloon);
		ll_rooms[2, 1] = new BoardLocation("Road", true, Deception.ROOM_EXIT_FLAGS.SOUTH, sprRoad);
		ll_rooms[2, 2] = new BoardLocation("Butcher", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprButcher);
		ll_rooms[2, 3] = new BoardLocation("Gaol", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprJail);

		ll_rooms[3, 0] = new BoardLocation("Stable", false, Deception.ROOM_EXIT_FLAGS.SOUTH, sprStable);
		ll_rooms[3, 1] = new BoardLocation("City Limits", true, Deception.ROOM_EXIT_FLAGS.SOUTH, sprLimits);
		ll_rooms[3, 2] = new BoardLocation("Road", true, Deception.ROOM_EXIT_FLAGS.SOUTH, sprRoad);
		ll_rooms[3, 3] = new BoardLocation("Road", true, Deception.ROOM_EXIT_FLAGS.SOUTH, sprRoad);

		GameObject newtile;
		for (int i = 0; i < iHeight; i++) {
			for (int j = 0; j < iWidth; j++) {
				if (ll_rooms[i, j].sName != "") {
					newtile = (GameObject)GameObject.Instantiate(protoTile, new Vector2(i, j), Quaternion.identity);
					newtile.GetComponent<SpriteRenderer>().sprite = ll_rooms[i, j].sprTile;
				}
			}
		}
	}

	void Update() {
	
	}
}
