using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    [Header("LOGIN")]
    private string userEmailLogin;
    private string userPasswordLogin;

    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "144";
        }
    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("First API call");
    }
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    public void GetUserEmail(string email)
    {
        userEmailLogin = email;
    }
    public void GetUserPassword(string pass)
    {
        userPasswordLogin = pass;
    }
    public void LogIn()
    {
        print(userEmailLogin);
        var request = new LoginWithEmailAddressRequest
        {
            Email = userEmailLogin,
            Password = userPasswordLogin
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
}
