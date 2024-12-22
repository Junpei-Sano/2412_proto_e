using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    // ���X�g�̗v�f�̃C���f�b�N�X�͂��ꂼ��̃I�u�W�F�N�g�ɑΉ�
    // ��Œ�������

    [SerializeField] private float enemy_min_time_span;
    // �G�L�����̃C���X�^���X������
    [SerializeField] private List<GameObject> enemyList;
    // ���ꂼ��̓G�L�����̐����m��������i���v1�𒴂��Ȃ��悤�ɁA1�����̕��͐������Ȃ������j
    [SerializeField] private List<float> enemy_ratio_first;
    // �G�L�����̍ŏI�I�Ȑ����m��
    [SerializeField] private List<float> enemy_ratio_finish;
    // ���ꂼ��̃L�����̃X�|�[���ʒu
    [SerializeField] private List<Vector2> ground_spawn_position;

    private List<float> enemy_ratio_diff = new List<float>();
    private float remaining_time = 60.0f;    // ���ƂłȂ�Ƃ�����
    private float start_time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        // �ŏ��Ɉ�̂����S�u�����𐶐�
        Instantiate(enemyList[0], ground_spawn_position[0], Quaternion.identity);

        for (int i = 0; i <  enemyList.Count; i++) 
        {
            float diff = (enemy_ratio_finish[i] - enemy_ratio_first[i]) / remaining_time;
            enemy_ratio_diff.Add(diff);
        }
        start_time = Time.time;

        StartCoroutine("Spawn_Enemies");
    }

    IEnumerator Spawn_Enemies()
    {
        while (true)
        {
            // �����_���œG�𐶐�
            GameObject enemy = null;
            Vector2 spawn_position = Vector2.zero;
            float rand = Random.Range(0.0f, 1.0f);
            float ratio_sum = 0.0f;
            for (int i = 0; i < enemyList.Count; i++)
            {
                ratio_sum += enemy_ratio_first[i];
                if (rand < ratio_sum)
                {
                    enemy = enemyList[i];
                    spawn_position = ground_spawn_position[i];
                    break;
                }
                enemy_ratio_first[i] += enemy_ratio_diff[i] * (Time.time - start_time);    // �����m�����X�V
            }
            // �������Ȃ��ꍇ
            if (enemy != null)
            {
                Instantiate(enemy, spawn_position, Quaternion.identity);
            }

            yield return new WaitForSeconds(enemy_min_time_span);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // do nothing
    }
}
