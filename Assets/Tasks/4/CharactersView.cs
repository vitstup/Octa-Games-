using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharactersView : MonoBehaviour
{
    [SerializeField] private float _updateTime; // Частота вызова операции
    [SerializeField] private Text _text; // Выносим text из getcomponent в SerializeField, можно так же при инициализации вызывать getcomponent
    [SerializeField] private Character[] _characters; // замена с Transform на Character, при необходимости из Character можно получить и трансформ, логика не сломается.
    // Но можно было и с TryGetComponent поиграться в случае если задумано, что у всех _characters есть компонент Character
    // Но в таком случае лучше применять вообще другие подходы
    // Проверка на null у _text и _characters отсутсвует, при необходимости можем добавить при инициализации


    // Замена с FixedUpdate на корутину. Корутину мы можем запустить или остановить в любой момент. К примеру при инициализации. Также мы можем указать фиксированное время вызова. 
    // Можно применить и UniTask и прочие решения
    // while (true) немного спорно в плане надежности и устойчивости приложения, но я думаю тут как пример пойдёт
    private IEnumerator TextUpdateRoutine(float _updateTime)
    {
        while (true)
        {
            float totalValue = 0f;
            foreach (Character chara in _characters)
                totalValue += chara != null ? chara.Value : 0f; // Можно заменить foreach на linq summ или поскольку в итоге нужно только среднее значение - то на linq average
                                                                // Оставил chara != null так как в инспекторе мы можем и null прокинуть, дабы не вылазили ошибки. Но тут всё зависит от того требуется ли ожидать null или нет.

            var averageValue = _characters.Length > 0 ? totalValue / _characters.Length : 0f; // Фиксим неправильную логику и убираем теоретически возможную ошибку при делении на 0. Проверку на null не делал. 
            string text = $"Characters: {_characters.Length} Avg value: {averageValue}"; // Заменил format на вот это, так как легче читается
            _text.text = text;
            Debug.Log(text);

            yield return new WaitForSeconds(_updateTime);
        }
    }
}

// В плане оптимизации - это отказ от GetComponent и также сокращение частоты вызовов самого метода. 



public class Character : MonoBehaviour
{
    public float Value;
}