using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameBase;

[ResourcePath("UI/Dialog/Dialog-CardConfirm")]
public class CardConfirmDialogUIScript : DialogBase
{
    [SerializeField] protected Button _closeButton;
    [SerializeField] protected Button _saveButton;
    [SerializeField] protected Button _shareButton;
    [SerializeField] protected RenderTexture _cardRenderTexture;

    public override void Init(DialogInfo info)
    {
        var onClickClose = (Action)info.param["onClickClose"];

        _closeButton.OnClickIntentAsObservable()
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
            })
            .Subscribe();

        _shareButton.OnClickIntentAsObservable()
            .Subscribe();
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
