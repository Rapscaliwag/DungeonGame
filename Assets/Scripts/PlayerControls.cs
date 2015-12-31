using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    int damageAmount = 10;

	void Update ()
    {
        //This will allow us to test taking health away from player.
        if (Input.anyKeyDown)
            this.transform.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
	}
}
