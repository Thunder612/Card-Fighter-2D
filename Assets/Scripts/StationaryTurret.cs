using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StationaryTurret : MonoBehaviour
{
    public Timer timer;
    private float lastTime = 0f;
    private GameObject bulletInst;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timer > lastTime + 1.3)
        {
            lastTime = timer.timer;
            fireBullet();
        }
    }

    private void fireBullet()
    {

        //Spawn bullet
        bulletInst = Instantiate(bullet, transform.position, transform.rotation);
    }
}
