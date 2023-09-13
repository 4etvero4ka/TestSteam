using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpawningTargets : MonoBehaviour
{
    [SerializeField] private SteamVR_Input_Sources handType;
    [SerializeField] private SteamVR_Action_Boolean SpawnTarget;
    [Header("SpawnSet")]
    [SerializeField] private List<GameObject> Targets;
    [SerializeField] private List<Transform> Positions;

    private List<Transform> spawnedTargets = new List<Transform>();

    void Update()
    {
        if (SpawnTarget.GetStateDown(handType))
        {
            SpawnTargets();
        }
    }

    void SpawnTargets()
    {
        List<int> availableIndices = new List<int>(); 

        for (int i = 0; i < Positions.Count; i++)
        {
            availableIndices.Add(i);
        }

        for (int i = 0; i < 4; i++) 
        {
            int randomIndex = Random.Range(0, availableIndices.Count);
            int positionIndex = availableIndices[randomIndex];
            availableIndices.RemoveAt(randomIndex);

            int randomTargetIndex = Random.Range(0, Targets.Count);

            GameObject target = Instantiate(Targets[randomTargetIndex], Positions[positionIndex].position, Positions[positionIndex].rotation);
        }
    }
}