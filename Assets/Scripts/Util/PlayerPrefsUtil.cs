using System;
using GameBase;

public class PlayerPrefsUtil
{
    #region Key
    /// <summary>
    /// 本日の保存回数が無制限か否か
    /// </summary>
    private static string IS_FREE_TODAY_SAVE_COUNT = "isFreeTodaySaveCount";

    /// <summary>
    /// 本日保存した回数
    /// </summary>
    private static string TODAY_SAVED_COUNT = "todaySavedCount";

    /// <summary>
    /// 最終ログイン日時
    /// </summary>
    private static string LAST_LOGIN_DATE = "lastLoginDate";
    #endregion Key

    #region Get
    public static bool GetIsFreeTodaySaveCount()
    {
        return SaveData.GetBool(IS_FREE_TODAY_SAVE_COUNT,false);
    }

    public static int GetTodaySavedCount()
    {
        return SaveData.GetInt(TODAY_SAVED_COUNT, 0);
    }

    public static DateTime GetLastLoginDate()
    {
        var defaultDate = new DateTime(1970,1,1).ToString();
        var dateStr = SaveData.GetString(LAST_LOGIN_DATE, defaultDate);
        return DateTime.Parse(dateStr);
    }
    #endregion Get

    #region Set
    public static void SetIsFreeTodaySaveCount(bool value)
    {
        SaveData.SetBool(IS_FREE_TODAY_SAVE_COUNT, value);
        SaveData.Save();
    }

    public static void SetTodaySavedCount(int value)
    {
        SaveData.SetInt(TODAY_SAVED_COUNT, value);
        SaveData.Save();
    }

    public static void SetLastLoginDate(DateTime value)
    {
        SaveData.SetString(LAST_LOGIN_DATE, value.ToString());
        SaveData.Save();
    }
    #endregion Set

    #region Add
    public static void AddTodaySavedCount()
    {
        var todaySavedCount = GetTodaySavedCount();
        todaySavedCount++;
        SetTodaySavedCount(todaySavedCount);
    }
    #endregion Add
}
