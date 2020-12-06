using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

[ResourcePath("UI/Dialog/Dialog-CardCreate")]
public class CardCreateDialogUIScript : DialogBase {

    [SerializeField] protected Button _closeButton;
    [SerializeField] protected Transform _cardItemBase;
    [SerializeField] protected InfiniteScroll _frameInfiniteScroll;
    [SerializeField] protected ToggleGroup _frameToggleGroup;
    [SerializeField] protected InfiniteScroll _attributeInfiniteScroll;
    [SerializeField] protected ToggleGroup _attributeToggleGroup;

    private CardItem cardItem;
    private List<Frame> targetFrameList = Enum.GetValues(typeof(Frame)).Cast<Frame>().ToList();
    private List<MonsterAttribute> targetAttributeList = Enum.GetValues(typeof(MonsterAttribute)).Cast<MonsterAttribute>().ToList();

    public override void Init(DialogInfo info) {
        var onClickClose = (Action)info.param["onClickClose"];

        _closeButton.OnClickAsObservable()
            .SelectMany(_ => UIManager.Instance.CloseDialogObservable())
            .Do(_ => {
                if (onClickClose != null)
                {
                    onClickClose();
                    onClickClose = null;
                }
            })
            .Subscribe();

        CreateCardItem();
        SetInputScrollView();
    }

    private void CreateCardItem()
    {
        cardItem = UIManager.Instance.CreateContent<CardItem>(_cardItemBase);
    }

    private void SetInputScrollView()
    {
        RefreshFramePanel();
        RefreshAttributePanel();
    }

    #region Frame
    private void RefreshFramePanel() {
        _frameInfiniteScroll.Clear();
        if (targetFrameList.Count > 0) _frameInfiniteScroll.Init(targetFrameList.Count, OnUpdateFrameItem);
    }

    private void OnUpdateFrameItem(int index, GameObject item)
    {
        if ((targetFrameList.Count <= index) || (index < 0)) return;
        var scrollItem = item.GetComponent<CardCreateToggleScrollItem>();
        var frame = targetFrameList[index];

        var name = TextUtil.GetDescriptionAttribute(frame);
        var card = cardItem.GetCardInfo();
        var isSelected = card.frame == frame;

        scrollItem.SetToggleGroup(_frameToggleGroup);
        scrollItem.SetSelectionState(isSelected);
        scrollItem.SetText(name);
        scrollItem.SetOnClickAction(() =>
        {
            scrollItem.SetSelectionState(true);
            cardItem.UpdateFrameInfo(frame);
            cardItem.UpdateFrameUI();
        });
    }
    #endregion Frame

    #region Attribute
    private void RefreshAttributePanel()
    {
        _attributeInfiniteScroll.Clear();
        if (targetAttributeList.Count > 0) _attributeInfiniteScroll.Init(targetAttributeList.Count, OnUpdateAttributeItem);
    }

    private void OnUpdateAttributeItem(int index, GameObject item)
    {
        if ((targetAttributeList.Count <= index) || (index < 0)) return;
        var scrollItem = item.GetComponent<CardCreateToggleScrollItem>();
        var attribute = targetAttributeList[index];

        var name = TextUtil.GetDescriptionAttribute(attribute);
        var card = cardItem.GetCardInfo();
        var isSelected = card.attribute == attribute;

        scrollItem.SetToggleGroup(_attributeToggleGroup);
        scrollItem.SetSelectionState(isSelected);
        scrollItem.SetText(name);
        scrollItem.SetOnClickAction(() =>
        {
            scrollItem.SetSelectionState(true);
            cardItem.UpdateAttributeInfo(attribute);
            cardItem.UpdateAttributeUI();
        });
    }
    #endregion Attribute

    public override void Back(DialogInfo info) {
    }
    public override void Close(DialogInfo info) {
    }
    public override void Open(DialogInfo info) {
    }
}
