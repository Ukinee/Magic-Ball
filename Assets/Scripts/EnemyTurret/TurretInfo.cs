using System;
using System.Collections;
using System.Collections.Generic;
using EnemyTurret;
using EnemyTurret.StructInfos;
using UnityEngine;
using UnityEngine.Serialization;

public class TurretInfo : MonoBehaviour
{
    [SerializeField] private TargetTracker _targetTracker;
    [SerializeField] private MeshRenderer _gunMeshRenderer;
    [SerializeField] private ParticleSystem _shootingParticleSystem;
    [SerializeField] private Transform _turretGunTarnsform;
    [SerializeField] private Transform _turretHeadTransform;

    public StateAggresiveInfo StateAggresiveInfo = new();

    private void Awake()
    {
        StateAggresiveInfo = new StateAggresiveInfo(
            _shootingParticleSystem, 
            _turretGunTarnsform, 
            _turretHeadTransform,
            _gunMeshRenderer, 
            _targetTracker);
    }
}