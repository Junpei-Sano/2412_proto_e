using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �G���G
public class Dragon : Enemy
{
    protected override void Move()
    {
        // �����g�̂悤�ɓ���

        //Mathf.PingPong(Time.time, 0.3f);


    }

    protected override void Spawn()
    {
        Vector2 spawnPosition = m_camera.ViewportToWorldPoint(new Vector2(1.0f, 0.8f));
        m_rig.transform.position = spawnPosition;
    }
}
