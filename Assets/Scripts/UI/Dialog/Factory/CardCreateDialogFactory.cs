using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CardCreateDialogFactory
{
    public static IObservable<CardCreateDialogResponse> Create(CardCreateDialogRequest request)
    {
        return Observable.Create<CardCreateDialogResponse>(observer => {
            var param = new Dictionary<string, object>();
            UIManager.Instance.OpenDialog<CardCreateDialogUIScript>(param, true);
            return Disposable.Empty;
        });
    }
}
