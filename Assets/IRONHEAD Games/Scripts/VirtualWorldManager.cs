using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{
    #region Photon Callback

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("The Player: {0} joined to {1}, Player counts is {2}", newPlayer.NickName,
            PhotonNetwork.CurrentRoom.Name, PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion
}