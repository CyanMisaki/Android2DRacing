using System;
using System.Collections.Generic;
using Inventory.Items;

namespace Abilities
{
    public interface IAbilityCollectionView
    {
        event EventHandler<IItem> UseRequested;
        
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}