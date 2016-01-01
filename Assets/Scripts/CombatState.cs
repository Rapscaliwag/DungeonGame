using UnityEngine;
using System.Collections;

public class CombatState : MonoBehaviour
{    
    private bool letsGo = false;
    private bool switchState = true;
    public bool attackHasBeenChosen = false;

    private float betweenTurns = 2f;
    private float introTime = 2.5f;

    public int theAttackSelected; //0,1,2,3 are the attack options

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
        StartCoroutine(WaitToStartFight(introTime));
	}
	
	void Update ()
    {
        if ((switchState) && (currentState == CombatStates.PLAYERMOVE))
        {
            //This is where I am going to make the fighting options first appear on the player's turn.
            //GameObject.Find("PlayerGUI").SetActive(true);
            
        }

        switch (currentState)
        {
            case (CombatStates.START):
                if (letsGo)
                    currentState = CombatStates.PLAYERMOVE;
                break;

            case (CombatStates.PLAYERMOVE):
                if (attackHasBeenChosen)
                {
                    StartCoroutine(SwitchToEnemy(betweenTurns));
                }
                switchState = false;
                break;

            case (CombatStates.ENEMYMOVE):
                switchState = false;
                break;

            case (CombatStates.LOSE):
                break;

            case (CombatStates.WIN):
                break;
        }
	}

    IEnumerator WaitToStartFight(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        letsGo = true;
    }

    IEnumerator SwitchToEnemy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        currentState = CombatStates.ENEMYMOVE;
        switchState = true;
    }
}
