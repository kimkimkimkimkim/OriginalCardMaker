using System;
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
    [SerializeField] protected Sprite[] _linkNumSpriteList;
    [SerializeField] protected RawImage _rawImage;
    [SerializeField] protected RawImage _xyzRawImage;
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
    [SerializeField] protected Text _linkAttackText;
    [SerializeField] protected Text _defenceText;
    [SerializeField] protected Text _monsterDescriptionText;
    [SerializeField] protected Text _descriptionText;
    [SerializeField] protected Text _pendulumText;
    [SerializeField] protected Text _pendulumNumBlueText;
    [SerializeField] protected Text _pendulumNumRedText;
    [SerializeField] protected Image _linkNumImage;

    private CardInfo card = new CardInfo();

    public void SetCardInfo(CardInfo card)
    {
        this.card = card;
    }

    public CardInfo GetCardInfo()
    {
        return card;
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
            case Frame.TokenOptional:
            case Frame.XyzMonster:
                _rawImage.gameObject.SetActive(true);
                _xyzRawImage.gameObject.SetActive(false);
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
                _rawImage.gameObject.SetActive(false);
                _xyzRawImage.gameObject.SetActive(true);
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
                _rawImage.gameObject.SetActive(true);
                _xyzRawImage.gameObject.SetActive(false);
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
                _rawImage.gameObject.SetActive(true);
                _xyzRawImage.gameObject.SetActive(false);
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
                _rawImage.gameObject.SetActive(true);
                _xyzRawImage.gameObject.SetActive(false);
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
        UpdateAttackUI();
        UpdateDefenceUI();
        UpdateMonsterTextUI();
        UpdateTextUI();
        UpdateTextSizeUI();
        UpdatePendulumTextUI();
        UpdatePendulumTextSizeUI();
        UpdatePendulumNumBlueUI();
        UpdatePendulumNumRedUI();
        UpdateLinkNumUI();
    }

    #region RawImage
    public void UpdateRawImage(Texture texture)
    {
        _rawImage.texture = texture;
    }
    #endregion RawImage

    #region XyzRawImage
    public void UpdateXyzRawImage(Texture texture)
    {
        _xyzRawImage.texture = texture;
    }
    #endregion XyzRawImage

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
        _nameText.color = CardUtil.GetColor(card.nameColor);
    }
    #endregion NameColor

    #region NameSize
    public void UpdateNameSizeInfo(NameSize nameSize)
    {
        card.nameSize= nameSize;
    }

    public void UpdateNameSizeUI()
    {
        _nameText.fontSize = CardUtil.GetSize(card.nameSize);
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
        _linkAttackText.text = card.attack;
    }
    #endregion Attack

    #region Defence
    public void UpdateDefenceInfo(string defence)
    {
        card.defence = defence;
    }

    public void UpdateDefenceUI()
    {
        _defenceText.text = card.defence;
    }
    #endregion Defence

    #region MonsterText
    public void UpdateMonsterTextInfo(string monsterText)
    {
        card.monsterText = monsterText;
    }

    public void UpdateMonsterTextUI()
    {
        _monsterDescriptionTextBase.SetActive(!String.IsNullOrEmpty(card.monsterText));
        _monsterDescriptionText.text = card.monsterText;
    }
    #endregion MonsterText

    #region Text
    public void UpdateTextInfo(string text) {
        card.text = text;
    }

    public void UpdateTextUI() 
    {
        _descriptionText.text = card.text;
    }
    #endregion Text

    #region TextSize
    public void UpdateTextSizeInfo(TextSize textSize)
    {
        card.textSize = textSize;
    }

    public void UpdateTextSizeUI()
    {
        _descriptionText.fontSize = CardUtil.GetSize(card.textSize);
    }
    #endregion TextSize

    #region PendulumText
    public void UpdatePendulumTextInfo(string pendulumText)
    {
        card.pendulumText = pendulumText;
    }

    public void UpdatePendulumTextUI() 
    {
        _pendulumText.text = card.pendulumText;
    }
    #endregion PendulumText

    #region PendulumTextSize
    public void UpdatePendulumTextSizeInfo(PendulumTextSize pendulumTextSize) {
        card.pendulumTextSize = pendulumTextSize;
    }

    public void UpdatePendulumTextSizeUI() {
        _pendulumText.fontSize = CardUtil.GetSize(card.pendulumTextSize);
    }
    #endregion PendulumTextSize

    #region PendulumNumBlue
    public void UpdatePendulumNumBlueInfo(PendulumNumBlue pendulumNumBlue) {
        card.pendulumNumBlue = pendulumNumBlue;
    }

    public void UpdatePendulumNumBlueUI()
    {
        _pendulumNumBlueText.text = ((int)card.pendulumNumBlue).ToString();
    }
    #endregion PendulumNumBlue

    #region PendulumNumRed
    public void UpdatePendulumNumRedInfo(PendulumNumRed pendulumNumRed)
    {
        card.pendulumNumRed = pendulumNumRed;
    }

    public void UpdatePendulumNumRedUI()
    {
        _pendulumNumRedText.text = ((int)card.pendulumNumRed).ToString();
    }
    #endregion PendulumNumRed

    #region LinkNum
    public void UpdateLinkNumInfo(LinkNum linkNum)
    {
        card.linkNum = linkNum;
    }

    public void UpdateLinkNumUI() {
        _linkNumImage.sprite = _linkNumSpriteList[(int)card.linkNum];
    }
    #endregion
}
