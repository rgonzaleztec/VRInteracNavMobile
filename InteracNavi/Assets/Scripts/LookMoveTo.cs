using System.Collections;
using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    float speed = 3.0f;

    public float lookangledown = 25.0f;

    public Transform vrPlayer;

    public bool moveForward;

    private CharacterController _miCC;

    // Start is called before the first frame update
    void Start()
    {
        _miCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        
    }

    void Mover()
    {
        if (vrPlayer.eulerAngles.x >= lookangledown && vrPlayer.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }

        if (moveForward)
        {
            Vector3 _forward = vrPlayer.TransformDirection(Vector3.forward);
            _miCC.SimpleMove(_forward * speed);
        }
    }
}
