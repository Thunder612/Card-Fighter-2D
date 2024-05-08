using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int id;
    public string cardName;
    public int damage;
    public Collider2D collid;
    public Sprite spriteImage;
    public float swingTime;
    private PlayerController player;
    private AudioManager audioManager;
    
    public Card()
    {

    }

    public Card(int Id, string CardName, int Damage, Collider2D Collider, Sprite SpriteImage, float Swingtime)
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        id = Id;
        cardName = CardName;
        damage = Damage;
        collid = Collider;
        spriteImage = SpriteImage;
        swingTime = Swingtime;

        
    }

    public void execute()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        player.handleSprite(collid, swingTime);
        
        //Debug.Log(this.cardName);
        switch (id)
        {
            case 0:
                genericStab(); //Attack404
                break;
            case 1:
                genericStab(); //UpStab
                break;
            case 2:
                genericStab(); //DownStab
                break;
            case 3:
                genericStab(); //LeftStab
                break;
            case 4:
                genericStab(); //RightStab
                break;
            case 5:
                genericStab(); //CircleSlash
                break;
            case 6:
                genericStab(); //DamageRightStab
                break;
            case 7:
                genericStab(); //QuickLeftStab
                break;
            case 8:
                genericStab(); //TallUpStab
                break;
            case 9:
                genericStab(); //WideDownStab
                break;
            case 10:
                oneTenthHeal(); //Heal
                break;
            case 11:
                hyperBeam(); //Hyper Beam
                break;
            case 12:
                genericStab(); //Poison Needle
                break;
            case 13:
                genericStab(); //Instant Poke
                break;

        }
        
        

        //return true;
    }

    
    

    

    private void dealDamage(Collider2D col)
    {
        GameObject.Find("GameController").GetComponent<GameController>().score += damage;
        Debug.Log(col.name);
        try
        {

            col.GetComponentInParent<Enemy>().takeDamage(damage);
        } catch (System.Exception e)
        {

        }
        try
        {

            col.GetComponentInParent<HexagonEnemy>().takeDamage(damage);
        }
        catch (System.Exception e)
        {

        }
        try
        {

            col.GetComponentInParent<DiamondEnemy>().takeDamage(damage);
        }
        catch (System.Exception e)
        {

        }
        try
        {

            col.GetComponentInParent<CapsuleEnemy>().takeDamage(damage);
        }
        catch (System.Exception e)
        {

        }
        try
        {
            col.GetComponentInParent<CircleEnemy>().takeDamage(damage);
        }
        catch (System.Exception e)
        {

        }
        try
        {
            col.GetComponentInParent<SquareEnemy>().takeDamage(damage);
        }
        catch (System.Exception e)
        {

        }
        try
        {
            if (col.name.Contains("Slot A") || col.name.Contains("Slot B") || col.name.Contains("Slot C") || col.name.Contains("Remove Slot"))
            {
                GameObject.Find("GameController").GetComponent<GameController>().addCard(col.name);
            }
        }
        catch (System.Exception e)
        {

        }
    }

    private bool hyperBeam()
    {
        audioManager.BeamSFX();
        collid.transform.gameObject.SetActive(true);
        Collider2D[] cols = Physics2D.OverlapBoxAll(collid.bounds.center, collid.bounds.extents, 0, LayerMask.GetMask("Hitbox"));
        foreach (Collider2D col in cols)
        {
            dealDamage(col);
        }
        player.handleSprite(collid, swingTime);
        return true;
    }
    
    
    private bool genericStab()
    {
        audioManager.SwingSFX();
        collid.transform.gameObject.SetActive(true);
        Collider2D[] cols = Physics2D.OverlapBoxAll(collid.bounds.center, collid.bounds.extents, 0, LayerMask.GetMask("Hitbox"));
        foreach (Collider2D col in cols)
        {
            dealDamage(col);
        }
        player.handleSprite(collid, swingTime);
        return true;
    }

    private bool oneTenthHeal()
    {

        if(GameObject.Find("GameController").GetComponent<GameController>().winScreen.activeInHierarchy)
        {
            Collider2D healReminder = player.healReminder; //Don't heal if outside battle
            healReminder.transform.gameObject.SetActive(true);
            player.handleSprite(healReminder, swingTime);
        } else
        {
            audioManager.HealSFX();
            collid.transform.gameObject.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerController>().takeDamage(-.1);
            player.handleSprite(collid, swingTime);
        }
        return true;
    }

}
