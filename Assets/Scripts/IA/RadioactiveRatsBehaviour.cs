using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveRatsBehaviour : MonoBehaviour {

    public int numberOfRats;

    float initRadius;

	void Start () {
        Transform rat = transform.GetChild(0);
        for (int i = 1; i < numberOfRats; i++)
        {
            Instantiate(rat, rat.position, Quaternion.identity, transform);
        }
        initRadius = GetComponentInChildren<RadioactivityZone>().getZoneRadius();
	}

    private void Update()
    {
        float state = GetComponentInChildren<RadioactivityZone>().getZoneRadius() / initRadius;
        foreach(RandomMovementAroundObject movement in GetComponentsInChildren<RandomMovementAroundObject>())
        {
            movement.setMovementRangeCoef(state);
        }

        if (GetComponentInChildren<RadioactivityZone>().getZoneRadius() <= 0.2f)
        {
            Destroy(GetComponentInChildren<RadioactivityZone>().gameObject);
            foreach (RandomMovementAroundObject movement in GetComponentsInChildren<RandomMovementAroundObject>())
            {
                movement.setMovementRangeCoef(100f);
            }
        }
    }
}
