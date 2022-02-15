using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
   private Inventory inventory;
   public Transform ParentsItems;

   public GameObject inventoryUI;

   private InventorySlot[] slots;
   private void Start()
   {
       inventory = Inventory.instance;
       inventory.onItemChangeCallBack += UpdateUI;

       slots = ParentsItems.GetComponentsInChildren<InventorySlot>();

   }

   private void Update()
   {
       if (Input.GetButtonDown("Inventory"))
       {
           inventoryUI.SetActive(!inventoryUI.activeSelf);
       }
   }

   private void UpdateUI()
   {
       for (int i = 0; i < slots.Length; i++)
       {
           if (i < inventory.listItems.Count)
           {
               slots[i].AddItem(inventory.listItems[i]);
           }
           else
           {
               slots[i].ClearItem();
           }
           
       }
   }
}
