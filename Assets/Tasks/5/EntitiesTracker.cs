using System.Collections.Generic;
using UnityEngine;

public class EntitiesTracker : MonoBehaviour
{
    private HashSet<IEntity> _entities = new();
    private HashSet<IEntity> _activeEntities = new();

    public IEnumerable<IEntity> GetActiveEntities() => _activeEntities; // Без создания нового перечисления. Не безопасно так как можно закастить обратно к хэшу и что то с ним сделать
    // Но думаю тут это не критично

    public void Register(IEntity entity) 
    {
        if (_entities.Contains(entity)) return;

        _entities.Add(entity);

        if (entity.isActive) _activeEntities.Add(entity);

        entity.ActivityStatusChangedEvent += OnActivityStatusChanged;
    }


    public void Unregister(IEntity entity)
    {
        if (!_entities.Contains(entity)) return;

        _entities.Remove(entity);
        _activeEntities.Remove(entity);

        entity.ActivityStatusChangedEvent -= OnActivityStatusChanged;
    }

    private void OnActivityStatusChanged(IEntity entity, bool status)
    {
        if (status)
            _activeEntities.Add(entity);
        else
            _activeEntities.Remove(entity);
    }

    private void OnDestroy()
    {
        if (_entities == null) return;

        foreach (var entity in _entities) 
            if (entity != null)
                entity.ActivityStatusChangedEvent -= OnActivityStatusChanged;
    }
}