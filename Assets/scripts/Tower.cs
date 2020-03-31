using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform lookAt;
    [SerializeField] Transform rotator;
    [SerializeField] ParticleSystem bullets;
    const float shootRange = 10f;

    void Update()
    {
        if (lookAt != null)
        {
            rotator.LookAt(lookAt);
            distanceRange();
        }
        else
            shootOn(false);
    }

    private void distanceRange()
    {
        
            float distance = Vector3.Distance(rotator.position, lookAt.position);
            if (distance <= shootRange && lookAt != null)
                shootOn(true);
            else
                shootOn(false);
    }

    private void shootOn(bool isActive)
    {
        var emissions = bullets.emission;
        emissions.enabled = isActive;
    }
}
