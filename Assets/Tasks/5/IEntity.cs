using System;
using UnityEngine;

public interface IEntity
{
    bool isActive { get; }
    event Action<IEntity, bool> ActivityStatusChangedEvent;
}

public class SomeEntity1 : MonoBehaviour, IEntity
{
    public bool isActive { 
        get => gameObject.activeInHierarchy; 
        set { gameObject.SetActive(value); ActivityStatusChangedEvent?.Invoke(this, value); }
    }

    public event Action<IEntity, bool> ActivityStatusChangedEvent;

    public void Kill()
    {
        if (!isActive) return;

        isActive = false;
    }
}

public class SomeEntity2 : IEntity
{
    public bool isActive
    {
        get => _isActive;
        set { _isActive = value; ActivityStatusChangedEvent?.Invoke(this, value); }
    }

    private bool _isActive;

    public event Action<IEntity, bool> ActivityStatusChangedEvent;

    private void OnMissionCompleted()
    {
        if (!isActive) return;

        isActive = false;
    }
}