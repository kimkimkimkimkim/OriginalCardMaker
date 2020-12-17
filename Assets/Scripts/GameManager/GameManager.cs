using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using GameBase;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    void Start()
    {
        HomeWindowFactory.Create(new HomeWindowRequest()).Subscribe();
    }
}
