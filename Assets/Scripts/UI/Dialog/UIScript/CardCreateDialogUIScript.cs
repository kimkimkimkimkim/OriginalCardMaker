﻿using System;
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
    [SerializeField] protected Button _pickImageButton;
    [SerializeField] protected Button _pickXyzImageButton;
    [SerializeField] protected RawImage _rawImage;
    [SerializeField] protected RawImage _xyzRawImage;
    [SerializeField] protected Transform _cardItemBase;
    [SerializeField] protected Transform _inputPanelBase;

    private CardItem cardItem;
    private CardCreateStringInputPanelBase monsterTextInputPanel;

    public override void Init(DialogInfo info) {
        var onClickClose = (Action)info.param["onClickClose"];

        CreateCardItem();

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

        _pickImageButton.OnClickIntentAsObservable()
            .Do(_ =>
            {
                PickAndCrop(_rawImage, 1,texture =>
                {
                    if (cardItem == null) {
                        Debug.Log("card Itemがあリマせん");
                        return;
                    }
                    Debug.Log("Update Image");
                    cardItem.UpdateRawImage(texture);
                });
            })
            .Subscribe();

        _pickXyzImageButton.OnClickIntentAsObservable()
            .Do(_ =>
            {
                PickAndCrop(_xyzRawImage, 1.337f, texture =>
                {
                    if (cardItem == null) return;
                    cardItem.UpdateXyzRawImage(texture);
                });
            })
            .Subscribe();

        CreateInputPanel();

    }

    private void CreateCardItem()
    {
        cardItem = UIManager.Instance.CreateContent<CardItem>(_cardItemBase);
        cardItem.UpdateAllUI();
    }

    private void CreateInputPanel()
    {
        // Name
        var nameInputPanel = UIManager.Instance.CreateContent<CardCreateStringInputPanel>(_inputPanelBase);
        nameInputPanel.RefreshInputPanel("カード名", text => {
            cardItem.UpdateNameInfo(text);
            cardItem.UpdateNameUI();
        });

        // NameColor
        var nameColorInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        nameColorInputPanel.RefreshPanel<NameColor>(cardItem);

        // NameSize
        var nameSizeInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        nameSizeInputPanel.RefreshPanel<NameSize>(cardItem);

        // Frame
        var frameInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        frameInputPanel.RefreshPanel<Frame>(cardItem,callBackAction:frame =>
        {
            if (monsterTextInputPanel == null) return;
            var inputField = monsterTextInputPanel.GetInputField();
            var text = CardUtil.GetInitialMonsterText(frame);
            inputField.text = text;
            cardItem.UpdateMonsterTextInfo(text);
            cardItem.UpdateMonsterTextUI();
        });

        // Attribute
        var attributeInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        attributeInputPanel.RefreshPanel<MonsterAttribute>(cardItem);

        // Level
        var levelInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        levelInputPanel.RefreshPanel<MonsterLevel>(cardItem);

        // Attack
        var attackInputPanel = UIManager.Instance.CreateContent<CardCreateStringInputPanel>(_inputPanelBase);
        attackInputPanel.RefreshInputPanel("攻撃力", text => {
            cardItem.UpdateAttackInfo(text);
            cardItem.UpdateAttackUI();
        });

        // Defence
        var defenceInputPanel = UIManager.Instance.CreateContent<CardCreateStringInputPanel>(_inputPanelBase);
        defenceInputPanel.RefreshInputPanel("守備力", text => {
            cardItem.UpdateDefenceInfo(text);
            cardItem.UpdateDefenceUI();
        });

        // MonsterText
        monsterTextInputPanel = UIManager.Instance.CreateContent<CardCreateStringInputPanel>(_inputPanelBase);
        monsterTextInputPanel.RefreshInputPanel("モンスターテキスト", text => {
            cardItem.UpdateMonsterTextInfo(text);
            cardItem.UpdateMonsterTextUI();
        });
        var monsterTextInputField = monsterTextInputPanel.GetInputField();
        var monsterText = CardUtil.GetInitialMonsterText(cardItem.GetCardInfo().frame);
        monsterTextInputField.text = monsterText;
        cardItem.UpdateMonsterTextInfo(monsterText);
        cardItem.UpdateMonsterTextUI();

        // Text
        var textInputPanel = UIManager.Instance.CreateContent<CardCreateStringInputPanelLarge>(_inputPanelBase);
        textInputPanel.RefreshInputPanel("テキスト", text => {
            cardItem.UpdateTextInfo(text);
            cardItem.UpdateTextUI();
        });

        // TextSize
        var textSizeInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        textSizeInputPanel.RefreshPanel<TextSize>(cardItem);

        // PendulumText
        var pendulumTextInputPanel = UIManager.Instance.CreateContent<CardCreateStringInputPanelLarge>(_inputPanelBase);
        pendulumTextInputPanel.RefreshInputPanel("ペンデュラム", text => {
            cardItem.UpdatePendulumTextInfo(text);
            cardItem.UpdatePendulumTextUI();
        });

        // PendulumTextSize
        var pendulumTextSizeInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        pendulumTextSizeInputPanel.RefreshPanel<PendulumTextSize>(cardItem);

        // PendulumNumBlue
        var pendulumNumBlueInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        pendulumNumBlueInputPanel.RefreshPanel<PendulumNumBlue>(cardItem);

        // PendulumNumRed
        var pendulumNumRedInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        pendulumNumRedInputPanel.RefreshPanel<PendulumNumRed>(cardItem);

        // LinkNum
        var linkNumInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        linkNumInputPanel.RefreshPanel<LinkNum>(cardItem);

        // LinkPosition
        var linkPositionInputPanel = UIManager.Instance.CreateContent<CardCreateEnumInputPanel>(_inputPanelBase);
        linkPositionInputPanel.RefreshPanel<LinkPosition>(cardItem,isMultipleSelection: true);
    }

    private void PickAndCrop(RawImage rawImage, float aspectRatio, Action<Texture> callBackAction)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                ImageCropper.Instance.Show(texture, (bool result, Texture originalImage, Texture2D croppedImage) =>
                {
                    // If screenshot was cropped successfully
                    if (result)
                    {
                        Debug.Log("===== クロップ完了 ========");
                        rawImage.texture = croppedImage;
                        callBackAction(croppedImage);
                    }
                    else
                    {
                        Debug.Log("===== クロップできませんでした ========");
                    }

                    // Destroy the screenshot as we no longer need it in this case
                    Destroy(texture);
                },
                settings: new ImageCropper.Settings()
                {
                    ovalSelection = false,
                    autoZoomEnabled = true,
                    imageBackground = Color.clear, // transparent background
                    selectionMinAspectRatio = aspectRatio,
                    selectionMaxAspectRatio = aspectRatio

                },
                croppedImageResizePolicy: (ref int width, ref int height) =>
                {
                    // uncomment lines below to save cropped image at half resolution
                    //width /= 2;
                    //height /= 2;
                });
            }
            else
            {
                Debug.Log("==== pathがありません ====");
            }
        }, "Select a PNG image", "image/png");
    }

    public override void Back(DialogInfo info) {
    }
    public override void Close(DialogInfo info) {
    }
    public override void Open(DialogInfo info) {
    }
}
