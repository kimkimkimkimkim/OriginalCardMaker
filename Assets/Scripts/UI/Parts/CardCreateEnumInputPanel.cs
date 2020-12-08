using System;
using GameBase;
using UnityEngine;
using UnityEngine.UI;

[ResourcePath("UI/Parts/Parts-CardCreateEnumInputPanel")]
public class CardCreateEnumInputPanel : MonoBehaviour
{
    [SerializeField] protected Text _titleText;
    [SerializeField] protected InfiniteScroll _infiniteScroll;
    [SerializeField] protected ToggleGroup _toggleGroup;

    public void RefreshPanel<T>(CardItem cardItem, bool isMultipleSelection = false,Action<T> callBackAction = null) where T : Enum
    {
        var cardCreateInputPanelBase = new CardCreateEnumInputPanelBase<T>();
        cardCreateInputPanelBase.RefreshPanel(cardItem,_titleText,_infiniteScroll,_toggleGroup,isMultipleSelection,callBackAction);
    }
}
