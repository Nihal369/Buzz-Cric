﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    static int numberOfOvers, numberOfBalls, totalRuns, wicketsGone, striker, nonStriker,nextBatsman,strikerRuns,nonStrikerRuns;
    int nextBallScore;
    public Text ballDisplay,strikerDisplay,nonStrikerDisplay,overDisplay,runDisplayText;

	// Use this for initialization
	void Start () {
        numberOfOvers = 0;
        numberOfBalls = 0;
        totalRuns = 0;
        strikerRuns = 0;
        nonStrikerRuns = 0;
        wicketsGone = 0;
        striker = 1;
        nonStriker = 2;
        nextBatsman = 3;
	}

    // Update is called once per frame
    void Update()
    {
        overDisplay.text = "OVERS " + numberOfOvers + "." + numberOfBalls;
        runDisplayText.text = "IND " + totalRuns + "/" + wicketsGone;
        strikerDisplay.text = "Batsman" + striker + " " + strikerRuns;
        nonStrikerDisplay.text = "Batsman" + nonStriker + " " + nonStrikerRuns;
    }


    public void nextBall()
    {
        //Generate runs between 0-6(5 is given as wicket)
        nextBallScore = Random.RandomRange(0, 7);
        if (nextBallScore != 5)
        {
            scoreRun();
        }
        else
        {
            wicketFall();
        }
        numberOfBalls++;

        //Check for an over
        calculateOvers();
    }

    void calculateOvers()
    {
        if (numberOfBalls == 6)
        {
            //End of one over
            numberOfOvers++;
            numberOfBalls = 0;
            //Strike Rotation
            int swap = striker;
            striker = nonStriker;
            nonStriker = swap;
            swap = strikerRuns;
            strikerRuns = nonStrikerRuns;
            nonStrikerRuns = swap;
        }
    }

    void wicketFall()
    {
        ballDisplay.text = "W";
        wicketsGone++;
        striker = nextBatsman;
        nextBatsman++;
        strikerRuns = 0;
    }

    void scoreRun()
    {
        //Set main display to runs scored in this ball
        ballDisplay.text = nextBallScore.ToString();
        //Increment strikers runs
        strikerRuns += nextBallScore;
        //Increment total score by the runs scored in this ball
        totalRuns += nextBallScore;
    }
}