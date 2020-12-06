using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using GameBase;

public class CardCreateDialogFactory
{
    public static IObservable<CardCreateDialogResponse> Create(CardCreateDialogRequest request)
    {
        return Observable.Create<CardCreateDialogResponse>(observer => {
            var param = new Dictionary<string, object>();
            param.Add("onClickClose", new Action(() => {
                observer.OnNext(new CardCreateDialogResponse());
                observer.OnCompleted();
            }));
            UIManager.Instance.OpenDialog<CardCreateDialogUIScript>(param, true);
            return Disposable.Empty;
        });
    }
}
