using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;
using System.IO;

[ResourcePath("UI/Dialog/Dialog-CardConfirm")]
public class CardConfirmDialogUIScript : DialogBase
{
    [SerializeField] protected Button _closeButton;
    [SerializeField] protected Button _saveButton;
    [SerializeField] protected Button _shareButton;
    [SerializeField] protected RenderTexture _cardRenderTexture;
    [SerializeField] protected Text _todaySavedCountText;

    private bool isSaved = false;

    public override void Init(DialogInfo info)
    {
        var onClickClose = (Action)info.param["onClickClose"];

        _closeButton.OnClickIntentAsObservable()
            .SelectMany(_ =>
            {
                if (isSaved)
                {
                    return Observable.Return(true);
                }
                else
                {
                    return CommonDialogFactory.Create(new CommonDialogRequest() { body = "まだ保存されていません\n本当に閉じますか？" ,type = CommonDialogType.Selection})
                        .Select(res => res.responseType == CommonDialogResponseType.Yes);
                }
            })
            .Where(isContinue => isContinue)
            .Do(_ => MobileAdsManager.Instance.TryShowInterstitial())
            .SelectMany(_ => UIManager.Instance.CloseDialogObservable())
            .Do(_ => {
                if (onClickClose != null)
                {
                    onClickClose();
                    onClickClose = null;
                }
            })
            .Subscribe();

        _saveButton.OnClickIntentAsObservable()
            .Do(_ => {
                if (isSaved)
                {
                    CommonDialogFactory.Create(new CommonDialogRequest() { body = "保存済みです" }).Subscribe();
                    return;
                }

                var todaySavedCount = PlayerPrefsUtil.GetTodaySavedCount();
                var canSaved = todaySavedCount != ConstUtil.MAX_TODAY_SAVE_COUNT || PlayerPrefsUtil.GetIsFreeTodaySaveCount();
                if (canSaved)
                {
                    // 保存可能なら保存する
                    SaveImage();
                }
                else
                {
                    // 保存不可なら、広告再生許可のダイアログを表示
                    CommonDialogFactory.Create(new CommonDialogRequest(){
                        title = "確認",
                        body = "広告を再生して本日の保存回数制限を解除します",
                        type = CommonDialogType.Selection,
                    })
                        .Where(res => res.responseType == CommonDialogResponseType.Yes)
                        .Do(res =>
                        {
                            var rewardAction = new Action(() => {
                                PlayerPrefsUtil.SetIsFreeTodaySaveCount(true);
                                SaveImage();
                            });

                            MobileAdsManager.Instance.TryShowRewarded(rewardAction);
                        })
                        .Subscribe();
                }

            })
            .Subscribe();

        _shareButton.OnClickIntentAsObservable()
            .Do(_ => StartCoroutine(Share()))
            .Subscribe();

        RefreshTodaySavedCountText();
    }

    private void RefreshTodaySavedCountText()
    {
        var isFree = PlayerPrefsUtil.GetIsFreeTodaySaveCount();
        var todaySavedCount = PlayerPrefsUtil.GetTodaySavedCount();
        _todaySavedCountText.text = isFree ? "本日の保存回数制限解除済み" : $"本日の保存可能回数\n{todaySavedCount} / {ConstUtil.MAX_TODAY_SAVE_COUNT}";
    }

    private void SaveImage()
    {
        Observable.ReturnUnit()
            .Select(res =>
            {
                var texture = new Texture2D(_cardRenderTexture.width, _cardRenderTexture.height, TextureFormat.ARGB32, false, false);
                RenderTexture.active = _cardRenderTexture;
                texture.ReadPixels(new Rect(0, 0, _cardRenderTexture.width, _cardRenderTexture.height), 0, 0);
                texture.Apply();

                // Save the screenshot to Gallery/Photos
                NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(texture, "GalleryTest", "Image.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

                return permission;
            }) 
            .SelectMany(res =>
            {
                if (res == NativeGallery.Permission.Granted)
                {
                    isSaved = true;
                    PlayerPrefsUtil.AddTodaySavedCount();
                    return CommonDialogFactory.Create(new CommonDialogRequest() { body = "画像を保存しました", noButtonText = "閉じる" }).AsUnitObservable();
                }
                else
                {
                    return CommonDialogFactory.Create(new CommonDialogRequest() { body = "画像の保存に失敗しました\nアルバムへの許可がされているかどうか確認してみてください", noButtonText = "閉じる" }).AsUnitObservable();
                }
            })
            .Do(_ => RefreshTodaySavedCountText())
            .Subscribe();
    }

    // SNS共有処理
    public IEnumerator Share()
    {
        string imagePath = Application.persistentDataPath + "/shareImage.png";

        // 前回のデータを削除
        File.Delete(imagePath);
        // 削除が完了するまで待機
        while (true)
        {
            if (!File.Exists(imagePath)) break;
            yield return null;
        }

        // 画像を取得
        var texture = new Texture2D(_cardRenderTexture.width, _cardRenderTexture.height, TextureFormat.ARGB32, false, false);
        RenderTexture.active = _cardRenderTexture;
        texture.ReadPixels(new Rect(0, 0, _cardRenderTexture.width, _cardRenderTexture.height), 0, 0);
        texture.Apply();
        var png = texture.EncodeToPNG();
        File.WriteAllBytes(imagePath, png);

        // 撮影画像の書き込みが完了するまで待機
        while (true)
        {
            if (File.Exists(imagePath)) break;
            yield return null;
        }
        // 撮影画像の保存処理のため、１フレーム待機
        yield return new WaitForEndOfFrame();

        // 投稿する
        string tweetText = "オリジナル遊戯王カード作ってみたw\n楽しいからみんなもやってみて！";
        string tweetURL = "https://apps.apple.com/us/app/オリジナルカードメーカー-for-遊/id1547441197";
        SocialConnector.PostMessage(SocialConnector.ServiceType.Twitter, tweetText, tweetURL, imagePath);
    }

    public override void Back(DialogInfo info)
    {
    }
    public override void Close(DialogInfo info)
    {
    }
    public override void Open(DialogInfo info)
    {
    }
}
