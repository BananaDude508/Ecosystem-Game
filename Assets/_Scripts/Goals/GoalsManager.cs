using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static PlayerInventory;
using static AllPlantsManager;

public class GoalsManager : MonoBehaviour
{
    public TextMeshProUGUI goalText;

    public static int goalCount;

    private void Start()
    {
        if (currentGoal == null) StartNewGoal();
    }

    private void Update()
    {
        goalText.text = currentGoal.ToString();

        UpdateGoalProgress();
    }

    public void StartNewGoal()
    {
        currentGoal = new Goal();

        if (currentGoal.goalType == "money")
            goalCount = money;
        else if (currentGoal.goalType == "scarecrow" && scarecrowPlaced)
            StartNewGoal();
        else
            goalCount = items[currentGoal.goalType].amount;
    }

    public void UpdateGoalProgress()
    {
       
        if (currentGoal.goalType == "money")
        {
            currentGoal.amount += goalCount - money;
            goalCount = money;
        }
        else if (currentGoal.goalType == "scarecrow")
        {
            currentGoal.amount = scarecrowPlaced ? 0 : 1;
        }
        else
        {
            currentGoal.amount += goalCount - items[currentGoal.goalType].amount;
            goalCount = items[currentGoal.goalType].amount;
        }

        if (currentGoal.amount <= 0)
        {
            StartNewGoal();
            money += Random.Range(20, 51) * 10;
        }
    }
}


