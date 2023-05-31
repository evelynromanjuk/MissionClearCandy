using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    public int GoalNumber;


    private int _currentNumber;
    private bool _reachedGoal;

    // Start is called before the first frame update
    void Start()
    {
        _currentNumber = 1;
        if(GoalNumber == 1)
        {
            _reachedGoal = true;
        }
        else
        {
            _reachedGoal = false;
        }
    }

    public void AddNumber()
    {
        _currentNumber++;
        if(_currentNumber > 9)
        {
            _currentNumber = 0;
        }
        Debug.Log(this + " number: " + _currentNumber);
        CompareValues();
    }

    private void CompareValues()
    {
        if(_currentNumber == GoalNumber)
        {
            _reachedGoal = true;
        }
        else
        {
            _reachedGoal = false;
        }
    }

    public bool IsCorrect()
    {
        return _reachedGoal;
    }
}
