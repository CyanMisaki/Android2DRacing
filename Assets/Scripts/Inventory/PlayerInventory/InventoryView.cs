using System;
using System.Collections.Generic;
using Inventory.Items;
using UnityEngine;

namespace Inventory.PlayerInventory
{
    public class InventoryView : IInventoryView
    {
        public void Display(IReadOnlyList<IItem> items)
        {
            foreach (var item in items)
            {
                //TODO VISUAL
                Debug.Log($"Item ID: {item.ID}. Item Name: {item.Info.Title}");
            }
        }
    }
}