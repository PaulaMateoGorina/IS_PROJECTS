using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip correct;
    public AudioClip dig_clay;
    public AudioClip finished_building;
    public AudioClip gameplay_bg;
    public AudioClip get_material;
    public AudioClip incorrect;
    public AudioClip intro_music;
    public AudioClip stone_mining;
    public AudioClip water_in_bucket;
    public AudioClip wood_choping;

    private Vector3 cameraPosition;

    // Start is called before the first frame update

    //We use awake because it runs before start. If we wanted to reference the singleton in start
    //we would have troubles otherwise.
    void Awake()
    {
        Instance = this;
        cameraPosition = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void PlaySound(AudioClip clip){
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayCorrect()
    {
        PlaySound(correct);
    }

    public void PlayDigClay()
    {
        PlaySound(dig_clay);
    }

    public void PlayFinishedBuilding()
    {
        PlaySound(finished_building);
    }

    public void PlayGameplayBg()
    {
        PlaySound(gameplay_bg);
    }

    public void PlayGetMaterial()
    {
        PlaySound(get_material);
    }

    public void PlayIncorrect()
    {
        PlaySound(incorrect);
    }

    public void PlayIntroMusic()
    {
        PlaySound(intro_music);
    }

    public void PlayStoneMining()
    {
        PlaySound(stone_mining);
    }

    public void PlayWaterInBucket()
    {
        PlaySound(water_in_bucket);
    }

    public void PlayWoodChopping()
    {
        PlaySound(wood_choping);
    }


}
