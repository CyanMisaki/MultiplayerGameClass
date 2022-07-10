using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryElementOnStatrScreenView : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;

    public void SetName(string name)
    {
        _itemName.text = name;
    }

    public void SetDescription(string description)
    {
        _itemDescription.text = description;
    }
}
