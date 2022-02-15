using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
	public Transform playerBattleStation;
	public Transform enemyBattleStation;
	
	PlayerHealth playerUnit;
	public GameObject[] enemyUnits;
	private Unit enemyUnit;
	
	public Text dialogueText;

	public BattleHUDplayer playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

    void Start()
    {
	    playerUnit = FindObjectOfType<PlayerHealth>();
	    playerUnit.transform.position = playerBattleStation.transform.position + new Vector3(0f, 1f, 0f);

	    enemyUnit = Instantiate(enemyUnits[IsButtleSceneBool.GetIndexEnemy()].GetComponent<Unit>(), enemyBattleStation.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);

	    playerUnit.GetComponent<PLayerMovement>().spriteRender.flipX = false;
	    
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }
    
    
	IEnumerator SetupBattle()
	{
		IsButtleSceneBool.ChangeBatleState();
		
		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			StartCoroutine(EndBattle());
			
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
			
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			StartCoroutine(EndBattle());
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	IEnumerator EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
			
			yield return new WaitForSeconds(1f);
			
			IsButtleSceneBool.SetInedxToDestroy(IsButtleSceneBool.GetIndexEnemy());
			IsButtleSceneBool.ChangeBatleState();
			
			FindObjectOfType<PlayewrCollisions>().PlayDefaultAudio();
			FindObjectOfType<PlayewrCollisions>().LoadPosPlayer();
				
			SceneManager.LoadScene("Main");
		} 
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
			
			yield return new WaitForSeconds(1f);
			
			IsButtleSceneBool.ChangeBatleState();
			
			SceneManager.LoadScene("Main");
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}
