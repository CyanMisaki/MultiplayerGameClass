using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace PlayFabScripts.Accounts
{
    public class PlayFabLogin : MonoBehaviour
    {
        private const string TitleId = "921EC";
        private const string AuthGuidKey = "auth_guid";
        private void Start()
        {
            if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            {
                PlayFabSettings.staticSettings.TitleId = TitleId;
            }

            var needCreation = PlayerPrefs.HasKey(AuthGuidKey);
            var id = PlayerPrefs.GetString(AuthGuidKey, Guid.NewGuid().ToString());
            
            var request = new LoginWithCustomIDRequest
            {
                CustomId = id,
                CreateAccount = !needCreation
            };
            PlayFabClientAPI.LoginWithCustomID(request, success =>
            {
                PlayerPrefs.SetString(AuthGuidKey, id);
                OnLoginSuccess(success);
            }, OnLoginFailed);
        }

        private void OnLoginFailed(PlayFabError res)
        {
            var errorMessage = res.GenerateErrorReport();
            Debug.LogError($"Error: {errorMessage}");
        }

        private void OnLoginSuccess(LoginResult res)
        {
            Debug.Log("Logging complete");
        }
    }
}
