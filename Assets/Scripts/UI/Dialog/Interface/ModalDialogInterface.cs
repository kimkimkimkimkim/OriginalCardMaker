public class ModalDialogRequest
{

}

public class ModalDialogResponse
{
    /// <summary>
    /// レスポンスタイプ
    /// </summary>
    public ModalDialogResponseType responseType { get; set; }
}

public enum ModalDialogResponseType
{
    Cancel,
    Button1,
    Button2
}
