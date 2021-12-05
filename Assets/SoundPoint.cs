using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPoint : MonoBehaviour
{
    public TextMesh textMesh;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        // AudioClip clipp = Resources.Load("sounds/synth") as AudioClip;
        // audio.clip = clipp;
        textMesh.text = audio.clip.name;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
