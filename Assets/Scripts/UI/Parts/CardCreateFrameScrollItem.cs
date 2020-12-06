using GameBase;
using UnityEngine;

[ResourcePath("UI/Parts/Parts-CardCreateFrame")]
public class CardCreateFrameScrollItem : ScrollItem
{
    [SerializeField] protected Sprite _unselectedSprite;
    [SerializeField] protected Sprite _selectedSprite;

    public void SetImage(bool isSelected)
    {
        var sprite = isSelected ? _selectedSprite : _unselectedSprite;
        image.sprite = sprite;
    }
}
