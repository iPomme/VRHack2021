using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalPlayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject GoHome_Button;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GoHome_Button.GetComponent<Button>();
        button.onClick.AddListener(VirtualWorldManager.instance.LeaveRoomAndLoadHomeScene);
    }

    // Update is called once per frame
    void Update()
    {
    }
}