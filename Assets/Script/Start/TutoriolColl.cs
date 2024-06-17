using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using Vignette = UnityEngine.Rendering.Universal.Vignette;

public class TutoriolColl : MonoBehaviour
{
    public AudioClip _audio;

    public TutoriolVoice _voice;
    public bool _exit;
    public Animator _gateAni;
    public Volume _effect;
    Vignette _vignette;

    private void Start()
    {
        _effect.profile.TryGet<Vignette>(out _vignette);
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _voice.PlayAudio(_audio);

            if (!_exit)
            {
                Destroy(this);
            }

            else
            {
                await Task.Delay((int)_audio.length * 1000);
                _gateAni.SetBool("Exit", true);
                //_vignette.intensity.value = 2;
            }
        }
    }
}
