using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class EquipmentManager : MonoBehaviour
{
    #region Singelton

    public static EquipmentManager invoke;
    
        private void Awake()
        {
            invoke = this;
        }

    #endregion

    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChange;

    
    private Equipment[] currentEquip;

    private Inventory inventory;
    private void Start()
    {
        inventory = Inventory.instance;
        
        int indexEquip = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquip = new Equipment[indexEquip];
    }

    public void Equip(Equipment newEquip)
    {
        int slotIndex = (int)newEquip.equipSlot;

        Equipment oldItem = null;
        
        if (currentEquip[slotIndex] != null)
        {
            oldItem = currentEquip[slotIndex];
            inventory.AddItem(oldItem);
        }

        if (onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newEquip, oldItem);
        }
        currentEquip[slotIndex] = newEquip;
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquip[slotIndex] != null)
        {
            Equipment oldItem = currentEquip[slotIndex];
            inventory.AddItem(oldItem);
            
            currentEquip[slotIndex] = null;
            
            if (onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(null, oldItem);
            }
        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquip.Length; i++)
        {
            UnEquip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }
}
