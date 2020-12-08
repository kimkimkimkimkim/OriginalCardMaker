using System;
using GameBase;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CardCreateStringInputPanelBase : MonoBehaviour
{
    [SerializeField] protected Text _titleText;
    [SerializeField] protected InputField _inputField;

    private IDisposable observable;

    public void RefreshInputPanel(string title, Action<string> inputFieldCallBackAction)
    {
        _titleText.text = title;

        if (observable != null) observable = null;
        observable = _inputField.OnEndEditAsObservable()
            .Do(text =>
            {
                if (inputFieldCallBackAction != null) inputFieldCallBackAction(text);
            })
            .Subscribe();
    }

    public InputField GetInputField()
    {
        return _inputField;
    }
}