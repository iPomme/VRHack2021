using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPointManager : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public Transform allSoundEmitters;
    public GameObject soundPointPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform soundEmitter in allSoundEmitters)
        {
            Debug.Log("ffff-" + soundEmitter.gameObject.name);
            AudioClip newRandomClip = getRandomAudioClip();

            GameObject newSoundPoint = Instantiate(soundPointPrefab);

            newSoundPoint.transform.position = soundEmitter.position;
            newSoundPoint.GetComponent<AudioSource>().clip = newRandomClip;
            newSoundPoint.transform.SetParent(soundEmitter);
            newSoundPoint.name = "SoundPoint_" + newRandomClip.name;
            newSoundPoint.GetComponent<AudioSource>().Play();

            soundEmitter.GetComponent<MeshRenderer>().enabled = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip getRandomAudioClip()
    {
        int randomX = Random.Range(0, audioClips.Count);
        return audioClips[randomX];
    }
     
}
