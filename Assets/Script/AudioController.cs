using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaDeFundo;
    public AudioSource audioSourceSFX;
    public AudioClip[] musicasDeFundo;

    private float musicaDeFundoVolumeOriginal; // Armazena o volume original da música de fundo

    // Start is called before the first frame update
    void Start()
    {
        AudioClip musicaDeFundoDessaFase = musicasDeFundo[0];
        audioSourceMusicaDeFundo.clip = musicaDeFundoDessaFase;
        audioSourceMusicaDeFundo.Play();

        musicaDeFundoVolumeOriginal = audioSourceMusicaDeFundo.volume; // Armazena o volume original
    }

    public void ToqueSFX(AudioClip clip)
    {
        audioSourceSFX.PlayOneShot(clip);
        audioSourceSFX.clip = clip;
        audioSourceSFX.Play();

        DiminuirVolumeMusicaDeFundo(); // Chama o método para diminuir o volume da música de fundo
    }

    private void DiminuirVolumeMusicaDeFundo()
    {
        audioSourceMusicaDeFundo.volume = musicaDeFundoVolumeOriginal * 0.0f; 
    }
}
