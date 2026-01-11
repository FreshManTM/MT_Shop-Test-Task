using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _priceText;
    [SerializeField] TextMeshProUGUI _incomeText;
    [SerializeField] Image _iconImage;
    [SerializeField] Image _backgroundImage;
    [SerializeField] Button _buyButton;


    [Header("Feedback Settings")]
    [SerializeField] float _feedbackDuration = 0.25f;
    [SerializeField] float _shakeStrength = 5f;

    Color _defaultBgColor;
    Vector3 _initialPosition;
    Action _buttonAction;

    void Awake()
    {
        _defaultBgColor = _backgroundImage.color;
    }

    public void SetShopItem(ItemDefinition item, Action buttonAction)
    {
        _nameText.text = item.ItemName;
        _priceText.text = $"Price: {item.Price}$";

        _incomeText.text = BuildShopEffectText(item);
        _iconImage.sprite = item.Icon;
        _buttonAction = buttonAction;

        _buyButton.onClick.RemoveAllListeners();

        _buyButton.onClick.AddListener(OnButtonClicked);
    }
    string BuildShopEffectText(ItemDefinition item)
    {
        if (item.Effects.Count == 0)
            return string.Empty;

        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        foreach (ItemEffect effect in item.Effects)
        {
            builder.AppendLine(effect.GetValueString(item));
        }

        return builder.ToString().TrimEnd();
    }

    void OnButtonClicked()
    {
        _buttonAction?.Invoke();
    }


    public void PlaySuccessFeedback()
    {
        StopAllCoroutines();
        StartCoroutine(ColorChangeRoutine(Color.green, _feedbackDuration));
    }

    public void PlayFailFeedback()
    {
        StopAllCoroutines();

        StartCoroutine(ColorChangeRoutine(Color.red, _feedbackDuration));
        StartCoroutine(ShakeRoutine(_feedbackDuration, _shakeStrength));
    }

    IEnumerator ColorChangeRoutine(Color color, float duration)
    {
        _backgroundImage.color = color;
        yield return new WaitForSeconds(duration);
        _backgroundImage.color = _defaultBgColor;
    }

    IEnumerator ShakeRoutine(float feedbackDuration, float strength)
    {
        _initialPosition = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < feedbackDuration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * strength;
            transform.localPosition = _initialPosition + new Vector3(x, 0f, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = _initialPosition;
    }
}
