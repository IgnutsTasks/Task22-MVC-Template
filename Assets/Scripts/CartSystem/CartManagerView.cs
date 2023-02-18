using System.Collections.Generic;
using SelectionSystem;
using UnityEngine;

namespace CartSystem
{
    public class CartManagerView : MonoBehaviour
    {
        [Header("UI")] 
        [SerializeField] private ItemView itemViewPrefab;
        [SerializeField] private Transform layout;
        
        private readonly List<ItemView> _createdItemsView = new List<ItemView>();
        
        private void Start()
        {
            CartManager.Instance.OnChangeItemData += data =>
            {
                Initialize(data);
            };
        }

        private void Initialize(ItemDataSO[] itemsDataSO)
        {
            CleanUp();

            foreach (var itemData in itemsDataSO)
            {
                CreateItemView(itemData);
            }
        }

        private void CreateItemView(ItemDataSO itemDataSO)
        {
            ItemView newItemView = Instantiate(itemViewPrefab, layout);

            newItemView.AvatarImage.sprite = itemDataSO.AvatarSprite;
            newItemView.UseButton.onClick.AddListener(delegate
            {
                CartManager.Instance.RemoveItemDataSO(itemDataSO);
            });
            
            _createdItemsView.Add(newItemView);
        }
        
        private void CleanUp()
        {
            foreach (var itemView in _createdItemsView)
            {
                Destroy(itemView.gameObject);
            }
            
            _createdItemsView.Clear();
        }
    }
}