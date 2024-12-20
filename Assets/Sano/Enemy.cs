using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    // �Ƃ肠����private
    private int hp = 1;
    private float speed = 1.0f;
    private float attack = 1.0f;

    // �X�|�[���̏ꏊ
    protected Vector2 spawnPosition;

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

    private void SetSpawnPosition()
    {
        //
    }

    public void Spawn()
    {
        // �I�u�W�F�N�g�𐶐������Ƃ��̏���
        // instantiate���̂�manager����Ăяo���H
    }

    private void Move()
    {
        // �ЂƂ܂����W�𒼐ڍX�V��������ɂ���
        m_rig.position += new Vector2(-speed * Time.deltaTime, 0);
    }

    // �v���C���[�ɃA�^�b�N����
    // �v���C���[������̔�_���̓v���C���[���g�Ŋ������邽�߁A�A�^�b�N�̃��[�V�����������s����
    private void AttackPlayer()
    {
        
    }

    // ��ɍU������
    private void AttackCastle()
    {
        // ��ɏՓ�
        // �Q�[���I�[�o�[
    }

    // �v���C���[����̃_���[�W���󂯂�
    public void TakeDamage(int ap)
    {
        // ��������
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փˎ��̓���

        GameObject opponent = collision.gameObject;    // �Փˑ�����擾
        if (true)    // ���ƂŏՓˑ��肪�v���C���[���𔻒肷�����������
        {
            AttackPlayer();
        }
        else if (true)    // ���ƂŏՓˑ��肪�邩�𔻒肷�����������
        {
            AttackCastle();
        }
    }
}
