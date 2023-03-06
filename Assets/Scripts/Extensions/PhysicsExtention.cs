using System;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public class PhysicsExtention
    {
        public static Collider[] ConeOverlap(List<Collider> colliders, Vector3 position, Vector3 direction, float coneAngle)
        {
            if (colliders.Count == 0)
                return Array.Empty<Collider>();
            
            var coneCastHitList = new List<Collider>();

            foreach (Collider collider in colliders)
            {
                Vector3 directionToHit = collider.transform.position - position;
                var angleToHit = Vector3.Angle(direction, directionToHit);
                
                if (angleToHit < coneAngle)
                {
                    coneCastHitList.Add(collider);
                }
            }

            return coneCastHitList.ToArray();
        }
    }
}