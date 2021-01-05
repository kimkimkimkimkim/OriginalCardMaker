public class CommonDialogRequest
{
    /// <summary>
    /// タイトル
    /// </summary>
    public string title { get; set; } = "確認";

    /// <summary>
    /// 本文
    /// </summary>
    public string body { get; set; } = "";

    /// <summary>
    /// Yesボタンテキスト
    /// </summary>
    public string yesButtonText { get; set; } = "はい";

    /// <summary>
    /// Noボタンテキスト
    /// </summary>
    public string noButtonText { get; set; } = "いいえ";

    /// <summary>
    /// ダイアログタイプ
    /// </summary>
    public CommonDialogType type { get; set; } = CommonDialogType.Confirm;
}

public class CommonDialogResponse
{
    /// <summary>
    /// レスポンスタイプ
    /// </summary>
    public CommonDialogResponseType responseType { get; set; }
}

public enum CommonDialogType
{
    Confirm, // OKだけ
    Selection, // Yes,Noの選択
}

public enum CommonDialogResponseType
{
    None,
    Yes,
    No
}