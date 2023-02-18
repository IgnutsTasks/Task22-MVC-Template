using System;
using System.Collections.Generic;
using CartSystem;
using UnityEngine;

namespace SelectionSystem
{
    public class SelectionManagerView : MonoBehaviour
    {
        [Header("UI")] 
        [SerializeField] private GameObject selectionManagerUI;
        [SerializeField] private ItemView itemViewPrefab;
        [SerializeField] private Transform layout;
        
        private readonly List<ItemView> _createdItemsView = new List<ItemView>();

        private void Start()
        {
            SelectionManager.Instance.OnChangeItemsData += data =>
            {
                Initialize(data);   
                selectionManagerUI.SetActive(true);
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
                CartManager.Instance.AddItemDataSO(itemDataSO);
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