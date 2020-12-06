using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

[ResourcePath("UI/Window/Window-Home")]
public class HomeWindowUIScript : WindowBase
{
    [SerializeField] protected Button _createCardButton;

    public override void Init(WindowInfo info)
    {
        _createCardButton.OnClickIntentAsObservable()
            .SelectMany(_ => CardCreateDialogFactory.Create(new CardCreateDialogRequest() { }))
            .Subscribe();
    }

    public override void Open(WindowInfo info){
    }

    public override void Back(WindowInfo info){
    }

    public override void Close(WindowInfo info){
    }

}
