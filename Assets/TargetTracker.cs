using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TargetTracker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private UnityEvent _onTargetChange;
    [SerializeField] private UnityEvent _onTargetsLost;

    private List<Collider> _targets = new();
    private bool _hadTargets = false;

    public Collider Target { get; private set; }

    private void FixedUpdate()
    {
        TryGetTargets();

        UpdateTargets();
    }

    private void UpdateTargets()
    {
        if (_targets.Contains(Target))
            return;
        
        if (_targets.Count != 0)
        {
            _hadTargets = true;
            Target = _targets[0];
            _onTargetChange?.Invoke();
        }
        else
        {
            if (_hadTargets == false)
                return;

            Target = null;
            _hadTargets = false;
            _onTargetsLost?.Invoke();
        }
    }

    private void TryGetTargets()
    {
        var colliders = Physics.OverlapSphere(transform.position, _radius);

        if (colliders.Contains(Target))
            return;

        _targets.Clear();

        foreach (Collider foundCollider in colliders)
        {
            if (foundCollider.TryGetComponent<ITarget>(out _))
            {
                _targets.Add(foundCollider);
            }
        }
    }
}