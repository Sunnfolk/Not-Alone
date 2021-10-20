using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{

    private Animator _animator;
    public float timeOffset = 2f;

    public string nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        FadeIn();
    }

    public void FadeIn()
    {
        _animator.Play("FadeIn");
    }

    public void FadeOut()
    {
        _animator.Play("FadeOut");
        
        StartCoroutine(nameof(fadeTime));
    }

    IEnumerator fadeTime()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length + timeOffset);
        SceneManager.LoadScene(nextLevelName);
    }
}
