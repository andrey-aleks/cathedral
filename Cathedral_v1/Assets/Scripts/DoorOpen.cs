using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator _animator;
    private bool _inTrigger = false;
    private bool _isOpen = false;
    public Transform _player;
    public float interactionDistance;
    public bool playSound;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        _inTrigger = true;
    }

    void OnMouseExit()
    {
        _inTrigger = false;
    }

    public bool distanceCheck()
    {
        Vector3 offset = _player.position - transform.position;
        float sqrLen = offset.sqrMagnitude;
        if ((sqrLen < interactionDistance * interactionDistance) && _inTrigger == true)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if (_inTrigger && Input.GetKeyDown(KeyCode.E) && distanceCheck())
        {
            _animator.SetTrigger("open");
            if (playSound)
            {
                if (_isOpen == false)
                {
                    FindObjectOfType<AudioManagerScript>().Play("doorOpen");
                    _isOpen = true;
                }
                else
                {
                    FindObjectOfType<AudioManagerScript>().Play("doorClose");
                    _isOpen = false;
                }
            }
        }
    }
}
