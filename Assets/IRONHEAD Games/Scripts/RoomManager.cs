using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    #region UI Callbacks methods

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    #endregion

    #region Photon Callback

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogFormat("{0}:{1}",returnCode, message);
        CreateAndJoinRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.LogFormat("A room is created with the name: {0}", PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.LogFormat("The local Player: {0} joined to {1}, Player counts is {2}", PhotonNetwork.NickName, PhotonNetwork.CurrentRoom.Name, PhotonNetwork.CurrentRoom.PlayerCount);
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("The Player: {0} joined to {1}, Player counts is {2}", newPlayer.NickName, PhotonNetwork.CurrentRoom.Name, PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion
    
    #region Private Methods

    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room" + Random.Range(1, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }
    #endregion
}
