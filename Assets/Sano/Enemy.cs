using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* ����
 * �E�ŏ���disable�ɂ���instantiate, OnEnable�œ����n�߂�悤�ɂ���
 * 
 * */


public class Enemy : MonoBehaviour
{
    [SerializeField] private Camera m_camera;

    // �Ƃ肠����private
    private int hp = 1;
    private float speed = 1.0f;
    private float attack = 1.0f;


    // True�̊ԃ^�[�Q�b�g����Ă���}�[�N��\������悤�ɂ���
    public bool isTargeting = false;

    private bool isAttacked = false;    // true�̊ԓG�ƏՓ˂��Ă�AttackPlayer���Ă΂Ȃ�
    private Rigidbody2D m_rig;


    private void OnEnable()
    {
        Spawn();
    }

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

    // �I�u�W�F�N�g�𐶐������Ƃ��̏���
    // OnEnable()����Ăяo��
    protected virtual void Spawn()
    {
        // �X�|�[���̏ꏊ���w��
        Vector2 spawnPosition = m_camera.ViewportToWorldPoint(new Vector2(1.0f, 0.5f));
        m_rig.transform.position = spawnPosition;
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
        // �U���̃A�j���[�V����
    }

    // ��ɍU������
    private void AttackCastle()
    {
        // ��ɏՓ�
        // �Q�[���I�[�o�[�ɂ���H
    }

    // �v���C���[����̃_���[�W���󂯂�iPlayer����Ăяo���j
    public void TakeDamage(int ap)
    {
        this.hp -= ap;
        if (this.hp <= 0)
        {
            this.hp = 0;
            Dead();
        }
    }

    public void Dead()
    {
        //  ���񂾂Ƃ��̓���������ɏ���

        // �Ƃ肠����GameObject���폜
        Destroy(this.gameObject);
    }

    // �Փˑ���̔����Tag��
    // Player or Castle
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փˎ��̓���

        GameObject opponent = collision.gameObject;    // �Փˑ�����擾
        Collider2D other = opponent.GetComponent<Collider2D>();

        if (other.CompareTag("Player"))
        {
            AttackPlayer();
        }
        else if (other.CompareTag("Castle"))
        {
            AttackCastle();
        }
    }
}
