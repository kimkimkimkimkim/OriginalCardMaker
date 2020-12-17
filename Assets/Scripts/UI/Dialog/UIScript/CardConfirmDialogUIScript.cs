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
            .Do(_ =>
            {
                var texture = new Texture2D(_cardRenderTexture.width, _cardRenderTexture.height, TextureFormat.ARGB32, false, false);
                RenderTexture.active = _cardRenderTexture;
                texture.ReadPixels(new Rect(0, 0, _cardRenderTexture.width, _cardRenderTexture.height), 0, 0);
                texture.Apply();

                // Save the screenshot to Gallery/Photos
                NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(texture, "GalleryTest", "Image.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

                isSaved = true;
            })
            .SelectMany(_ => CommonDialogFactory.Create(new CommonDialogRequest() { body = "画像を保存しました", noButtonText = "閉じる"}))
            .Subscribe();

        _shareButton.OnClickIntentAsObservable()
            .Do(_ => StartCoroutine(Share()))
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
        string tweetText = "【テスト】\nオリジナル遊戯王カード作ってみたw\n楽しいからみんなもやってみて！";
        string tweetURL = "https://www.google.co.jp";
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
