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
        // すでに存在していたら削除
        if(_cardItemBase.transform.childCount > 0)
        {
            foreach (Transform t in _cardItemBase.transform)
            {
                GameObject.Destroy(t.gameObject);
            }
        }

        return UIManager.Instance.CreateContent<CardItem>(_cardItemBase);
    }
}
