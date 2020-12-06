public class CardInfo
{
    public string name { get; set; }
    public NameColor nameColor { get; set; }
    public NameSize nameSize { get; set; }
    public Frame frame { get; set; }
    public MonsterAttribute attribute { get; set; }
    public MonsterLevel level { get; set; }
    public string attack { get; set; }
    public string defence { get; set; }
    public string monsterText { get; set; }
    public string text { get; set; }
    public TextSize textSize { get; set; }
    public string pendulumText { get; set; }
    public PendulumTextSize pendulumTextSize { get; set; }
    public PendulumNumBlue pendulumNumBlue { get; set; }
    public PendulumNumRed pendulumNumRed { get; set; }
    public LinkNum linkNum { get; set; }
    public int linkPosition { get; set; }

    /// <summary>
    /// 指定したリンク位置が選択中かどうか返します
    /// </summary>
    public bool IsSelectedLinkPosition(LinkPosition linkPosition)
    {
        return (this.linkPosition & (1 << (int)linkPosition)) != 0;
    }

    /// <summary>
    /// 指定したリンク位置が選択中なら非選択状態に、非選択中なら選択状態にする
    /// </summary>
    public void ToggleLinkPosition(LinkPosition linkPosition)
    {
        this.linkPosition = this.linkPosition ^ (1 << (int)linkPosition);
    }
}
