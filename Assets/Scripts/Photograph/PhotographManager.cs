using System.Collections;
using System.Collections.Generic;
using GameBase;
using UnityEngine;
using UnityEngine.UI;

public class PhotographManager : SingletonMonoBehaviour<PhotographManager>
{
    [SerializeField] protected Transform _cardItemBase;

    public CardItem CreateCardItem()
    {
        return UIManager.Instance.CreateContent<CardItem>(_cardItemBase);
    }
}
