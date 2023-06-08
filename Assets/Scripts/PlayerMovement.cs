using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class PlayerMovement : MonoBehaviour
{   
    [SerializeField]
    private SteamVR_Action_Vector2 _input;
    [SerializeField]
    private float _speed;
    private CharacterController CharacterController;

    private void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_input.axis.magnitude > 0.1f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(_input.axis.x, 0, _input.axis.y));
            CharacterController.Move(Time.deltaTime * _speed * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
        }
    }
}
