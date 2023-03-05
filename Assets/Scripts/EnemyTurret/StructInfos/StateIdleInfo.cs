using UnityEngine;

namespace EnemyTurret.StructInfos
{
    public struct StateIdleInfo
    {
        public readonly MeshRenderer TurretGunMeshRenderer;
        public readonly Transform TurretGunTarnsform;

        public StateIdleInfo(
            MeshRenderer turretGunMeshRenderer, 
            Transform turretGunTarnsform)
        {
            TurretGunMeshRenderer = turretGunMeshRenderer;
            TurretGunTarnsform = turretGunTarnsform;
        }
    }
}