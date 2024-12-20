using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // �C���X�^���X��
    public static GameController instance { get; private set; }

    [SerializeField]
    private int remaining_time;

    public int Remaining_Time
    {
        set { remaining_time = value; } //�l�̑��
        get { return remaining_time; } //�O���ɒl��Ԃ�
    }

	void Awake()
	{
		if(instance == null)
		{
            instance = this;
		}
	}

    public void GameStart()
	{

	}

    public void SpawnEnemy()
	{

	}

    public void GameClear()
    {

    }

    public void GameOver()
    {

    }
}
