using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collecton
{
    public Transform parentChest;
    
    public static Chest instance;
    public GameObject openChest;
    public int CoinsInChest = 20;
    
    public DontDestroyChest _dontDestroyChest;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public override void GiveSmtToPlayer()
    {
        base.GiveSmtToPlayer();

        StorCoins.instance.GiveMoneyToPlayer(CoinsInChest);
        var newChest = Instantiate(openChest, transform.position, Quaternion.identity);
        newChest.transform.parent = parentChest.transform;
        _dontDestroyChest._childsChest.Add(newChest);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GiveSmtToPlayer();
        }
    }

    public int GetCoinsInChest()
    {
        return CoinsInChest;
    }
}
