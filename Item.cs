using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
	
	new public string name= "new item";
	public Sprite icon = null;
	public bool isDedaultItem = false;

	public virtual void Use()
	{
		Debug.Log("Using "+ name);
	}

	public void RemoveFromInventory()
	{
		Inventory.instance.RemoveItem(this);
	}
}

