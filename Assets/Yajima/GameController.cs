using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	#region �

	// �C���X�^���X��
	public static GameController instance { get; private set; }

    [SerializeField]
    private int remaining_time;

    private bool isGameStart;
    private bool isGameClear;
    private bool isGameOver;

    public int Remaining_Time
    {
        set { remaining_time = value; } //�l�̑��
        get { return remaining_time; } //�O���ɒl��Ԃ�
    }

	#endregion

	void Awake()
	{
		if(instance == null)
		{
            instance = this;
		}
	}

	void Start()
	{
        isGameStart = false;
        isGameClear = false;
        isGameOver = false;
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

    // �Q�[���I���֐�
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //���̃R�[�h�Ńr���h�����Q�[�����I�����邱�Ƃ��ł���
        Application.Quit();
#endif
    }
}
