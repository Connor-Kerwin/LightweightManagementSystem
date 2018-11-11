﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightweightManagementSystem;

public class ScoreTest : MonoBehaviour
{
    [SerializeField]
    private int score;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ScoreManager scoreManager = CoreBehaviour.GetFirstManager<ScoreManager>();
            scoreManager.AddScore(score);
        }
    }
}