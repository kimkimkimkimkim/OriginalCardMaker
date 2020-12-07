using System;
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
    [SerializeField] protected Image[] _linkPositionImageList;
    [SerializeField] protected GameObject _statusBase;
    [SerializeField] protected GameObject _linkStatusBase;
    [SerializeField] protected GameObject _linkPositionBase;
    [SerializeField] protected GameObject _pendulumBase;
    [SerializeField] protected GameObject _monsterDescriptionTextBase;
    [SerializeField] protected GameObject _descriptionTextBaseBottom;
    [SerializeField] protected Image _frameImage;
    [SerializeField] protected Image _attributeImage;
    [SerializeField] protected Image _levelImage;
    [SerializeField] protected Text _nameText;
    [SerializeField] protected Text _attackText;

    private CardInfo card = new CardInfo();

    public void SetCardInfo(CardInfo card)
    {
        this.card = card;
    }

    public CardInfo GetCardInfo()
    {
        return card;
    }

    public void UpdateUI()
    {

    }

    /// <summary>
    /// Frameに応じて、UIのactiveを切り替える
    /// </summary>
    private void ActivateUI(Frame frame)
    {
        switch (frame)
        {
            case Frame.NormalMonster:
            case Frame.EffectMonster:
            case Frame.RitualMonster:
            case Frame.FusionMonster:
            case Frame.SynchroMonster:
            case Frame.XyzMonster:
            case Frame.TokenOptional:
                _frameImage.gameObject.SetActive(true);
                _nameText.gameObject.SetActive(true);
                _attributeImage.gameObject.SetActive(true);
                _levelImage.gameObject.SetActive(true);
                _statusBase.SetActive(true);
                _linkStatusBase.SetActive(false);
                _linkPositionBase.SetActive(false);
                _pendulumBase.SetActive(false);
                _monsterDescriptionTextBase.SetActive(true);
                _descriptionTextBaseBottom.SetActive(true);
                break;

            case Frame.PendulumNormalMonster:
            case Frame.PendulumEffectMonster:
            case Frame.PendulumRitualMonster:
            case Frame.PendulumFusionMonster:
            case Frame.PendulumSynchroMonster:
            case Frame.PendulumXyzMonster:
                _frameImage.gameObject.SetActive(true);
                _nameText.gameObject.SetActive(true);
                _attributeImage.gameObject.SetActive(true);
                _levelImage.gameObject.SetActive(true);
                _statusBase.SetActive(true);
                _linkStatusBase.SetActive(false);
                _linkPositionBase.SetActive(false);
                _pendulumBase.SetActive(true);
                _monsterDescriptionTextBase.SetActive(true);
                _descriptionTextBaseBottom.SetActive(true);
                break;

            case Frame.LinkMonster:
                _frameImage.gameObject.SetActive(true);
                _nameText.gameObject.SetActive(true);
                _attributeImage.gameObject.SetActive(true);
                _levelImage.gameObject.SetActive(false);
                _statusBase.SetActive(false);
                _linkStatusBase.SetActive(true);
                _linkPositionBase.SetActive(true);
                _pendulumBase.SetActive(false);
                _monsterDescriptionTextBase.SetActive(true);
                _descriptionTextBaseBottom.SetActive(true);
                break;


            case Frame.NormalSpell:
            case Frame.QuickPlaySpell:
            case Frame.ContinuousSpell:
            case Frame.EquipSpell:
            case Frame.RitualSpell:
            case Frame.FieldSpell:
            case Frame.NormalTrap:
            case Frame.ContinuousTrap:
            case Frame.CounterTrap:
                _frameImage.gameObject.SetActive(true);
                _nameText.gameObject.SetActive(true);
                _attributeImage.gameObject.SetActive(false);
                _levelImage.gameObject.SetActive(false);
                _statusBase.SetActive(false);
                _linkStatusBase.SetActive(false);
                _linkPositionBase.SetActive(false);
                _pendulumBase.SetActive(false);
                _monsterDescriptionTextBase.SetActive(false);
                _descriptionTextBaseBottom.SetActive(false);
                break;

            case Frame.Token:
                _frameImage.gameObject.SetActive(true);
                _nameText.gameObject.SetActive(true);
                _attributeImage.gameObject.SetActive(true);
                _levelImage.gameObject.SetActive(false);
                _statusBase.SetActive(false);
                _linkStatusBase.SetActive(false);
                _linkPositionBase.SetActive(false);
                _pendulumBase.SetActive(false);
                _monsterDescriptionTextBase.SetActive(false);
                _descriptionTextBaseBottom.SetActive(false);
                break;
        }
    }

    public void UpdateAllUI()
    {
        UpdateFrameUI();
        UpdateNameUI();
        UpdateNameColorUI();
        UpdateNameSizeUI();
        UpdateAttributeUI();
        UpdateLevelUI();
        UpdateLinkPositionUI();
    }

    #region Frame
    public void UpdateFrameInfo(Frame frame)
    {
        card.frame = frame;
    }

    public void UpdateFrameUI() {
        ActivateUI(card.frame);

        _frameImage.sprite = _frameSpriteList[(int)card.frame];
        UpdateLevelUI();
    }
    #endregion Frame

    #region Name
    public void UpdateNameInfo(string name)
    {
        card.name = name;
    }

    public void UpdateNameUI()
    {
        _nameText.text = card.name;
    }
    #endregion Name

    #region Attribute
    public void UpdateAttributeInfo(MonsterAttribute attribute)
    {
        card.attribute = attribute;
    }

    public void UpdateAttributeUI()
    {
        _attributeImage.sprite = _attributeSpriteList[(int)card.attribute];
    }
    #endregion Attribute

    #region Level
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
    #endregion Level

    #region LinkPosition
    public void ToggleLinkPositionInfo(LinkPosition linkPosition)
    {
        card.ToggleLinkPosition(linkPosition);
    }

    public void UpdateLinkPositionUI()
    {
        foreach(LinkPosition linkPosition in Enum.GetValues(typeof(LinkPosition)))
        {
            var index = (int)linkPosition;
            var isSelected = card.IsSelectedLinkPosition(linkPosition);
            _linkPositionImageList[index].gameObject.SetActive(isSelected);
        }
    }
    #endregion LinkPosition

    #region NameColor
    public void UpdateNameColorInfo(NameColor nameColor)
    {
        card.nameColor = nameColor;
    }

    public void UpdateNameColorUI()
    {
        _nameText.color = GetColor(card.nameColor);
    }

    private Color GetColor(NameColor nameColor)
    {
        switch (nameColor)
        {
            case NameColor.Black:
                return new Color(0.0f, 0.0f, 0.0f);
            case NameColor.White:
                return new Color(0.95f, 0.95f, 0.95f);
            case NameColor.Shilver:
                return new Color(0.77f, 0.77f, 0.77f);
            case NameColor.Gold:
                return new Color(0.77f, 0.77f, 0.0f);
            case NameColor.Red:
                return new Color(0.77f, 0.05f, 0.05f);
            default:
                return new Color(0.0f, 0.0f, 0.0f);
        }
    }
    #endregion NameColor

    #region NameSize
    public void UpdateNameSizeInfo(NameSize nameSize)
    {
        card.nameSize= nameSize;
    }

    public void UpdateNameSizeUI()
    {
        _nameText.fontSize = GetSize(card.nameSize);
    }

    private int GetSize(NameSize nameSize)
    {
        switch (nameSize)
        {
            case NameSize.Medium:
                return 70;
            case NameSize.Small:
                return 50;
            default:
                return 70;
        }
    }
    #endregion NameSize

    #region Attack
    public void UpdateAttackInfo(string attack)
    {
        card.attack = attack;
    }

    public void UpdateAttackUI()
    {
        _attackText.text = card.attack;
    }
    #endregion Attack
}
