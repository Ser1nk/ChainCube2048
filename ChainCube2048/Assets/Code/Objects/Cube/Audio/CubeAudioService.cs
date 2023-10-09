using UnityEngine;

public class CubeAudioService : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private Cube _cube;

    [Header("AudioSources")]
    [SerializeField] private AudioSource _mergeCube;
    [SerializeField] private AudioSource _pushCube;
    [SerializeField] private AudioSource _pulseCube;

    private void OnEnable()
    {
        _cube.OnCubeMerged += PlayMergeSound;
        _cube.OnCubePushed += PlayPushSound;
    }

    private void OnDisable()
    {
        _cube.OnCubeMerged -= PlayMergeSound;
        _cube.OnCubePushed -= PlayPushSound;
    }

    private void PlayMergeSound()
    {
        _mergeCube.Play();
    }

    private void PlayPushSound()
    {
        _pushCube.Play();
    }

    private void PlayPulseSound()
    {
        _pulseCube.Play();
    }
}
