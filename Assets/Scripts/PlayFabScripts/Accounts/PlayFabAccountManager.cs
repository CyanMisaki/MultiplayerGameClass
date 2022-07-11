using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;

namespace PlayFabScripts.Accounts
{
    public class PlayFabAccountManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleLabel;
        [SerializeField] private TMP_Text _howLongInGameLabel;
        [SerializeField] private Transform _itemScrollerTransform;
        [SerializeField] private InventoryElementOnStartScreenView _itemScrollerCellPrefab;


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
                if (item.Bundle != null || item.Container != null) continue;
                
                var elementText = Instantiate(_itemScrollerCellPrefab, _itemScrollerTransform);
                elementText.SetName(item.DisplayName);
                elementText.SetDescription(item.Description);

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