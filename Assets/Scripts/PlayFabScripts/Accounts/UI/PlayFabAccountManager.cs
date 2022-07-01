using System;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

namespace PlayFabScripts.Accounts.UI
{
    public class PlayFabAccountManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleLabel;
        [SerializeField] private TMP_Text _howLongInGameLabel;


        private void Start()
        {
            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(),
                                            OnGetAccountSuccess,
                                            OnGetAccountError);
        }

        private void OnGetAccountError(PlayFabError obj)
        {
            var errorMsg = obj.GenerateErrorReport();
            Debug.LogError(errorMsg);
        }

        private void OnGetAccountSuccess(GetAccountInfoResult result)
        {
            var accInfo = result.AccountInfo;
            _titleLabel.text = $"Welcome, {accInfo.Username}, {accInfo.PlayFabId}";
            _howLongInGameLabel.text = $"In game for: {(DateTime.Now - accInfo.Created).Days.ToString()} days.";
        }
    }
}