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
    [SerializeField] protected Transform _inputPanelBase;

    private CardItem cardItem;

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
        CreateInputPanel();

    }

    private void CreateCardItem()
    {
        cardItem = UIManager.Instance.CreateContent<CardItem>(_cardItemBase);
        cardItem.UpdateAllUI();
    }

    private void CreateInputPanel()
    {
        // Name
        var nameInputPanel = UIManager.Instance.CreateContent<CardCreateStringInputPanel>(_inputPanelBase);
        nameInputPanel.RefreshInputPanel("カード名", text => {
            cardItem.UpdateNameInfo(text);
            cardItem.UpdateNameUI();
        });

        // NameColor
        var nameColorInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        nameColorInputPanel.RefreshPanel<NameColor>(cardItem);

        // Frame
        var frameInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        frameInputPanel.RefreshPanel<Frame>(cardItem);

        // Attribute
        var attributeInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        attributeInputPanel.RefreshPanel<MonsterAttribute>(cardItem);

        // Level
        var levelInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        levelInputPanel.RefreshPanel<MonsterLevel>(cardItem);

        // LinkPosition
        var linkPositionInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        linkPositionInputPanel.RefreshPanel<LinkPosition>(cardItem,true);
    }

    public override void Back(DialogInfo info) {
    }
    public override void Close(DialogInfo info) {
    }
    public override void Open(DialogInfo info) {
    }
}
