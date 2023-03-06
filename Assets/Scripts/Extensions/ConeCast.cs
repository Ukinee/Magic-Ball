using System;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public class ConeCast
    {
        public static Collider[] ConeCastAll(Vector3 origin, float maxRadius, Vector3 direction, float coneAngle)
        {
            var sphereCastHits = Physics.SphereCastAll(
                origin - direction.normalized * maxRadius,
                maxRadius,
                direction,
                maxRadius); // магическая 2, пока хз откуда она

            if (sphereCastHits.Length == 0)
                return Array.Empty<Collider>();

            var coneCastHitList = new List<Collider>();

            foreach (RaycastHit raycastHit in sphereCastHits)
            {
                Vector3 directionToHit = raycastHit.point - origin;
                var angleToHit = Vector3.Angle(direction, directionToHit);

                if (angleToHit < coneAngle)
                {
                    coneCastHitList.Add(raycastHit.collider);
                }
            }

            return coneCastHitList.ToArray();
        }
    }
}