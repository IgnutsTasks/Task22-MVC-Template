using System;
using System.Collections.Generic;
using UnityEngine;

namespace SelectionSystem
{
    public class SelectionManager : MonoBehaviour
    {
        public static SelectionManager Instance { get; private set; }
        
        private ItemDataSO[] _currentItemsData;

        public delegate void ChangeItemsData(ItemDataSO[] itemsData);
        public event ChangeItemsData OnChangeItemsData;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void Initialize(ItemDataSO[] itemsDataSO)
        {
            _currentItemsData = itemsDataSO;
            OnChangeItemsData?.Invoke(itemsDataSO);
        }
    }
}