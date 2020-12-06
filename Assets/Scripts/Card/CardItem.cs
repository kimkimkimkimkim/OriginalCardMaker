using System.Collections;
using System.Collections.Generic;
using GameBase;
using UnityEngine;
using UnityEngine.UI;

[ResourcePath("UI/Parts/Parts-CardItem")]
public class CardItem : MonoBehaviour
{
    [SerializeField] protected Sprite[] _frameSpriteList;
    [SerializeField] protected Image _frameImage;

    private CardInfo card;

    public void SetCardInfo(CardInfo card)
    {
        this.card = card;
    }

    public void UpdateFrameInfo(Frame frame)
    {
        card.frame = frame;
    }

    public void UpdateFrameUI() {
        _frameImage.sprite = _frameSpriteList[(int)card.frame];
    }
}
