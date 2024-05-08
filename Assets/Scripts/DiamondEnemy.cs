using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondEnemy : MonoBehaviour
{
    public Collider2D enemyCollider;
    public float health;
    public GameObject winScreen;
    public Timer timer;
    private float lastTime = 0f;
    public Transform bulletSpawn;
    public AudioClip newSong;
    public AudioManager audioManager;


    [SerializeField] private GameObject bullet;

    private GameObject bulletInst;
    private float bulletRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void spawn(float startingHealth)
    {
        health = startingHealth;
        audioManager.ChangeMusic(newSong);
    }

    public void takeDamage(int amount)
    {
        Debug.Log("Taking " + amount + " damage");
        health -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        /*
        if (timer.timer > lastTime + 1)
        {
            lastTime = timer.timer;
            fireBullet();
        }
        */
    }

    private void fireBullet()
    {

        //Spawn bullet
        bulletInst = Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(0f, 0f, bulletRot));
        bulletRot += 30f;
    }

    void Die()
    {
        health = 1;
        gameObject.SetActive(false);
        GameObject.Find("GameController").GetComponent<GameController>().WinScreen();

    }
}
