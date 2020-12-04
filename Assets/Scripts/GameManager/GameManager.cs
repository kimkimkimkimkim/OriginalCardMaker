using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        HomeWindowFactory.Create(new HomeWindowRequest()).Subscribe();
    }
}
