using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using GameBase;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    void Start()
    {
        CheckLoginDate();

        HomeWindowFactory.Create(new HomeWindowRequest()).Subscribe();
    }

    private void CheckLoginDate()
    {
        var lastLoginDate = PlayerPrefsUtil.GetLastLoginDate();

        var isFirstTimeLoginToday = IsFirstTimeLoginToday(lastLoginDate);
        if (isFirstTimeLoginToday) PlayerPrefsUtil.SetIsFreeTodaySaveCount(false);

        var now = DateTime.Now;
        PlayerPrefsUtil.SetLastLoginDate(now);
    }

    private bool IsFirstTimeLoginToday(DateTime lastLoginDate)
    {
        var now = DateTime.Now;

        Debug.Log($"now : {now.Year}/{now.Month}/{now.Day}");
        Debug.Log($"lastLoginDate : {lastLoginDate.Year}/{lastLoginDate.Month}/{lastLoginDate.Day}");

        if (lastLoginDate.Year == now.Year && lastLoginDate.Month == now.Month && lastLoginDate.Day < now.Day) return true;

        if (lastLoginDate.Year == now.Year && lastLoginDate.Month < now.Month) return true;

        if (lastLoginDate.Year < now.Year) return true;

        return false;
    }
}
