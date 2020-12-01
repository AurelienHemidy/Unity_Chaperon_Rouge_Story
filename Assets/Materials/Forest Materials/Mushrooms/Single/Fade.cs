using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    private Renderer _renderer;

    private bool _isVisible = false;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = Instantiate<Material>(_renderer.material);
    }

    public void FadeIn(){
        _isVisible = false;
        StartCoroutine(AsyncFade());
    }
    public void FadeOut(){
        _isVisible = true;
        StartCoroutine(AsyncFade());
    }

    private IEnumerator AsyncFade(){

        float duration = 1.0f;
        float progress = 0.0f;
        float time = 0.0f;
        Color color;
        while(time <= duration){
            time += Time.deltaTime;

            progress = time / duration;

            color = _renderer.material.color;
            color.a = _isVisible ? progress : 1-progress;
            _renderer.material.color = color;

            yield return null;
        }

        color = _renderer.material.color;
        color.a = _isVisible ? 1 : 0;
        _renderer.material.color = color;
    }
}
