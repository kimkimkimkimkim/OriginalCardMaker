using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using GameBase;

public class ModalDialogFactory
{
    public static IObservable<ModalDialogResponse> Create(ModalDialogRequest request)
    {
        return Observable.Create<ModalDialogResponse>(observer => {
            var param = new Dictionary<string, object>();
            param.Add("onClickClose", new Action(() => {
                observer.OnNext(new ModalDialogResponse() { responseType = ModalDialogResponseType.Cancel});
                observer.OnCompleted();
            }));
            param.Add("onClickButton1", new Action(() => {
                observer.OnNext(new ModalDialogResponse() { responseType = ModalDialogResponseType.Button1 });
                observer.OnCompleted();
            }));
            param.Add("onClickButton2", new Action(() => {
                observer.OnNext(new ModalDialogResponse() { responseType = ModalDialogResponseType.Button2 });
                observer.OnCompleted();
            }));
            UIManager.Instance.OpenDialog<ModalDialogUIScript>(param, true, DialogAnimationType.Bottom);
            return Disposable.Empty;
        });
    }
}
