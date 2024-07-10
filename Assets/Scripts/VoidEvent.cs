using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

[CreateAssetMenu(menuName = "Events/VoidEvent", fileName = "newVoidEvent")]

public class VoidEvent : ScriptableObject
{
    public Action _action;

    public void AddListener(Action action)
    {
        _action += action;
    }

    public void RemoveListener(Action action)
    {
        _action -= action;
    }

    public void Raise()
    {
        _action?.Invoke();
    }

}
