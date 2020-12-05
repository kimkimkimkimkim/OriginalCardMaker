using System;
using System.Collections.Generic;
using UniRx;

public class BoxWindowFactory
{
    public static IObservable<BoxWindowResponse> Create(BoxWindowRequest request)
    {
        return Observable.Create<BoxWindowResponse>(observer => {
            var param = new Dictionary<string, object>();
            UIManager.Instance.OpenWindow<BoxWindowUIScript>(param, false, WindowAnimationType.FooterWindowRight);
            return Disposable.Empty;
        });
    }
}