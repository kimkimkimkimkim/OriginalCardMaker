using UnityEngine;
using UnityEngine.UI;

public class ToggleScrollItem : ScrollItem
{
    [SerializeField] protected Toggle _toggle;

    public void SetToggleGroup(ToggleGroup group)
    {
        _toggle.group = group;
    }

    public void SetSelectionState(bool isSelected)
    {
        _toggle.isOn = isSelected;
    }
}
