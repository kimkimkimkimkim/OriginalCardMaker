using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

public class ScrollItem : MonoBehaviour
{
    [SerializeField] protected Button _button;
    [SerializeField] protected Image _image;
    [SerializeField] protected Text _text;

    public Button button { get { return _button; } }
    public Image image { get { return _image; } }
    private Action _onClickCallback;
    private IDisposable _onClickObservable;

    public void SetText(string str)
    {
        _text.text = str;
    }

    public void SetOnClickAction(Action callbackAction)
    {
        _onClickCallback = callbackAction;
        if (_onClickObservable != null) _onClickObservable.Dispose();

        _onClickObservable = _button.OnClickIntentAsObservable()
            .Where(_ => _onClickCallback != null)
            .Do(_ => _onClickCallback())
            .Subscribe();
    }
}
