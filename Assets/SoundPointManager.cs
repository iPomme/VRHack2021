using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundPointManager : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public Transform allSoundEmitters;
    public GameObject soundPointPrefab;

    
    public static List<T> GetRandomElements<T>(IEnumerable<T> list, int elementsCount)
    {
        return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
    }
    // Start is called before the first frame update
    void Start()
    {
        int halfOfEmmiter = allSoundEmitters.childCount / 2;
        List<Transform> allSoundList = allSoundEmitters.GetComponentsInChildren<Transform>().ToList();
        allSoundList.RemoveAt(0);
        List<Transform> randomEmitter = GetRandomElements(allSoundList, allSoundEmitters.childCount);
        List<AudioClip> audioClipList = audioClips.ToList();
        List<AudioClip> randomSound = GetRandomElements(audioClipList, halfOfEmmiter);
        for (int i = 0; i < halfOfEmmiter ; i ++)
        {
            AudioClip newRandomClip = audioClipList[i];

            GameObject newSoundPoint = Instantiate(soundPointPrefab);

            Transform soundEmitter1 = randomEmitter[i*2];
            newSoundPoint.transform.position = soundEmitter1.position;
            newSoundPoint.GetComponent<AudioSource>().clip = newRandomClip;
            newSoundPoint.transform.SetParent(soundEmitter1);
            newSoundPoint.name = "SoundPoint1_" + newRandomClip.name;
            newSoundPoint.GetComponent<AudioSource>().Play();
            soundEmitter1.GetComponent<MeshRenderer>().enabled = false;
            
            GameObject newSoundPoint1 = Instantiate(soundPointPrefab);
            Transform soundEmitter2 = randomEmitter[(i*2)+1];
            newSoundPoint1.transform.position = soundEmitter2.position;
            newSoundPoint1.GetComponent<AudioSource>().clip = newRandomClip;
            newSoundPoint1.transform.SetParent(soundEmitter2);
            newSoundPoint1.name = "SoundPoint2_" + newRandomClip.name;
            newSoundPoint1.GetComponent<AudioSource>().Play();
            soundEmitter1.GetComponent<MeshRenderer>().enabled = false;
            
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
