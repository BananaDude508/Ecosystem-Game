using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public string goalType;
    public int amount;

    /// <summary>
    /// Returns a randomly generated goal
    /// </summary>
    public Goal()
    {
        int goalTypeIndex = Random.Range(0, 6);
        switch (goalTypeIndex)
        {
            case 0:
                goalType = "money";
                break;
            case 1:
                goalType = "wheat";
                break;
            case 2:
                goalType = "tomato";
                break;
            case 3:
                goalType = "potato";
                break;
            case 4:
                goalType = "carrot";
                break;
            case 5:
                goalType = "scarecrow";
                break;
            default:
                goalType = "error";
                break;
        }
        if (goalType == "money")
            amount = Random.Range(100, 501);
        else
            amount = Random.Range(5, 16);
    }

    /// <summary>
    /// Returns a goal using set goal params
    /// </summary>
    /// <param name="goalType">What the goal should be</param>
    /// <param name="amount">How much you need (redundant with goalType="scarecrow")</param>
    public Goal(string goalType, int amount)
    {
        this.goalType = goalType;
        this.amount = amount;
    }

    public override string ToString()
    {
        switch (goalType)
        {
            case "money":
                return $"Get another ${amount}";
            case "wheat":
                return $"Get {amount} more {goalType}";
            case "tomato":
            case "potato":
            case "carrot":
                return $"Get {amount} more {goalType}s";
            case "scarecrow":
                return $"Place a scarecrow";
            default:
                return "NOT A VALID GOAL";
        }
    }
}
