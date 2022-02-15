using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBox : Collecton
{
    public GameObject cherry;
    public int boxCoins = 40;

    

    public override void GiveSmtToPlayer()
    {
        base.GiveSmtToPlayer();

        Instantiate(cherry, transform.position, Quaternion.identity);
        
        StorCoins.instance.GiveMoneyToPlayer(boxCoins);
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GiveSmtToPlayer();
        }
    }
}
