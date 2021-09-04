using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject _gameObject;
    public bool _inTrigger;
    public bool _isActive;
    public Transform _player;
    public float interactionDistance;

        private void Start()
    {
        _inTrigger = false;
        _isActive = true;
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
            _isActive = !_isActive;
            _gameObject.SetActive(_isActive);
        }
    }
}
