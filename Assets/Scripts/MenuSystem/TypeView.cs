using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MenuSystem
{
    public class TypeView : MonoBehaviour
    {
        [SerializeField] private Image avatarImage;
        [SerializeField] private Button useButton;
        [SerializeField] private TextMeshProUGUI typeNameText;

        public Image AvatarImage => avatarImage;
        public Button UseButton => useButton;
        public TextMeshProUGUI TypeNameText => typeNameText;
    }
}
