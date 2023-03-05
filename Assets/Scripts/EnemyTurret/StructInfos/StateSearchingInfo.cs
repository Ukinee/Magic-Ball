using UnityEngine;

namespace EnemyTurret.StructInfos
{
    public struct StateSearchingInfo
    {
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly Transform TurretHeadTarnsform;

        public StateSearchingInfo(Transform turretHeadTarnsform, MeshRenderer turretGunMeshRenderer)
        {
            TurretHeadTarnsform = turretHeadTarnsform;
            TurretGunMeshRenderer = turretGunMeshRenderer;
        }
    }
}