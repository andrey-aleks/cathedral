using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    public Transform _player;
    public float interactionDistance;
    public Text _text;
    public float fadeTime;
    public bool inTrigger;
    void Start()
    {
        _text.color = Color.clear;
    }

    void OnMouseEnter()
    {
        inTrigger = true;
    }

    void OnMouseExit()
    {
        inTrigger = false;
    }

    void Update()
    {
        if (_player)
        {
            Vector3 offset = _player.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            if ((sqrLen < (interactionDistance * interactionDistance)) && inTrigger == true)
            {
                _text.color = Color.Lerp(_text.color, Color.grey, fadeTime * Time.deltaTime);
            }
            else
            {
                _text.color = Color.Lerp(_text.color, Color.clear, fadeTime * Time.deltaTime);
            }
        }
    }
}
