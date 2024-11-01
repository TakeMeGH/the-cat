using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace TC
{
    public class MCController : MonoBehaviour
    {
        public float GroundDistance;
        public LayerMask TerrainLayyer;
        Rigidbody _rb;
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            RaycastHit hit;
            Vector3 castPos = transform.position;
            castPos.y += 1;
            if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, TerrainLayyer))
            {
                if (hit.collider != null)
                {
                    Vector3 movePos = transform.position;
                    movePos.y = hit.point.y + GroundDistance;
                    transform.position = movePos;
                }
            }

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("vertical");
            Vector3 moveDir = new Vector3(x, 0, y);
            _rb.velocity = new Vector3(x, 0, y);
        }
    }
}
