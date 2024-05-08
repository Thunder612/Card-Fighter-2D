using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Deck deck;
    public CardDatabase cardDatabase;
    int selectedCard = 0;
    double health = 3;
    public Text healthCounter;
    private string healthCounterText;
    public Timer timer;
    private float startTime;
    private bool attacking = false;
    private float SwingTime;
    private Collider2D collid;
    public Card lastUsedCard;
    public Collider2D healReminder;
    public AudioManager audioManager;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        //cardDatabase.loadCards();
        deck.loadStarterDeck();
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        healthCounterText = "Your Life:";
        for (double i = .95; i < health; i++)
        {
            healthCounterText += " <3";
        }
        healthCounter.text = healthCounterText;
    }

    // Update is called once per frame, used for controller input
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (rb.position.x < -960 && movement.x < 0) //Ensures the player cannot leave the bounds of the game
        {
            movement.x = 0;
        }

        if (rb.position.x > 960 && movement.x > 0)
        {
            movement.x = 0;
        }

        if (rb.position.y < -540 && movement.y < 0)
        {
            movement.y = 0;
        }

        if (rb.position.y > 540 && movement.y > 0)
        {
            movement.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.E) && !attacking)
        {
            Attack();
        }

        

        if (attacking && (startTime + SwingTime < timer.timer))
        {
            attacking = false;
            collid.transform.gameObject.SetActive(false);
        }
    }

    //Used for movement
    private void FixedUpdate()
    {

        


        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        
    }

    private void Attack ()
    {
        lastUsedCard = deck.deck[selectedCard];
        deck.deck[selectedCard].execute();
        selectedCard++;
        if (selectedCard >= deck.deckSize)
        {
            deck.shuffle();
            selectedCard = 0;
        }
        deck.displayCard(deck.deck[selectedCard]);
    }

    public void takeDamage(double damage)
    {
        if (damage > 0)
        {

            audioManager.OuchSFX();
        }
        health -= damage;
        UpdateHealth();
        if (health <= .95)
        {
            GameOver();
        }
    }

    private void GameOver() 
    { 
        gameObject.SetActive(false);
        audioManager.GameOverSFX();
    }

    public void handleSprite(Collider2D Collid, float swingTime)
    {
        attacking = true;
        startTime = timer.timer;
        SwingTime = swingTime;
        collid = Collid;
    }

}
