using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levelSegments;          //list of all segment prefabs
    public List<GameObject> activeLevelSegments;    //list of all active level segments
    public float levelSpeed = 3f;                   //start speed of the level segments
    private float currentSpeed;                     //current speed of the level segments  
    public float speedIncreaseRate = 0.05f;         //the rate at which the speed of the level segments gets increased            
    public bool active = true;                      //if true the LevelManager runs




    void Update()
    {
        if (active == false) return;

        MoveLevelSegments();                
        DestroyOffCameraLevelSegments();
        InitiateNextLevelSegment();         //initiates the next level segment if necessary

        currentSpeed += speedIncreaseRate * Time.deltaTime;  //increases the speed of the level segments

    }

    // ich war hier



    //moves the level segments
    private void MoveLevelSegments()
    {
        for (int i = 0; i < activeLevelSegments.Count; i++)
        {
            activeLevelSegments[i].transform.position -= new Vector3(currentSpeed * Time.deltaTime, 0, 0);
        } 
    }

    //destroys all level segment that left the camera view behind the player
    private void DestroyOffCameraLevelSegments()
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

    //initiates a new level segment ahead of the camera if the last level segment is about to not cover the camera view anymore
    private void InitiateNextLevelSegment()
    {
        //checks if the current level segment is about to reach the end of the camera view
        bool levelSegmentsReachedScreenEnd = true;

        for (int i = activeLevelSegments.Count; i > 0; i--)
        {
            if (activeLevelSegments[activeLevelSegments.Count - i].transform.position.x > -17f) levelSegmentsReachedScreenEnd = false;
        }

        //chooses and initiates the next level segment
        int nextLevel = Random.Range(0, levelSegments.Count);
        if (levelSegmentsReachedScreenEnd) activeLevelSegments.Add(Instantiate(levelSegments[nextLevel], new Vector3(52, 0, 0), Quaternion.identity));
    }

    //to be called when starting a game
    public void Initiate()
    {
        //destroys all active level segments and removes them from activeLevelSegments
        for (int i = activeLevelSegments.Count; i > 0; i--)
        {
            GameObject temp = activeLevelSegments[0];
            activeLevelSegments.RemoveAt(0);
            Destroy(temp);
        }

        activeLevelSegments.Add(Instantiate(levelSegments[0], new Vector3(0, 0, 0), Quaternion.identity));

        currentSpeed = levelSpeed;
    }

    public void SetActive(bool pActive)
    {
        active = pActive;
    }
}
