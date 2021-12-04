using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;
using TMPro;


public class RoomManager : MonoBehaviourPunCallbacks
{
    private string mapType;

    public TextMeshProUGUI OccupencyRateText_School;
    public TextMeshProUGUI OccupencyRateText_Outdoor;

    #region Unity Callbacks

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    #endregion

    #region UI Callbacks methods

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnEnterButtonClicked_Outdoor()
    {
        mapType = MultiplayerVRConstant.MAP_TYPE_VALUE_OUTDOOR;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
            {{MultiplayerVRConstant.MAP_TYPE_KEY, mapType}};
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    public void OnEnterButtonClicked_School()
    {
        mapType = MultiplayerVRConstant.MAP_TYPE_VALUE_SCHOOL;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
            {{MultiplayerVRConstant.MAP_TYPE_KEY, mapType}};
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    public void OnEnterButtonClicked_SoundRoom()
    {
        mapType = MultiplayerVRConstant.MAP_TYPE_VALUE_SOUNDROOM;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
            {{MultiplayerVRConstant.MAP_TYPE_KEY, mapType}};
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    #endregion

    #region Photon Callback

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogFormat("{0}:{1}", returnCode, message);
        CreateAndJoinRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.LogFormat("A room is created with the name: {0}", PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.LogFormat("The local Player: {0} joined to {1}, Player counts is {2}", PhotonNetwork.NickName,
            PhotonNetwork.CurrentRoom.Name, PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstant.MAP_TYPE_KEY))
        {
            object mapType;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstant.MAP_TYPE_KEY, out mapType))
            {
                Debug.LogFormat("Joined the room with the map: {0}", (string) mapType);
                if ((string) mapType == MultiplayerVRConstant.MAP_TYPE_VALUE_SCHOOL)
                {
                    PhotonNetwork.LoadLevel("World_School");
                }
                else if ((string)mapType == MultiplayerVRConstant.MAP_TYPE_VALUE_OUTDOOR)
                {
                    PhotonNetwork.LoadLevel("World_Outdoor");
                }
                else if ((string)mapType == MultiplayerVRConstant.MAP_TYPE_VALUE_SOUNDROOM)
                {
                    PhotonNetwork.LoadLevel("SoundRoom");
                }
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("The Player: {0} joined to {1}, Player counts is {2}", newPlayer.NickName,
            PhotonNetwork.CurrentRoom.Name, PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList.Count == 0)
        {
            OccupencyRateText_Outdoor.text = 0 + " / " + 20;
            OccupencyRateText_School.text = 0 + " / " + 20;
        }

        foreach (RoomInfo room in roomList)
        {
            Debug.LogFormat(room.Name);
            if (room.Name.Contains(MultiplayerVRConstant.MAP_TYPE_VALUE_SCHOOL))
            {
                Debug.LogFormat("Room is a School map. Player Count is {0}", room.PlayerCount);
                OccupencyRateText_School.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstant.MAP_TYPE_VALUE_OUTDOOR))
            {
                Debug.LogFormat("Room is an Outdoor map. Player Count is {0}", room.PlayerCount);
                OccupencyRateText_Outdoor.text = room.PlayerCount + " / " + 20;
            }
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined the lobby!");
    }

    #endregion

    #region Private Methods

    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room" + mapType + "_" + Random.Range(1, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        // we have 2 different maps
        // 1. outdoor
        // 2. school
        string[] roomPropsInLobby = {MultiplayerVRConstant.MAP_TYPE_KEY};
        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable()
            {{MultiplayerVRConstant.MAP_TYPE_KEY, mapType}};
        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomOptions.CustomRoomProperties = customRoomProperties;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion
}