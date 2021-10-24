using System.Linq;
using Inventory.Items;
using Inventory.PlayerInventory;

namespace Abilities
{
    public class AbilityController : BaseController
    {
        private readonly IInventoryModel _inventory;
        private readonly IAbilityRepository _abilityRepository;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;

        public AbilityController(IInventoryModel inventory, IAbilityRepository abilityRepository, IAbilityCollectionView abilityCollectionView, IAbilityActivator abilityActivator)
        {
            _inventory = inventory;
            _abilityRepository = abilityRepository;
            _abilityCollectionView = abilityCollectionView;
            _abilityActivator = abilityActivator;

            var equipped =inventory.GetEquippedItems();
            var equippedAbilities = equipped.Where(i => _abilityRepository.AbilityMapById.ContainsKey(i.ID));
            abilityCollectionView.Display(equippedAbilities.ToList());
            abilityCollectionView.UseRequested += ViewOnUseRequested;
        }

        private void ViewOnUseRequested(object sender, IItem e)
        {
            var ability = _abilityRepository.AbilityMapById[e.ID];
            ability.Apply(_abilityActivator);
        }
    }
}