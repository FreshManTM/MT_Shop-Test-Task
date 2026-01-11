using UnityEngine;
using UnityEngine.EventSystems;

public sealed class ButtonFeedback : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] bool _useHighlightScale = true;
    [SerializeField] float _highlightScale = 0.95f;

    [SerializeField] bool _usePressScale = true;
    [SerializeField] float _pressedScale = 0.9f;

    [SerializeField] float _scaleSpeed = 14f;


    Vector3 _defaultScale;
    Coroutine _scaleRoutine;

    void Awake()
    {
        _defaultScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_usePressScale)
            StartScale(_defaultScale * _pressedScale);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_usePressScale)
            StartScale(_defaultScale);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_useHighlightScale)
            StartScale(_defaultScale * _highlightScale);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_useHighlightScale)
            StartScale(_defaultScale);
    }
    void OnDisable()
    {
        transform.localScale = _defaultScale;
    }

    void StartScale(Vector3 target)
    {
        if (_scaleRoutine != null)
            StopCoroutine(_scaleRoutine);

        _scaleRoutine = StartCoroutine(ScaleRoutine(target));
    }

    System.Collections.IEnumerator ScaleRoutine(Vector3 target)
    {
        while (Vector3.Distance(transform.localScale, target) > 0.001f)
        {
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                target,
                Time.unscaledDeltaTime * _scaleSpeed);

            yield return null;
        }

        transform.localScale = target;
    }


}
