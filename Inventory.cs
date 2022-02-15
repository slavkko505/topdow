using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region Singelton

	public static Inventory instance;

	 private void Awake() {
		 if(instance != null){
			 Debug.Log("More then one instance of inventory");
			 return;
		 }
		instance = this;

	}
	#endregion

	public delegate void OnItemChange();
	public OnItemChange onItemChangeCallBack; 
	
	public List<Item> listItems = new List<Item>();
	
	public int sizeList = 3;
	 public bool AddItem(Item item){
		if(!item.isDedaultItem)
		{
			if(listItems.Count >= sizeList)
			{
				Debug.Log("ListSize is full");
				return false;
			}

			listItems.Add(item);

			if(onItemChangeCallBack != null)
				onItemChangeCallBack.Invoke();
		}
		
		return true;
	 }

	 public void RemoveItem(Item item){

		listItems.Remove(item);
		if (onItemChangeCallBack != null)
			onItemChangeCallBack.Invoke();
	 }
	
}
