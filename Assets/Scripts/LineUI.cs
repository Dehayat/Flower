using System;
using UnityEngine;
using UnityEngine.UI;

public class LineUI : MonoBehaviour
{
    public float moveSpeed = 5;
    public bool isMoving = true;

    [Header("Tech shit")]
    public Text staticText;
    public Text dynamicText;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string staticText, string dynamicText)
    {
        this.staticText.text = staticText;
        this.dynamicText.text = dynamicText;
        UpdateSize();
    }
    public void SetStartPosition(float x)
    {
        var position = rectTransform.position;
        position.x = x;
        rectTransform.position = position;
    }
    public float GetEndPosition()
    {
        var position = rectTransform.position;
        return position.x + rectTransform.sizeDelta.x;
    }

    private void UpdateSize()
    {
        var rect = rectTransform.rect;
        var size = rect.size;
        size.x = staticText.preferredWidth + 40;
        rectTransform.sizeDelta = new Vector2(size.x, size.y);
    }

    public void PlayChangeAnim()
    {
        GetComponent<Animator>().Play("ChangeOptionLoop");
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }
        var position = rectTransform.position;
        position.x += moveSpeed * Time.deltaTime;
        rectTransform.position = position;
    }

    public void DoChangeOption()
    {
        LineManager.instance.DoChangeOption();
    }
    public void EndChangeOption()
    {
        LineManager.instance.EndChange();
    }
}
