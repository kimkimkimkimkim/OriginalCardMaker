using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

[ResourcePath("UI/Dialog/Dialog-CardCreate")]
public class CardCreateDialogUIScript : DialogBase {

    [SerializeField] protected Button _closeButton;
    [SerializeField] protected InfiniteScroll _frameInfiniteScroll;

    private List<Frame> targetFrameList = Enum.GetValues(typeof(Frame)).Cast<Frame>().ToList();

    public override void Init(DialogInfo info) {
        var onClickClose = (Action)info.param["onClickClose"];

        _closeButton.OnClickAsObservable()
            .SelectMany(_ => UIManager.Instance.CloseDialogObservable())
            .Do(_ => {
                if (onClickClose != null)
                {
                    onClickClose();
                    onClickClose = null;
                }
            })
            .Subscribe();

        SetInputScrollView();
    }

    private void SetInputScrollView()
    {
        RefreshFramePanel();
    }

    private void RefreshFramePanel() {
        _frameInfiniteScroll.Clear();
        if (targetFrameList.Count > 0) _frameInfiniteScroll.Init(targetFrameList.Count, OnUpdateFrameItem);
    }

    private void OnUpdateFrameItem(int index, GameObject item)
    {
        if ((targetFrameList.Count <= index) || (index < 0)) return;
        var scrollItem = item.GetComponent<CardCreateFrameScrollItem>();
        var frame = targetFrameList[index];

        var name = TextUtil.GetDescriptionAttribute(frame);
        scrollItem.SetText(name);
    }

    public override void Back(DialogInfo info) {
    }
    public override void Close(DialogInfo info) {
    }
    public override void Open(DialogInfo info) {
    }
}
