public class CardInfo
{
    public string name { get; set; }
    public NameColor nameColor { get; set; }
    public NameSize nameSize { get; set; }
    public Frame frame { get; set; }
    public MonsterAttribute monsterAttribute { get; set; }
    public MonsterLevel monsterLevel { get; set; }
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
}
