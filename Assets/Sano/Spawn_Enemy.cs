using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    // ���X�g�̗v�f�̃C���f�b�N�X�͂��ꂼ��̃I�u�W�F�N�g�ɑΉ�
    // ��Œ�������

    [SerializeField] private float enemy_min_time_span;
    // �G�L�����̃C���X�^���X������
    [SerializeField] private List<GameObject> enemyList;
    // ���ꂼ��̓G�L�����̐����m��������i���v1�𒴂��Ȃ��悤�ɁA1�����̕��͐������Ȃ������j
    [SerializeField] private List<float> enemy_ratio;
    // ���ꂼ��̃L�����̃X�|�[���ʒu
    [SerializeField] private List<Vector2> ground_spawn_position;


    // Start is called before the first frame update
    void Start()
    {
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
                ratio_sum += enemy_ratio[i];
                if (rand < ratio_sum)
                {
                    enemy = enemyList[i];
                    spawn_position = ground_spawn_position[i];
                    break;
                }
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
