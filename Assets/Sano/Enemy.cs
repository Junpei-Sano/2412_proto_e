using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �Ƃ肠����private
    private int hp = 1;
    private float speed = 1.0f;
    private float attack = 1.0f;

    // True�̊ԃ^�[�Q�b�g����Ă���}�[�N��\������悤�ɂ���
    public bool isTargeting = false;

    private Rigidbody2D m_rig;


    // Start is called before the first frame update
    void Start()
    {
        m_rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // �ЂƂ܂����W�𒼐ڍX�V��������ɂ���
        m_rig.position += new Vector2(-speed * Time.deltaTime, 0);
    }

    // �v���C���[����̃_���[�W���󂯂�
    public void TakeDamage(int ap)
    {

    
    }
}
