using System;
using GameBase;
using UnityEngine;
using UnityEngine.UI;

[ResourcePath("UI/Parts/Parts-CardCreateInputPanel")]
public class CardCreateInputPanel : MonoBehaviour
{
    [SerializeField] protected Text _titleText;
    [SerializeField] protected InfiniteScroll _infiniteScroll;
    [SerializeField] protected ToggleGroup _toggleGroup;

    public void RefreshPanel<T>(CardItem cardItem) where T : Enum
    {
        var cardCreateInputPanelBase = new CardCreateInputPanelBase<T>();
        cardCreateInputPanelBase.RefreshPanel(cardItem,_titleText,_infiniteScroll,_toggleGroup);
    }
}
