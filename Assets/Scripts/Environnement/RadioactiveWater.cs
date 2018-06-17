using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveWater : MonoBehaviour {

    public float radioActivityPower;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.GetComponent<CharacterController>().inRadioActivity(radioActivityPower);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.GetComponent<CharacterController>().inRadioActivity(0f);
        }
    }

}
