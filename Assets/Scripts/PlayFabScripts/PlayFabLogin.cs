using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    private const string TitleId = "921EC";
    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = TitleId;
        }

        var request = new LoginWithCustomIDRequest
        {
            CustomId = "Player1",
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailed);
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
