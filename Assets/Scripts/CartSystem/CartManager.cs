using System;
using System.Collections.Generic;
using SelectionSystem;
using UnityEngine;

namespace CartSystem
{
    public class CartManager : MonoBehaviour
    {
        public static CartManager Instance { get; private set; }
        
        private readonly List<ItemDataSO> _itemsDataSO = new List<ItemDataSO>();

        public delegate void ChangeItemsData(ItemDataSO[] itemsDataSO);
        public event ChangeItemsData OnChangeItemData;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void AddItemDataSO(ItemDataSO itemDataSO)
        {
            _itemsDataSO.Add(Instantiate(itemDataSO));
            
            OnChangeItemData?.Invoke(_itemsDataSO.ToArray());
        }

        public void RemoveItemDataSO(ItemDataSO itemDataSO)
        {
            _itemsDataSO.Remove(itemDataSO);
            
            OnChangeItemData?.Invoke(_itemsDataSO.ToArray());
        }
    }
}