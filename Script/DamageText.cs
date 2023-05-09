using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float alphaSpeed = 1f;

    public float destroyTime = 2f;
    TextMeshPro text;
    Color alpha;

    public float damage; 

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        text.text = damage.ToString();
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,moveSpeed * Time.deltaTime,0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);

        text.color = alpha;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

}
