using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
	 public float radius= 3.5f;
	
	 public Transform InteractibleTransform;

	Transform player;
	bool isFocus = false;
	bool hasInteracteble = false;

	public virtual void Interact(){
		//metod to overwritten
		Debug.Log("Interacteble with  " + transform.name);
	}

	private void Update() {
		if(isFocus && !hasInteracteble){
			float distance = Vector3.Distance(InteractibleTransform.position, player.position);
			if(distance <= radius){
				Interact();
				hasInteracteble = true;
			}
		}
	}

	public void OnFocus(Transform newPlayer){
		player = newPlayer;
		isFocus = true;
		hasInteracteble = false;
	}

	public void OnDefocus()
	{
		player = null;
		isFocus = false;
		hasInteracteble = false;
	}
	 
    private void OnDrawGizmosSelected() {
		 if(InteractibleTransform == null){
			InteractibleTransform = transform;
		 }
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(InteractibleTransform.position, radius);
	 }
}
