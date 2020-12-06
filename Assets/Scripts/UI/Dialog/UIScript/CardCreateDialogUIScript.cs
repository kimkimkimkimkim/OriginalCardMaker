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
        CreateInputPanel();

    }

    private void CreateCardItem()
    {
        cardItem = UIManager.Instance.CreateContent<CardItem>(_cardItemBase);
    }

    private void CreateInputPanel()
    {
        // Frame
        var frameInputPanel = UIManager.Instance.CreateContent<CardCreateInputPanel>(_inputPanelBase);
        frameInputPanel.RefreshPanel<Frame>(cardItem);

        // Attribute
        var attributeInputPanel = UIManager.Instance.CreateContent<CardCreateInputPanel>(_inputPanelBase);
        attributeInputPanel.RefreshPanel<MonsterAttribute>(cardItem);
    }

    public override void Back(DialogInfo info) {
    }
    public override void Close(DialogInfo info) {
    }
    public override void Open(DialogInfo info) {
    }
}
