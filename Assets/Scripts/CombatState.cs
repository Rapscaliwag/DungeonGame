using UnityEngine;
using System.Collections;

public class CombatState : MonoBehaviour
{
    public enum CombatStates
    {
        START,
        PLAYERMOVE,
        ENEMYMOVE,
        LOSE,
        WIN
    }

    private CombatStates currentState;

	void Start ()
    {
        currentState = CombatStates.START;
	}
	
	void Update ()
    {
	    switch(currentState)
        {
            case (CombatStates.START):
                break;
            case (CombatStates.PLAYERMOVE):
                break;
            case (CombatStates.ENEMYMOVE):
                break;
            case (CombatStates.LOSE):
                break;
            case (CombatStates.WIN):
                break;
        }
	}
}
