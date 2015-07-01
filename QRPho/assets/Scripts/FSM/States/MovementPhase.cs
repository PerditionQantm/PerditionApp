using UnityEngine;
using System.Collections;

public class MovementPhase : FSM_State<Player>
{
		public override void Begin (Player obj)
		{
				//Checks if Want To Move
				//Checks that Movement is still legal
		}
		public override void Resume (Player obj)
		{
				//Checks if Want To Move
				//Checks that Movement is still legal or needed
		}
		public override void Run (Player obj)
		{
				//Waits If No Movement
				//Moves the player; checks for events
		}
		public override void Pause (Player obj)
		{
				//Does nothing; to review
		}
		public override void End (Player obj)
		{
				//Nothing if no movement
				//Confirms movement
		}
	
}
