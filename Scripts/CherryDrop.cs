using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CherryDrop : MonoBehaviour
{
    public float forceSpeed = 20f;
    public int healthPoint = 10;
    
    void Start()
    {
        transform.position += new Vector3(Random.RandomRange(-forceSpeed, forceSpeed), Random.RandomRange(-forceSpeed, forceSpeed), 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth.instance.Heal(healthPoint);
            Debug.Log("Add Health");
            Destroy(gameObject);
        }
    }
}
