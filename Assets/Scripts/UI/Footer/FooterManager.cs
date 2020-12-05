using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class FooterManager : MonoBehaviour
{
    [SerializeField] protected GameObject _selectedMark;
    [SerializeField] protected GameObject _homeButtonBase;
    [SerializeField] protected GameObject _boxButtonBase;
    [SerializeField] protected Button _homeButton;
    [SerializeField] protected Button _boxButton;
    [SerializeField] protected Image _homeButtonIcon;
    [SerializeField] protected Image _boxButtonIcon;
    [SerializeField] protected Text _homeButtonText;
    [SerializeField] protected Text _boxButtonText;

    private const float SELECTED_ICON_POSITION_Y = 70.0f;
    private const float UNSELECTED_ICON_POSITION_Y = 0.0f;

    private void Start()
    {
        _homeButton.OnClickAsObservable()
            .Do(_ => UIManager.Instance.CloseWindow(forceCloseParent: true, animationType: WindowAnimationType.FooterWindowRight))
            .Do(_ =>
            {
                PlaySelectedAnimationObservable(_homeButtonBase, _homeButtonIcon, _homeButtonText).Subscribe();
                PlayDeselectedAnimationObservable(_boxButtonIcon, _boxButtonText).Subscribe();
            })
            .SelectMany(_ => HomeWindowFactory.Create(new HomeWindowRequest()))
            .Subscribe();

        _boxButton.OnClickAsObservable()
            .Do(_ => UIManager.Instance.CloseWindow(forceCloseParent: true, animationType: WindowAnimationType.FooterWindowLeft))
            .Do(_ =>
            {
                PlaySelectedAnimationObservable(_boxButtonBase, _boxButtonIcon, _boxButtonText).Subscribe();
                PlayDeselectedAnimationObservable(_homeButtonIcon, _homeButtonText).Subscribe();
            })
            .SelectMany(_ => BoxWindowFactory.Create(new BoxWindowRequest()))
            .Subscribe();

        // ホームボタンを押したことにする
        _homeButton.onClick.Invoke();
    }

    private IObservable<Unit> PlaySelectedAnimationObservable(GameObject buttonBase, Image buttonIcon, Text buttonText)
    {
        // 選択マーク
        var selectedMarkSequence = DOTween.Sequence()
            .Append(_selectedMark.transform.DOLocalMove(buttonBase.transform.localPosition, 0.5f));

        // アイコン
        var iconSequence = DOTween.Sequence()
            .Append(buttonIcon.transform.DOLocalMoveY(SELECTED_ICON_POSITION_Y, 0.5f));

        buttonText.gameObject.SetActive(true);
        return DOTween.Sequence()
            .Append(selectedMarkSequence)
            .Join(iconSequence)
            .OnCompleteAsObservable()
            .AsUnitObservable();
    }

    private IObservable<Unit> PlayDeselectedAnimationObservable(Image buttonIcon, Text buttonText)
    {
        // アイコン
        var iconSequence = DOTween.Sequence()
            .Append(buttonIcon.transform.DOLocalMoveY(UNSELECTED_ICON_POSITION_Y, 0.5f));

        buttonText.gameObject.SetActive(false);
        return DOTween.Sequence()
            .Join(iconSequence)
            .OnCompleteAsObservable()
            .AsUnitObservable();
    }
}
