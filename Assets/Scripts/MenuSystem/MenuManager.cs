using System;
using System.Collections.Generic;
using UnityEngine;

namespace MenuSystem
{
    [Serializable]
    public class TypeData
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite avatarSprite;
        [SerializeField] private ItemDataSO[] itemsDataSO;
    
        public string Name => name;
        public Sprite AvatarSprite => avatarSprite;
        public ItemDataSO[] ItemsDataSO => itemsDataSO;
    }

    public class MenuManager : MonoBehaviour
    {
        public static MenuManager Instance { get; private set; }
    
        [SerializeField] private TypeData[] itemsDataSO;

        public TypeData[] ItemsDataSO => itemsDataSO;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
        
            Instance = this;
        }
    }
}