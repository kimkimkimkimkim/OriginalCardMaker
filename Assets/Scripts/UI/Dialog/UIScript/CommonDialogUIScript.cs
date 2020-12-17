using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

[ResourcePath("UI/Dialog/Dialog-Common")]
public class CommonDialogUIScript : DialogBase
{
    [SerializeField] protected Button _closeButton;
    [SerializeField] protected Button _yesButton;
    [SerializeField] protected GameObject _yesButtonBase;
    [SerializeField] protected Text _yesButtonText;
    [SerializeField] protected Text _noButtonText;
    [SerializeField] protected Text _titleText;
    [SerializeField] protected Text _bodyText;

    public override void Init(DialogInfo info)
    {
        var onClickClose = (Action)info.param["onClickClose"];
        var onClickOk = (Action)info.param["onClickOk"];
        var title = (string)info.param["title"];
        var body = (string)info.param["body"];
        var yesButtonText = (string)info.param["yesButtonText"];
        var noButtonText = (string)info.param["noButtonText"];
        var type = (CommonDialogType)info.param["type"];

        SetUI(type);

        _titleText.text = title;
        _bodyText.text = body;
        _yesButtonText.text = yesButtonText;
        _noButtonText.text = noButtonText;

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

        _yesButton.OnClickIntentAsObservable()
            .SelectMany(_ => UIManager.Instance.CloseDialogObservable())
            .Do(_ => {
                if (onClickOk != null)
                {
                    onClickOk();
                    onClickOk = null;
                }
            })
            .Subscribe();
    }

    /// <summary>
    /// タイプに応じてUIを調整
    /// </summary>
    private void SetUI(CommonDialogType type)
    {
        switch (type)
        {
            case CommonDialogType.Confirm:
                _yesButtonBase.SetActive(false);
                break;
            case CommonDialogType.Selection:
                _yesButtonBase.SetActive(true);
                break;
        }
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
