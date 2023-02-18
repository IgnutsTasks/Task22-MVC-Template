using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "ItemData", menuName = "ScriptableObject/ItemData")]
public class ItemDataSO : ScriptableObject
{
    [SerializeField] private Sprite avatarSprite;

    public Sprite AvatarSprite => avatarSprite;
}
