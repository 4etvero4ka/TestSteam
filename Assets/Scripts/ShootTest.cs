using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ShootTest : MonoBehaviour
{
    private Interactable interactable;
    [SerializeField] private SteamVR_Action_Boolean fireAction;
    [SerializeField] private Transform tran;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (fireAction[source].stateDown)
            {
                Shoot();
            }

        }
    }
    void Shoot()
    {
            int layerMask = 1 << 7;
            layerMask = ~layerMask;
            Ray ray = new Ray(tran.position, tran.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("Hit in " + hit.transform.name);
                
            }
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.5f);
    }

}
