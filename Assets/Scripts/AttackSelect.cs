using UnityEngine;
using System.Collections;

public class AttackSelect : MonoBehaviour
{
    public void ChosenAttack (int theSelectedAttack)
    {
        this.transform.GetComponent<CombatState>().attackHasBeenChosen = true;
        this.transform.GetComponent<CombatState>().theAttackSelected = theSelectedAttack;
    }
}
