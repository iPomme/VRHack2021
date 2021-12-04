using System;
using UnityEngine;
using Photon.Pun;
public class LoginManager : MonoBehaviourPunCallbacks
{
    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    
    #region Photon callbaks

    public override void OnConnected()
    {
        Debug.Log("OnConnected Called. The server is available");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToServer Called. Connected to the server!");
    }
    
    #endregion
    
    
}
