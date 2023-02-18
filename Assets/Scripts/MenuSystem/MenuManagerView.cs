using SelectionSystem;
using UnityEngine;

namespace MenuSystem
{
    public class MenuManagerView : MonoBehaviour
    {
        [Header("UI")] 
        [SerializeField] private GameObject menuManagerUI;
        [SerializeField] private TypeView typeViewPrefab;
        [SerializeField] private Transform layout;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            foreach (var typeData in MenuManager.Instance.ItemsDataSO)
            {
                CreateTypeView(typeData);
            }
        }

        private void CreateTypeView(TypeData typeData)
        {
            TypeView newType = Instantiate(typeViewPrefab, layout);

            newType.AvatarImage.sprite = typeData.AvatarSprite;
            newType.TypeNameText.text = typeData.Name;
            
            newType.UseButton.onClick.AddListener(delegate
            {
                SelectionManager.Instance.Initialize(typeData.ItemsDataSO);
                menuManagerUI.SetActive(false);
            });
        }
    }
}
