using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Shooting
{
    public class ShootingManager : MonoBehaviour
    {
        public void Shoot(Vector3 from,Vector3 dir)
        {
            RaycastHit hit;
            bool rayHit = Physics.Raycast(from, dir, out hit, Mathf.Infinity);
            Debug.DrawLine(from, transform.position + dir * 20, Color.red, 3);
            if(rayHit)
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}