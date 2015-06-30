using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
//T represents the owner of the FSM
public abstract class FSM_State<T> {

	//When the state is first run
	abstract public void Begin(T obj);

	//When the state runs
	abstract public void Run(T obj);

	//When the state has control returned to it
	abstract public void Resume(T obj);

	//When the state relinquishes control to the new top state
	abstract public void Pause(T obj);

	//Before the state is removed from the stack
	abstract public void End(T obj);
}