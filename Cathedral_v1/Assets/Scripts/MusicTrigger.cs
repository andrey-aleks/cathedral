using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    private bool playing;

    void Start()
    {
        playing = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && playing == false)
        {
            FindObjectOfType<AudioManagerScript>().Play("indoorMusic");
            playing = true;
        }
    }
}
