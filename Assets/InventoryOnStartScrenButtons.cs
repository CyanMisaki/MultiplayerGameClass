using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.PlayFabScripts.Accounts.UI;

public class InventoryOnStartScrenButtons : MonoBehaviour
{
    [SerializeField] private Button _rewButton;
    [SerializeField] private Button _fwdButton;
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private ScrollRect _scrollField;

    private IsInventoryOnStartScreenButtonPressed _fwdPressed;
    private IsInventoryOnStartScreenButtonPressed _rewPressed;

    private void Start()
    {
        _rewPressed = _rewButton.GetComponent<IsInventoryOnStartScreenButtonPressed>();
        _fwdPressed = _fwdButton.GetComponent<IsInventoryOnStartScreenButtonPressed>();
    }

    private void FixedUpdate()
    {
        if(_rewPressed.IsHolded)
        {
            _scrollField.horizontalNormalizedPosition -= _scrollSpeed * Time.deltaTime;
        }
        
        if(_fwdPressed.IsHolded)
        {
            _scrollField.horizontalNormalizedPosition += _scrollSpeed * Time.deltaTime;
        }

    }
}
