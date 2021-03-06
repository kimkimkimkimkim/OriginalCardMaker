﻿using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

[ResourcePath("UI/Window/Window-Home")]
public class HomeWindowUIScript : WindowBase
{
    [SerializeField] protected Button _createCardButton;
    [SerializeField] protected Button _rewardButton;

    public override void Init(WindowInfo info)
    {
        _createCardButton.OnClickIntentAsObservable()
            .SelectMany(_ => CardCreateDialogFactory.Create(new CardCreateDialogRequest() { }))
            .Subscribe();

        _rewardButton.OnClickIntentAsObservable()
            .SelectMany(_ => CommonDialogFactory.Create(new CommonDialogRequest()
            {
                title = "確認",
                body = "広告を再生して本日の保存回数制限を解除します",
                type = CommonDialogType.Selection,
            }))
            .Where(res => res.responseType == CommonDialogResponseType.Yes)
            .Do(_ =>
            {
                var action = new Action(() =>
                {
                    PlayerPrefsUtil.SetIsFreeTodaySaveCount(true);
                    ShowRewardButtonIfNeeded();
                });

                var isLoaded = MobileAdsManager.Instance.TryShowRewarded(action);

                if (!isLoaded)
                {
                    CommonDialogFactory.Create(new CommonDialogRequest() { body = "表示する広告がありません。時間を置いて再度お試しください。" }).Subscribe();
                }
            })
            .Subscribe();

        ShowRewardButtonIfNeeded();
    }

    private void ShowRewardButtonIfNeeded()
    {
        var isFree = PlayerPrefsUtil.GetIsFreeTodaySaveCount();

        _rewardButton.gameObject.SetActive(!isFree);
    }

    public override void Open(WindowInfo info){
    }

    public override void Back(WindowInfo info){
    }

    public override void Close(WindowInfo info){
    }

}
