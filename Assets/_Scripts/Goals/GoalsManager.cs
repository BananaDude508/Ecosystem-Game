using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static PlayerInventory;

public class GoalsManager : MonoBehaviour
{
    public static Goal currentGoal;
    public TextMeshProUGUI goalText;

    public int originalGoalCount;

    private void Awake()
    {
        if (currentGoal == null) StartNewGoal();
    }

    private void Update()
    {
        if (IsGoalCompleted())
        {
            StartNewGoal();
            money += Random.Range(20, 51) * 10;
        }
    }

    public void StartNewGoal()
    {
        currentGoal = new Goal();
        goalText.text = currentGoal.ToString();
        print(goalText.text);

        if (currentGoal.goalType == "money")
            originalGoalCount = money;
        else
            originalGoalCount = items[currentGoal.goalType].amount;
    }

    public bool IsGoalCompleted()
    {
        if (currentGoal.goalType == "money")
            return (originalGoalCount + currentGoal.amount) < money;
        else
            return (originalGoalCount + currentGoal.amount) < items[currentGoal.goalType].amount;
    }
}


