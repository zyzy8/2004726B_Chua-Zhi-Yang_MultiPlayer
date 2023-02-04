using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    //Aesthetic enhancement: Sound
    //The object this script is attached to, which is an Audio Source object has an audio clip which we will play.
    //We play the sound by having the buttons in the scenes call the AudioSource.PlayOneShot function on the assigned
    //Audio Source object, which is what this script is attached to.

    // Start is called before the first frame update
    void Start()
    {
        //Set to dont destroy on load so that the sound that plays will not abruptly stop upon entering the next scene
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
