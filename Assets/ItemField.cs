using UnityEngine;
using UnityEngine.UI;

public class ItemField : MonoBehaviour
{
	[SerializeField] private int _id;
	[SerializeField] private Text _mainButtonText;

	public int ID => _id;
	public Text Text => _mainButtonText;
}
