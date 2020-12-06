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
    [SerializeField] protected Sprite[] _levelSpriteList;
    [SerializeField] protected Sprite[] _rankSpriteList;
    [SerializeField] protected Image _frameImage;
    [SerializeField] protected Image _attributeImage;
    [SerializeField] protected Image _levelImage;

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
        UpdateLevelUI();
    }

    public void UpdateFrameInfo(Frame frame)
    {
        card.frame = frame;
    }

    public void UpdateFrameUI() {
        _frameImage.sprite = _frameSpriteList[(int)card.frame];

        UpdateLevelUI();
    }

    public void UpdateAttributeInfo(MonsterAttribute attribute)
    {
        card.attribute = attribute;
    }

    public void UpdateAttributeUI()
    {
        _attributeImage.sprite = _attributeSpriteList[(int)card.attribute];
    }

    public void UpdateLevelInfo(MonsterLevel level)
    {
        card.level = level;
    }

    public void UpdateLevelUI()
    {
        // エクシーズモンスターの場合はレベルではなくランクを表示
        var isXyz = card.frame == Frame.XyzMonster || card.frame == Frame.PendulumXyzMonster;
        var spriteList = isXyz ? _rankSpriteList : _levelSpriteList;

        _levelImage.sprite = spriteList[(int)card.level];
    }
}
