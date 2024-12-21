using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* ����
 * �E�ŏ���disable�ɂ���instantiate, OnEnable�œ����n�߂�悤�ɂ���
 * �EPlayer�Ƃ̂��Ƃ�
 * �@�EisTargeting    // �^�[�Q�b�g����Ƃ��ɌĂяo��
 * �@�Evoid PositionChanged()    // �v���C���[�Ƃ̍��W�̓���ւ����N���������ɌĂяo��
 * */


public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject m_target_mark;
    [SerializeField] protected GameObject m_question_mark;
    protected float question_mark_time = 2.0f;
    protected float attack_time = 2.0f;
    protected float dead_time = 2.0f;

    protected Camera m_camera;
    public bool isTargeting = false;

    // �Ƃ肠����private
    protected int hp = 1;
    protected float speed = 1.0f;
    //private float attack = 1.0f;

    protected Rigidbody2D m_rig;
    protected Animator m_animator;

    [SerializeField] private bool _tmp_isPositionChanged = false;

    private void OnEnable()
    {
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>();//Camera.current;
        m_rig = this.GetComponent<Rigidbody2D>();
        m_animator = this.GetComponent<Animator>();
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

        // �ȉ��f�o�b�O�p
        if (_tmp_isPositionChanged)
        {
            PositionChanged();
            _tmp_isPositionChanged = false;
        }
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
    protected void AttackPlayer()
    {
        // �U���̃A�j���[�V���������s
        StartCoroutine("Attack_anim");
    }

    // ��ɍU������
    protected void AttackCastle()
    {
        // ��ɏՓ�
        // �Q�[���I�[�o�[�ɂ���H
    }

    protected void Dead()
    {
        //  ���񂾂Ƃ��̓���������ɏ���
        StartCoroutine("Dead_anim");
    }

    IEnumerator SetQuestionMark()
    {
        m_question_mark.SetActive(true);
        float tmp_speed = this.speed;
        this.speed = 0.0f;
        m_animator.SetBool("Stand", true);
        yield return new WaitForSeconds(question_mark_time);
        this.speed = tmp_speed;
        m_question_mark.SetActive(false);
        m_animator.SetBool("Stand", false);
    }

    IEnumerator Attack_anim()
    {
        m_animator.SetBool("Attack", true);
        float tmp_speed = this.speed;
        this.speed = 0.0f;
        yield return new WaitForSeconds(attack_time);
        m_animator.SetBool("Attack", false);
        this.speed = tmp_speed;
    }

    IEnumerator Dead_anim()
    {
        m_animator.SetBool("Die", true);
        yield return new WaitForSeconds(dead_time);
        // �Ƃ肠����GameObject���폜
        Destroy(this.gameObject);
    }

    // �v���C���[����̃_���[�W���󂯂�iPlayer����Ăяo���j
    protected void TakeDamage(int ap)
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

    public virtual void PositionChanged()
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
        else if (other.CompareTag("Attack"))
        {
            TakeDamage(1);
        }
        else if (other.CompareTag("Castle"))
        {
            AttackCastle();
        }
    }
}

