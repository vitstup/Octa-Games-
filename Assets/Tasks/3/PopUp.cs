using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _content;
    [SerializeField] private PopUpBtn[] _btns;

    // 1 кнопка
    public void Display(string title, string content, string btnTitle, Action onClick)
    {
        Display(title, content, (btnTitle, onClick));
    }

    // 2 кнопки
    public void Display(string title, string content, string btn1Title, Action onBtn1Click, string btn2Title, Action onBtn2Click)
    {
        Display(title, content, (btn1Title, onBtn1Click), (btn2Title, onBtn2Click));
    }

    // Прочие варианты с 3, 4, 5 кнопками
    // Можно сделать перегрузки по каким то другим вариантам
    // Можно также и основной дисплей с params сделать public

    private void Display(string title, string content, params (string title, Action onClick)[] btnInfos)
    {
        if (btnInfos == null || btnInfos.Length == 0) return; // Можем кинуть ошибку о неправильных аргументах

        gameObject.SetActive(true);

        // Пример анимации появления
        StopAllCoroutines();
        StartCoroutine(AnimationBehaviorRoutine());
 

        _title.text = title;
        _content.text = content;
        
        for (int i = 0; i < _btns.Length; i++)
        {
            var btn = _btns[i];

            if (i >= btnInfos.Length)
            {
                btn.gameObject.SetActive(false);
                continue;
            }

            var btnInfo = btnInfos[i];

            btn.gameObject.SetActive(true);
            btn.Display(btnInfo.title, btnInfo.onClick);
        }
    }

    private IEnumerator AnimationBehaviorRoutine()
    {
        yield return null;
        // Тут какая нибудь логика анимации появления
        // Можно заменить корутину на твин или unitask или прочее
    }

    // Логика сокрытия попапа. Стоп всех корутин. Вызов корутины с аниацией и по оканчанию gameobject.setactive(false)
}

public class PopUpBtn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private Button _button;

    private Action _onClick;

    private void Awake() => _button.onClick.AddListener(HandleBtnClick);

    private void HandleBtnClick() => _onClick?.Invoke();

    public void Display(string title, Action onClick)
    {
        _title.text = title;
        _onClick = onClick;
    }
}