using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

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

    private const float ANIMATION_TIME = 0.2f;
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
            .SelectMany(_ => CommonDialogFactory.Create(new CommonDialogRequest() { title = "お知らせ", body = "Box機能は近日実装予定です" }))
            .Subscribe();
        /*
        _boxButton.OnClickAsObservable()
            .Do(_ => UIManager.Instance.CloseWindow(forceCloseParent: true, animationType: WindowAnimationType.FooterWindowLeft))
            .Do(_ =>
            {
                PlaySelectedAnimationObservable(_boxButtonBase, _boxButtonIcon, _boxButtonText).Subscribe();
                PlayDeselectedAnimationObservable(_homeButtonIcon, _homeButtonText).Subscribe();
            })
            .SelectMany(_ => BoxWindowFactory.Create(new BoxWindowRequest()))
            .Subscribe();
        */           

        // ホームボタンを押したことにする
        // 確実に動作させるため1フレーム後に実行
        Observable.NextFrame().Do(_ => _homeButton.onClick.Invoke()).Subscribe();
    }

    private IObservable<Unit> PlaySelectedAnimationObservable(GameObject buttonBase, Image buttonIcon, Text buttonText)
    {
        // 選択マーク
        var selectedMarkSequence = DOTween.Sequence()
            .Append(_selectedMark.transform.DOLocalMove(buttonBase.transform.localPosition, ANIMATION_TIME));

        // アイコン
        var iconSequence = DOTween.Sequence()
            .Append(buttonIcon.transform.DOLocalMoveY(SELECTED_ICON_POSITION_Y, ANIMATION_TIME));

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
            .Append(buttonIcon.transform.DOLocalMoveY(UNSELECTED_ICON_POSITION_Y, ANIMATION_TIME));

        buttonText.gameObject.SetActive(false);
        return DOTween.Sequence()
            .Join(iconSequence)
            .OnCompleteAsObservable()
            .AsUnitObservable();
    }
}
