using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by Pavlos Mavris.
/// This script will handle the checkpoint system and will be responsible to save and load
/// the last checkpoint that the player has passed through.
/// Check the tutorial for more explanation at https://youtu.be/2VBr2ShkXAY
/// </summary>

public class CheckpointController : MonoBehaviour
{
    [SerializeField] private GameObject _checkpointsParent;
    public GameObject[] _checkPointsArray;
    private Vector3 _startingPoint;
    
    //todo Uncomment this code if you have a rigidbody on your player and you want to stop it from moving
    // private Rigidbody _rigidbody;

    private const string SAVE_CHECKPOINT_INDEX = "Last_checkpoint_index";

    private void Awake()
    {
        /* Uncomment this code if you have a rigidbody on your player and you want to stop it from moving
           We set the "_rigidbody" variable with the actual Rigidbody component of the player.*/
        // _rigidbody = GetComponent<Rigidbody>();          

        LoadCheckpoints();
    }

    void Start()
    {
        int savedCheckpointIndex = -1;
        savedCheckpointIndex = PlayerPrefs.GetInt(SAVE_CHECKPOINT_INDEX, -1);
        if (savedCheckpointIndex != -1)
        {
            _startingPoint = _checkPointsArray[savedCheckpointIndex].transform.position;
        }
        else
        {
            _startingPoint = gameObject.transform.position;
        }
        
        RespawnPlayer();
    }

    void Update()
    {
        if(transform.position.y <= -10f)                // We check the position of the player at the Y axis  
        {
            RespawnPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            int checkPointIndex = -1;
            checkPointIndex = Array.FindIndex(_checkPointsArray, match => match == other.gameObject);

            if (checkPointIndex != -1)
            {
                PlayerPrefs.SetInt(SAVE_CHECKPOINT_INDEX,checkPointIndex);
                _startingPoint = other.gameObject.transform.position;
                other.gameObject.SetActive(false);
            }
        }
    }

   
    public void RespawnPlayer()
    {
        gameObject.transform.position = _startingPoint;
        
        //todo Uncomment this code if you have a rigidbody on your player and you want to stop it from moving
        // _rigidbody.velocity = Vector3.zero;
        // _rigidbody.angularVelocity = Vector3.zero;
    }

    private void LoadCheckpoints()
    {
        _checkPointsArray = new GameObject[_checkpointsParent.transform.childCount];

        int index = 0;

        foreach (Transform singleCheckpoint in _checkpointsParent.transform)
        {
            _checkPointsArray[index] = singleCheckpoint.gameObject;
            index++;
        }
    }
}
