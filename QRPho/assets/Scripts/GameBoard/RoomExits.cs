using UnityEngine;
using System.Collections;

namespace Deception {
	//[Flags]
	public enum ROOM_EXIT_FLAGS {
		NONE = 0x0,
		NORTH = 0x1,
		EAST = 0x2,
		SOUTH = 0x4,
		WEST = 0x8
	}
}
