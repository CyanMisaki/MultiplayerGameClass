using System;
using System.Collections.Generic;
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
                                            OnError);
            PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(),
                OnGetCatalogOnSuccess, OnError);
        }

        private void OnGetCatalogOnSuccess(GetCatalogItemsResult result)
        {
            ShowCatalog(result.Catalog);
            Debug.Log("CompleteLoadCatalog");
        }

        private void ShowCatalog(List<CatalogItem> catalog)
        {
            foreach (var item in catalog)
            {
                if(item.Bundle==null && item.Container==null)
                    Debug.Log($"Item: {item.ItemId} - {item.DisplayName}");
            }
        }

        private void OnError(PlayFabError obj)
        {
            var errorMsg = obj.GenerateErrorReport();
            Debug.LogError(errorMsg);
        }

        private void OnGetAccountSuccess(GetAccountInfoResult result)
        {
            var accInfo = result.AccountInfo;
            _titleLabel.text = $"Welcome, {accInfo.Username}, {accInfo.PlayFabId}";
            _howLongInGameLabel.text = $"In game for: {(DateTime.Now - accInfo.Created).Days.ToString()} day(s).";
        }
    }
}