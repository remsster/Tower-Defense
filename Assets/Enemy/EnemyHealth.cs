using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] int maxHitPoints = 5;
    private int currentHitPoints = 0;

    private void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints -= 1;   
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
