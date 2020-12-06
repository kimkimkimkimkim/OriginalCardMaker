using System.Collections;
using System.Collections.Generic;
using GameBase;
using UnityEngine;
using UnityEngine.UI;

[ResourcePath("UI/Parts/Parts-CardItem")]
public class CardItem : MonoBehaviour
{
    [SerializeField] protected Sprite[] _frameSpriteList;
    [SerializeField] protected Sprite[] _attributeSpriteList;
    [SerializeField] protected Image _frameImage;
    [SerializeField] protected Image _attributeImage;

    private CardInfo card = new CardInfo();

    public void SetCardInfo(CardInfo card)
    {
        this.card = card;
    }

    public CardInfo GetCardInfo()
    {
        return card;
    }

    public void UpdateAllUI()
    {
        UpdateFrameUI();
        UpdateAttributeUI();
    }

    public void UpdateFrameInfo(Frame frame)
    {
        card.frame = frame;
    }

    public void UpdateFrameUI() {
        _frameImage.sprite = _frameSpriteList[(int)card.frame];
    }

    public void UpdateAttributeInfo(MonsterAttribute attribute)
    {
        card.attribute = attribute;
    }

    public void UpdateAttributeUI()
    {
        _attributeImage.sprite = _attributeSpriteList[(int)card.attribute];
    }
}
