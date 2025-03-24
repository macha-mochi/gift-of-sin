using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expire : MonoBehaviour
{
    [SerializeField] float expireTime = 5f;
    private LineRenderer render;
    private float a, b, t;
    void Start()
    {
        render = GetComponent<LineRenderer>();
        a = 3;
        b = 0;
        t = 0;
        StartCoroutine(TimedExpire(expireTime));
        
    }
    private void Update()
    {
            AnimationCurve curve = new AnimationCurve();
            float v = Mathf.Lerp(a, b, t);
            t += Time.deltaTime * 2;
            curve.AddKey(0,v);
            render.widthCurve = curve;
    }
    IEnumerator TimedExpire(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
