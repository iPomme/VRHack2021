using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject localXRRigGameObject;

    public GameObject AvatarHeadGameObject;
    public GameObject AvatarBodyGameObject;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            // the player is local
            localXRRigGameObject.SetActive(true);
            SetLayerRecursively(AvatarBodyGameObject,6);
            SetLayerRecursively(AvatarHeadGameObject,7);
            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if (teleportationAreas.Length > 0)
            {
                foreach (var item in teleportationAreas)
                {
                    item.teleportationProvider = localXRRigGameObject.GetComponent<TeleportationProvider>();
                }
            }
        }
        else
        {
            // The player is remote
            localXRRigGameObject.SetActive(false);
            SetLayerRecursively(AvatarBodyGameObject,0);
            SetLayerRecursively(AvatarHeadGameObject,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}