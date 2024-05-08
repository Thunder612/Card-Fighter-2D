using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{

    private Collider2D proj;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f); //Destroy the bullet automagically after 15 seconds
        proj = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(proj.bounds.center, proj.bounds.extents, 0, LayerMask.GetMask("Projectile"));
        foreach (Collider2D col in cols)
        {
            Debug.Log(col.name + " takes a damage!");
            col.GetComponentInParent<PlayerController>().takeDamage(1);
            Destroy(gameObject);
        }
    }
}
