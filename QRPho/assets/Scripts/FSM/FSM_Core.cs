using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class FSM_Core<T>
{

		//public int mappy;
		public T fsmOwner;
		public Stack<FSM_State<T>> st_states;

		//Both Init and Config need to be run in the owner's Start() or similar to launch the FSM
		//Init will essentially hard reset the FSM if run once running, not recommended
		public void Init ()
		{
				st_states = new Stack<FSM_State<T>> ();
		}
	
		public void Config (T owner, FSM_State<T> start_state)
		{
				fsmOwner = owner;
				PushState (start_state);
		}

		//The top of the stack gets updated
		public void Update ()
		{
				if (st_states.Count > 0) {
						st_states.Peek ().Run (fsmOwner);
				}
		}

		//Create a new state and put it at the top of the stack, pausing the old one
		public void PushState (FSM_State<T> new_state)
		{
				if (st_states.Count > 0) {
						st_states.Peek ().Pause (fsmOwner);
				}

				st_states.Push (new_state);
				st_states.Peek ().Begin (fsmOwner);
		}

		//Destroy the top of the stack and resume the past one
		public void PopState ()
		{
				st_states.Pop ().End (fsmOwner);

				if (st_states.Count > 0) {
						st_states.Peek ().Resume (fsmOwner);
				}
		}

		//Pops states until it reaches the bottom state
		public void PopUntilBottom ()
		{
				while (st_states.Count > 1) {
						st_states.Pop ().End (fsmOwner);
						st_states.Peek ().Resume (fsmOwner);
				}
		}

		//Pops states until there are none left
		public void PopUntilEmpty ()
		{
				while (st_states.Count > 0) {
						st_states.Pop ().End (fsmOwner);

						if (st_states.Count > 0) {
								st_states.Peek ().Resume (fsmOwner);
						}
				}
		}

		//Debugging
		public override string ToString ()
		{
				string str = "";	

				str += "States: " + st_states.Count.ToString () + "\t";

				if (st_states.Count > 0) {
						int i = 1;
						foreach (FSM_State<T> state in st_states) {
								str += i.ToString () + ": " + state.ToString () + ", ";
								i++;
						}
				}

				return str;
		}
}