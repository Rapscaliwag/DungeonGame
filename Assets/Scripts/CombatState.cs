using UnityEngine;
using System.Collections;

public class CombatState : MonoBehaviour
{
    private bool letsGo = false;
    private bool switchState = true;
    public bool attackHasBeenChosen = false;

    private float betweenTurns = 1f;
    private float introTime = 2.5f;

    public int enemyAttackDamage = 20;
    public int slashAttackDamage = 50;
    public int stabAttackDamage = 10;
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

    public Canvas playerGUIPrefab;

    void Start()
    {
        currentState = CombatStates.START;
        StartCoroutine(WaitToStartFight(introTime));
    }

    void Update()
    {
        if ((switchState) && (currentState == CombatStates.PLAYERMOVE))
        {
            //This is where I am going to make the fighting options first appear on the player's turn.
            //GameObject.Find("PlayerGUI").SetActive(true);
            Instantiate(playerGUIPrefab);
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
                    Destroy(playerGUIPrefab);
                    StartCoroutine(SwitchToEnemy(betweenTurns));

                    //Here is where damage is assigned according to which attack was chosen
                    if (theAttackSelected == 0)
                        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>().TakeDamage(stabAttackDamage);
                    else if (theAttackSelected == 1)
                        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>().TakeDamage(slashAttackDamage);
                }
                switchState = false;
                Debug.Log(theAttackSelected);  //TESTING TO SEE IF ATTACKS CAN BE SELECTED!!!
                break;

            case (CombatStates.ENEMYMOVE):
                //Eventually the enemy will choose a certain attack based on the circumstances, but for now it will do the same attack
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(enemyAttackDamage);
                StartCoroutine(SwitchToPlayer(betweenTurns));
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

    IEnumerator SwitchToPlayer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        currentState = CombatStates.PLAYERMOVE;
        switchState = true;
    }
}
