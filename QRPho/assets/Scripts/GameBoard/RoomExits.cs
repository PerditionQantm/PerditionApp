using UnityEngine;
using System.Collections;

namespace Deception {
	[System.Flags]
	public enum ROOM_EXIT_FLAGS {
		NONE = 0,
		NORTH = 1 << 0,
		EAST = 1 << 1,
		SOUTH = 1 << 2,
		WEST = 1 << 3
	}
}
