using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum State {cell, sheets_0, lock_0, mirror, sheets_1, lock_1, cell_mirror, freedom};

	State currentState;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState)
		{
			case State.cell:
				StateCell();
				break;
			case State.sheets_0:
				StateSheet0();
				break;
			case State.lock_0:
				StateLock0();
				break;
			case State.mirror:
				StateMirror();
				break;
			case State.cell_mirror:
				StateCellMirror();
				break;
			case State.sheets_1:
				StateSheet1();
				break;
			case State.lock_1:
				StateLock1();
				break;
			case State.freedom:
				StateFreedom();
				break;
			default:
				StateCell();
				break;
		}
	}

	void StateCell()
	{
		text.text = "You are in a prison cell and you want to escape. " +
					"There are some dirty sheets on the bed, a mirror on " +
					"the wall, and the door is locked from the outside.\n\n" +
					"Press <b>S</b> to view Sheets, <b>M</b> to view Mirror and " +
					"<b>L</b> to view Lock";

		if(Input.GetKeyDown(KeyCode.S))
		{
			currentState = State.sheets_0;
		} 
		else if (Input.GetKeyDown(KeyCode.L))
		{
			currentState = State.lock_0;
		} 
		else if (Input.GetKeyDown(KeyCode.M))
		{
			currentState = State.mirror;
		}
	}

	void StateCellMirror()
	{
		text.text = "You are still in your cell and you STILL want to escape! " +
					"There are some dirty sheets on the bed, a mark where the mirror " +
					"was, and the pesky door is still there and firmly locked!\n\n" +
					"Press <b>S</b> to view Sheets, or " +
					"<b>L</b> to view Lock";

		if(Input.GetKeyDown(KeyCode.S))
		{
			currentState = State.sheets_1;
		} 
		else if (Input.GetKeyDown(KeyCode.L))
		{
			currentState = State.lock_1;
		} 
	}

	void StateSheet0()
	{
		text.text = "You can't beleive you sleep in these things! Surely it's " +
					"time somebody changed them. The pleasures of prison life, I " +
					"guess!\n\n" +
					"Press <b>R</b> to return to roaming cell";

		if(Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.cell;
		} 
	}

	void StateSheet1()
	{
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better. \n\n" +
					"Press <b>R</b> to return to roaming your cell";

		if(Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.cell_mirror;
		} 
	}

	void StateLock0()
	{
		text.text = "This is one of the button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press <b>R</b> to return to roaming cell";

		if(Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.cell;
		} 
	}

	void StateLock1()
	{
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"do you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirt buttons, and hear a click. \n\n" +
					"Press <b>O</b> to open, or <b>R</b> to return to your cell";

		if(Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.cell_mirror;
		} 
		else if (Input.GetKeyDown(KeyCode.O))
		{
			currentState = State.freedom;
		}
	}

	void StateMirror()
	{
		text.text = "The dirt old mirror on the wall seems loose. \n\n " +
					"Press <b>T</b> to take the mirror or <b>R</b> to return to roaming cell.";

		if(Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.cell;
		} 
		else if (Input.GetKeyDown(KeyCode.T))
		{
			currentState = State.cell_mirror;
		}
	}

	void StateFreedom()
	{
		text.text = "You are FREE! \n\n" +
					"Press <b>P</b> to play again";
		
		if (Input.GetKeyDown(KeyCode.P))
		{
			currentState = State.cell;
		}
	}
}
