using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* ����
 * �E�ŏ���disable�ɂ���instantiate, OnEnable�œ����n�߂�悤�ɂ���
 * �EPlayer�Ƃ̂��Ƃ�
 * �@�Ebool Targeting()    // �^�[�Q�b�g����Ƃ��ɌĂяo��
 * �@�Evoid TakeDamage()    // �v���C���[���U���A�N�V�������������ɌĂяo��
 * �@�Evoid PositionChanged()    // �v���C���[�Ƃ̍��W�̓���ւ����N���������ɌĂяo��
 * */


public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject m_target_mark;
    [SerializeField] protected GameObject m_question_mark;
    private float question_mark_time = 2.0f;

    protected Camera m_camera;
    public bool isTargeting = false;

    // �Ƃ肠����private
    private int hp = 1;
    private float speed = 1.0f;
    //private float attack = 1.0f;

    protected Rigidbody2D m_rig;


    private void OnEnable()
    {
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>();//Camera.current;
        m_rig = this.GetComponent<Rigidbody2D>();
        Spawn();
    }

    // Start is called before the first frame update
    void Start()
    {
        // do nothing
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Targeting();
        Debug.Log("hello");
    }

    // �I�u�W�F�N�g�𐶐������Ƃ��̏���
    // OnEnable()����Ăяo��
    protected virtual void Spawn()
    {
        // �X�|�[���̏ꏊ���w��
        Vector2 spawnPosition = m_camera.ViewportToWorldPoint(new Vector2(1.0f, 0.5f));
        m_rig.transform.position = spawnPosition;
    }

    protected virtual void Move()
    {
        // �ЂƂ܂����W�𒼐ڍX�V��������ɂ���
        m_rig.position += new Vector2(-speed * Time.deltaTime, 0);
    }

    // �v���C���[�ɃA�^�b�N����
    // �v���C���[������̔�_���̓v���C���[���g�Ŋ������邽�߁A�A�^�b�N�̃��[�V�����������s����
    private void AttackPlayer()
    {
        // �U���̃A�j���[�V���������s
        Dead();    // ��Udead�ɂ���
    }

    // ��ɍU������
    private void AttackCastle()
    {
        // ��ɏՓ�
        // �Q�[���I�[�o�[�ɂ���H
    }

    private void Dead()
    {
        //  ���񂾂Ƃ��̓���������ɏ���

        // �Ƃ肠����GameObject���폜
        Destroy(this.gameObject);
    }

    IEnumerator SetQuestionMark()
    {
        m_question_mark.SetActive(true);
        yield return new WaitForSeconds(question_mark_time);
        m_question_mark.SetActive(false);
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

    // �^�[�Q�b�g���ꂽ���ɌĂ΂��
    public void Targeting()
    {
        if (isTargeting && !m_target_mark.activeSelf)
        {
            m_target_mark.SetActive(true);
        }
        else if (!isTargeting && m_target_mark.activeSelf)
        {
            m_target_mark.SetActive(false);
        }
    }

    public void PositionChanged()
    {
        // ���W������ւ�������̂͂Ăȃ}�[�N
        StartCoroutine("SetQuestionMark");
    }



    // �Փˑ���̔����Tag��
    // Player or Castle
    public void OnCollisionEnter2D(Collision2D collision)
    {

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

