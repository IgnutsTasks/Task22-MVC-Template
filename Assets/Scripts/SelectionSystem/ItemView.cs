using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SelectionSystem
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private ItemDataSO itemDataSO;
        [SerializeField] private Image avatarImage;
        [SerializeField] private Button useButton;
        
        public Image AvatarImage => avatarImage;
        public Button UseButton => useButton;
    }
}