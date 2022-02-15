using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int damage = 20;
    
    public int maxHP;
    public int currentHP;

    public HealthBar healthBar;

    public static PlayerHealth instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        int count = FindObjectsOfType<PlayerHealth>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        currentHP = maxHP;
        if(healthBar != null)
            healthBar.SetMaxHealth(maxHP);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(damage);
        }
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
		
        if(healthBar != null)
            healthBar.SetHealth(currentHP);

        if (currentHP <= 0)
            return true;
        else
            return false;
		
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
		
        if(healthBar != null)
            healthBar.SetHealth(currentHP);
    }
}
