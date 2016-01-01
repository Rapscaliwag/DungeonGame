using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackSelect : MonoBehaviour
{
    public void ChosenAttack (int theSelectedAttack)
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<CombatState>().attackHasBeenChosen = true;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<CombatState>().theAttackSelected = theSelectedAttack;
        this.gameObject.GetComponent<CombatState>().attackHasBeenChosen = true;
        this.gameObject.GetComponent<CombatState>().theAttackSelected = theSelectedAttack;
    }

    
}
