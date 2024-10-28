using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GoogleUtility : MonoBehaviour
{
    public GameObject connectedUI;
    public GameObject disconnectedUI;

    public static GoogleUtility instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //// Initialize Google Play Games platform
            //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            //    .Build();
            //PlayGamesPlatform.InitializeInstance(config);
            //PlayGamesPlatform.Activate();

            // Authenticate the user
            AuthenticateUser();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AuthenticateUser()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            OnConnectionResponse(success);
        });
    }

    public void OnConnectClick()
    {
        // Re-authenticate the user on button click
        AuthenticateUser();
    }

    private void OnConnectionResponse(bool authenticated)
    {
        if (authenticated)
        {
            // Unlock an achievement if authenticated (make sure the GameManager and IDs are correctly set up)
            GameManager.Instance.UnlockAchievement(GPGSPenguRunSDIds.achievement_log_in);

            // Update UI to show connected status
            disconnectedUI.SetActive(false);
            connectedUI.SetActive(true);
        }
        else
        {
            // Update UI to show disconnected status
            disconnectedUI.SetActive(true);
            connectedUI.SetActive(false);
        }
    }
}
