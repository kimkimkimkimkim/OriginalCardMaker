using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using GameBase;

public class CardConfirmDialogFactory
{
    public static IObservable<CardConfirmDialogResponse> Create(CardConfirmDialogRequest request)
    {
        return Observable.Create<CardConfirmDialogResponse>(observer => {
            var param = new Dictionary<string, object>();
            param.Add("onClickClose", new Action(() => {
                observer.OnNext(new CardConfirmDialogResponse());
                observer.OnCompleted();
            }));
            UIManager.Instance.OpenDialog<CardConfirmDialogUIScript>(param, true);
            return Disposable.Empty;
        });
    }
}
