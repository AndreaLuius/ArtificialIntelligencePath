using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healt;

    public void Start()
    {
        healt = 100;
    }

    public void Update()
    {
        died();
    }

    private void OnParticleCollision(GameObject other)
    {
        damageHit();
    }

    public int  damageHit()
    {
        return healt -= 10;
    }

    private void died()
    {
        /*so theres a little diffrence
         between the this and gameobject
         because with the gameObject im saying 
         that all of em are gonna die
         with the this just the empty child*/
        if (healt <= 0)
            Destroy(gameObject);
    }
}
