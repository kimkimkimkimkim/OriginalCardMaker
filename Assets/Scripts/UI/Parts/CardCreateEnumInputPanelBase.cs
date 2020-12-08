using System;
using System.Collections.Generic;
using System.Linq;
using GameBase;
using UnityEngine;
using UnityEngine.UI;

public class CardCreateEnumInputPanelBase<T> where T : Enum
{ 
    private CardItem cardItem;
    private InfiniteScroll infiniteScroll;
    private ToggleGroup toggleGroup;
    private List<T> targetList = new List<T>();
    private bool isMultipleSelection;
    private Action<T> callBackAction;

    public void RefreshPanel(CardItem cardItem,Text text,InfiniteScroll infiniteScroll,ToggleGroup toggleGroup, bool isMultipleSelection, Action<T> callBackAction)
    {
        this.cardItem = cardItem;
        this.infiniteScroll = infiniteScroll;
        this.toggleGroup = toggleGroup;
        this.targetList = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        this.isMultipleSelection = isMultipleSelection;
        this.callBackAction = callBackAction;

        text.text = TextUtil.GetDescriptionAttribute<T>();
        infiniteScroll.Clear();
        if (targetList.Count > 0) infiniteScroll.Init(targetList.Count, OnUpdateItem);
    }

    private void OnUpdateItem(int index, GameObject item)
    {
        if ((targetList.Count <= index) || (index < 0)) return;
        var scrollItem = item.GetComponent<CardCreateToggleScrollItem>();
        var cardEnum = targetList[index];

        var name = TextUtil.GetDescriptionAttribute(cardEnum);
        var card = cardItem.GetCardInfo();
        var isSelected = IsSelected(cardEnum);

        if(!isMultipleSelection)scrollItem.SetToggleGroup(toggleGroup);
        scrollItem.SetSelectionState(isSelected);
        scrollItem.SetText(name);
        scrollItem.SetOnClickAction(() =>
        {
            if (isMultipleSelection) 
            {
                scrollItem.SetSelectionState(!scrollItem.GetSelectionState());
            }
            else
            {
                scrollItem.SetSelectionState(true);
            }

            UpdateCardItem(cardEnum);
            if (callBackAction != null) callBackAction(cardEnum);
        });
    }

    private bool IsSelected(T cardEnum)
    {
        var card = cardItem.GetCardInfo();
        var value = Convert.ToInt32(cardEnum);

        if (cardEnum is Frame)
        {
            return (int)card.frame == value;
        }
        else if (cardEnum is MonsterAttribute)
        {
            return (int)card.attribute == value;
        }
        else if (cardEnum is MonsterLevel)
        {
            return (int)card.level == value;
        }
        else if(cardEnum is LinkPosition)
        {
            return card.IsSelectedLinkPosition((LinkPosition)value);
        }
        else if(cardEnum is NameColor)
        {
            return (int)card.nameColor == value;
        }
        else if(cardEnum is NameSize)
        {
            return (int)card.nameSize == value;
        }
        else if(cardEnum is TextSize)
        {
            return (int)card.textSize == value;
        }
        else if(cardEnum is PendulumTextSize) 
        {
            return (int)card.pendulumTextSize == value;
        }
        else if(cardEnum is PendulumNumBlue)
        {
            return (int)card.pendulumNumBlue == value;
        }
        else if(cardEnum is PendulumNumRed)
        {
            return (int)card.pendulumNumRed == value;
        }
        else if(cardEnum is LinkNum)
        {
            return (int)card.linkNum == value;
        }

        return false;
    }

    private void UpdateCardItem(T cardEnum)
    {
        var value = Convert.ToInt32(cardEnum);
        if (cardEnum is Frame)
        {
            cardItem.UpdateFrameInfo((Frame)value);
            cardItem.UpdateFrameUI();
        }
        else if (cardEnum is MonsterAttribute)
        {
            cardItem.UpdateAttributeInfo((MonsterAttribute)value);
            cardItem.UpdateAttributeUI();
        }
        else if (cardEnum is MonsterLevel)
        {
            cardItem.UpdateLevelInfo((MonsterLevel)value);
            cardItem.UpdateLevelUI();
        }
        else if(cardEnum is LinkPosition)
        {
            cardItem.ToggleLinkPositionInfo((LinkPosition)value);
            cardItem.UpdateLinkPositionUI();
        }
        else if(cardEnum is NameColor)
        {
            cardItem.UpdateNameColorInfo((NameColor)value);
            cardItem.UpdateNameColorUI();
        }
        else if(cardEnum is NameSize)
        {
            cardItem.UpdateNameSizeInfo((NameSize)value);
            cardItem.UpdateNameSizeUI();
        }
        else if (cardEnum is TextSize)
        {
            cardItem.UpdateTextSizeInfo((TextSize)value);
            cardItem.UpdateTextSizeUI();
        }
        else if (cardEnum is PendulumTextSize)
        {
            cardItem.UpdatePendulumTextSizeInfo((PendulumTextSize)value);
            cardItem.UpdatePendulumTextSizeUI();
        }
        else if (cardEnum is PendulumNumBlue)
        {
            cardItem.UpdatePendulumNumBlueInfo((PendulumNumBlue)value);
            cardItem.UpdatePendulumNumBlueUI();
        }
        else if (cardEnum is PendulumNumRed)
        {
            cardItem.UpdatePendulumNumRedInfo((PendulumNumRed)value);
            cardItem.UpdatePendulumNumRedUI();
        }
        else if (cardEnum is LinkNum)
        {
            cardItem.UpdateLinkNumInfo((LinkNum)value);
            cardItem.UpdateLinkNumUI();
        }
    }
}