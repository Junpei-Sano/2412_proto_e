using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class QuiteButton : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private AudioManager _audioManager;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Button _quiteButton;
    
    private void Start()
    {
        _quiteButton
            .OnClickAsObservable()
            .Subscribe(_=>
            {
                _audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.Cancel);
                Quite();
            })
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Quite()
    {
#if UNITY_WEBGL
        Application.ExternalEval("window.open('','_self','');");
        Application.ExternalEval("window.close();");
        
#else
        Application.Quit();
#endif
    }
}
