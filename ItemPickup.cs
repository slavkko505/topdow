using UnityEngine;

public class ItemPickup : Interaction
{
	 public Item item;
	 public override void Interact()
	 {
		 base.Interact();

		 PickUp();
	 }

	 void PickUp()
	 {
		 Debug.Log("Picking up " + item.name);

		 bool wasAdd = Inventory.instance.AddItem(item);
		 
		//add to inventory
		 if(wasAdd){
			 Destroy(gameObject);
		 }
	 }
}
