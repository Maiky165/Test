using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public GameObject levelSegment;
    public List<GameObject> activeLevelSegments;
    public float levelSpeed = 3f;


    void Start()
    {
        activeLevelSegments.Add(Instantiate(levelSegment, new Vector3(0, 0, 0), Quaternion.identity));
    }


    void Update()
    {
        MoveLevelSegments();
        DestroyLevelSegments();
        InstantiateLevelSegments();
    }

    // ich war hier

    private void MoveLevelSegments()
    {
        for (int i = 0; i < activeLevelSegments.Count; i++)
        {
            activeLevelSegments[i].transform.position -= new Vector3(levelSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void DestroyLevelSegments()
    {
        for (int i = 0; i < activeLevelSegments.Count; i++)
        {
            if (activeLevelSegments[i].transform.position.x <= -55f)
            {
                GameObject temp = activeLevelSegments[i];
                activeLevelSegments.RemoveAt(i);
                Destroy(temp);
            } 
        }
    }

    private void InstantiateLevelSegments()
    {
        bool levelSegmentsReachScreenEnd = true;

        for (int i = 0; i < activeLevelSegments.Count; i++)
        {
            if (activeLevelSegments[i].transform.position.x > -17f) levelSegmentsReachScreenEnd = false;
        }

        if (levelSegmentsReachScreenEnd) activeLevelSegments.Add(Instantiate(levelSegment, new Vector3(52, 0, 0), Quaternion.identity));
    }
}
