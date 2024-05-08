using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnemy : MonoBehaviour
{
    //public Collider2D enemyCollider;
    public float health;
    public Timer timer;
    private float lastTime = 0f;
    public Transform bulletSpawn;


    [SerializeField] private GameObject bullet;

    private GameObject bulletInst;
    private float bulletRot = 0f;
    public AudioClip newSong;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {

        audioManager.ChangeMusic(newSong);
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

        if (timer.timer > lastTime + .7)
        {
            lastTime = timer.timer;
            fireBullet();
        }
    }

    private void fireBullet()
    {

        //Spawn bullet
        bulletInst = Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(0f, 0f, bulletRot));
        bulletRot += 134f;
    }

    void Die()
    {
        health = 1;
        gameObject.SetActive(false);
        GameObject.Find("GameController").GetComponent<GameController>().WinScreen();

    }
}
