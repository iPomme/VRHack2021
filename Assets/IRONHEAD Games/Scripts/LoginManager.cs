using System;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField PlayerName_InputName;
    
    #region Unity Methods
    
    #endregion

    
    #region UI Callback Methods
    public void ConnectionAnonymously()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToPhotoServer()
    {
        if (PlayerName_InputName != null)
        {
            PhotonNetwork.NickName = PlayerName_InputName.text;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    #endregion

    
    #region Photon callbaks

    public override void OnConnected()
    {
        Debug.Log("OnConnected Called. The server is available");
    }

    public override void OnConnectedToMaster()
    {
        Debug.LogFormat("OnConnectedToServer Called. Connected to the Master server using nickname {0}!", PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("HomeScene");
    }
    
    #endregion
    
    
}
