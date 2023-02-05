using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundWithKey : MonoBehaviour
{

    public AudioSource[] soundFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("akey"))
        {
            soundFX[0].Play();
            
        }  
        if (Input.GetButtonDown("skey"))
        {
            soundFX[1].Play();
            
        } 
        if (Input.GetButtonDown("dkey"))
        {
            soundFX[2].Play();
            
        } 
        if (Input.GetButtonDown("fkey"))
        {
            soundFX[3].Play();
            
        } 
        if (Input.GetButtonDown("jkey"))
        {
            soundFX[4].Play();
            
        }  
        if (Input.GetButtonDown("kkey"))
        {
            soundFX[5].Play();
            
        } 
        if (Input.GetButtonDown("lkey"))
        {
            soundFX[6].Play();
            
        } 
        if (Input.GetButtonDown(";key"))
        {
            soundFX[7].Play();
            
        } 
        if (Input.GetButtonDown("spaceKey"))
        {
            soundFX[8].Play();
            
        } 
    }
}
