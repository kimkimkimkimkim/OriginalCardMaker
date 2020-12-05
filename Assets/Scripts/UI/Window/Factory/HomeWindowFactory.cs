using System;
using System.Collections.Generic;
using UniRx;

public class HomeWindowFactory
{
    public static IObservable<HomeWindowResponse> Create(HomeWindowRequest request)
    {
        return Observable.Create<HomeWindowResponse>(observer => {
            var param = new Dictionary<string, object>();
            UIManager.Instance.OpenWindow<HomeWindowUIScript>(param, false, WindowAnimationType.FooterWindowLeft);
            return Disposable.Empty;
        });
    }
}
