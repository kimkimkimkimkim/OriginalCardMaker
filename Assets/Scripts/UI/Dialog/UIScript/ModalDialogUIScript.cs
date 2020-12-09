using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

[ResourcePath("UI/Dialog/Dialog-Modal")]
public class ModalDialogUIScript : DialogBase
{
    [SerializeField] protected Button _closeButton;
    [SerializeField] protected Button _button1;
    [SerializeField] protected Button _button2;

    public override void Init(DialogInfo info)
    {
        var onClickClose = (Action)info.param["onClickClose"];
        var onClickButton1 = (Action)info.param["onClickButton1"];
        var onClickButton2 = (Action)info.param["onClickButton2"];

        _closeButton.OnClickIntentAsObservable()
            .SelectMany(_ => UIManager.Instance.CloseDialogObservable())
            .Do(_ => {
                if (onClickClose != null)
                {
                    onClickClose();
                    onClickClose = null;
                }
            })
            .Subscribe();

        _button1.OnClickIntentAsObservable()
            .SelectMany(_ => UIManager.Instance.CloseDialogObservable())
            .Do(_ => {
                if (onClickButton1 != null)
                {
                    onClickButton1();
                    onClickButton1 = null;
                }
            })
            .Subscribe();

        _button2.OnClickIntentAsObservable()
            .SelectMany(_ => UIManager.Instance.CloseDialogObservable())
            .Do(_ => {
                if (onClickButton2 != null)
                {
                    onClickButton2();
                    onClickButton2 = null;
                }
            })
            .Subscribe();
    }

    public override void Back(DialogInfo info)
    {
    }
    public override void Close(DialogInfo info)
    {
    }
    public override void Open(DialogInfo info)
    {
    }
}