using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using GameBase;

public class CommonDialogFactory
{
    public static IObservable<CommonDialogResponse> Create(CommonDialogRequest request)
    {
        return Observable.Create<CommonDialogResponse>(observer => {
            var param = new Dictionary<string, object>();
            param.Add("title", request.title);
            param.Add("body", request.body);
            param.Add("type", request.type);
            param.Add("yesButtonText", request.yesButtonText);
            param.Add("noButtonText", request.noButtonText);
            param.Add("onClickClose", new Action(() => {
                observer.OnNext(new CommonDialogResponse() { responseType = CommonDialogResponseType.No});
                observer.OnCompleted();
            }));
            param.Add("onClickOk", new Action(() => {
                observer.OnNext(new CommonDialogResponse() { responseType = CommonDialogResponseType.Yes });
                observer.OnCompleted();
            }));
            UIManager.Instance.OpenDialog<CommonDialogUIScript>(param, true);
            return Disposable.Empty;
        });
    }
}

