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
