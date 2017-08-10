using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum State {cell, sheets_0, lock_0, mirror, sheets_1, lock_1, cell_mirror, corridor_0, 
	stairs_0, floor, closed_door, stairs_1, corridor_1, in_closet, corridor_2, stairs_2, corridor_3, 
	courtyard};

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
			case State.corridor_0:
				StateCorridor0();
				break;
			case State.stairs_0:
				StateStairs0();
				break;
			case State.floor:
				StateFloor();
				break;
			case State.closed_door:
				StateClosedDoor();
				break;
			case State.stairs_1:
				StateStairs1();
				break;
			case State.corridor_1:
				StateCorridor1();
				break;
			case State.in_closet:
				StateInCloset();
				break;
			case State.corridor_2:
				StateCorridor2();
				break;
			case State.stairs_2:
				StateStairs2();
				break;
			case State.corridor_3:
				StateCorridor3();
				break; 
			case State.courtyard:
				StateCourtyard();
				break;
			default:
				StateCell();
				break;
		}
	}

	#region States Description
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
			currentState = State.corridor_0;
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

	void StateCorridor0()
	{
		text.text = "You're out of your cell, but not out of trouble." +
					"You are in the corridor, there's a closet and some stairs leading to " +
					"the courtyard. There's also various detritus on the floor.\n\n" +
					"<b>C</b> to view the Closet, <b>F</b> to inspect the Floor, and <b>S</b> to climb the stairs";

		if(Input.GetKeyDown(KeyCode.S))
		{
			currentState = State.stairs_0;
		} 
		else if (Input.GetKeyDown(KeyCode.F))
		{
			currentState = State.floor;
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			currentState = State.closed_door;
		}
	}

	void StateStairs0()
	{
		text.text = "You start walking up the stairs towards the outside light. " +
					"You realise it's not break time, and you'll be caught immediately. " +
					"You slither back down the stairs and reconsider.\n\n" +
					"Press <b>R</b> to Return to the corridor.";

		if (Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.corridor_0;
		}
		
	}
	
	void StateFloor()
	{
		text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
					"Press <b>R</b> to Return to the standing, or <b>H</b> to take the Hairclip.";

		if (Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.corridor_0;
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			currentState = State.corridor_1;
		}
	}
	
	void StateClosedDoor()
	{
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
					"Maybe you could find something around to help enourage it open?\n\n" +
					"Press <b>R</b> to Return to the corridor";	

		if (Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.corridor_0;
		}
	}
	
	void StateStairs1()
	{
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
					"Press <b>R</b> to Retreat down the stairs";

		if (Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.corridor_1;
		}
	}
	
	void StateCorridor1()
	{
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
					"Now what? You wonder if that lock on the closet would succumb to " +
					"to some lock-picking?\n\n" +
					"<b>P</b> to Pick the lock, and <b>S</b> to climb the stairs";

		if (Input.GetKeyDown(KeyCode.P))
		{
			currentState = State.in_closet;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			currentState = State.stairs_1;
		}
	}
	
	void StateInCloset()
	{
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
					"Seems like your day is looking-up.\n\n" +
					"Press <b>D</b> to Dress up, or <b>R</b> to Return to the corridor";

		if (Input.GetKeyDown(KeyCode.D))
		{
			currentState = State.corridor_3;
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.corridor_2;
		}
	}
	void StateCorridor2()
	{
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
					"Press <b>C</b> to revisit the Closet, and <b>S</b> to climb the stairs";

		if (Input.GetKeyDown(KeyCode.C))
		{
			currentState = State.in_closet;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			currentState = State.stairs_2;
		}
	}
	
	void StateStairs2()
	{
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
					"a hairclip (now badly bent). Even these achievements together don't give " +
					"you the courage to climb up the staris to your death!\n\n" +
					"Press <b>R</b> to Return to the corridor";

		if (Input.GetKeyDown(KeyCode.R))
		{
			currentState = State.corridor_2;
		}
	}
	
	void StateCorridor3()
	{
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
					"You strongly consider the run for freedom.\n\n" +
					"Press <b>S</b> to take the Stairs, or <b>U</b> to Undress";

		if (Input.GetKeyDown(KeyCode.S))
		{
			currentState = State.courtyard;
		}
		else if (Input.GetKeyDown(KeyCode.U))
		{
			currentState = State.in_closet;
		}
	}
	
	void StateCourtyard()
	{
		text.text = "You are FREE! \n\n" +
					"Press <b>P</b> to play again";
		
		if (Input.GetKeyDown(KeyCode.P))
		{
			currentState = State.cell;
		}
	}

	#endregion
}
