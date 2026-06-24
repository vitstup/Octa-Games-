# Octo Games Test Task

## Задача 1. Coding Principles

### 1) Строгое разделение зон ответственности
Применение **MV*** паттернов или в целом логики для выделения отдельных зон ответственности:
- **UI**
- **Core** (геймплейная логика)
- **Визуализация**
- **Конфиги / Заполнение данных**
- ...и прочее по необходимости.

Это особенно позитивно сказывается на соблюдении принципа **Single Responsibility**, который далеко не всегда соблюдается в разработке на Unity.

### 2) Событийный или реактивный подход
Применение событийного/реактивного подхода и, возможно, реализация **Event Bus**.

**Плюсы:**
- Хорошо работает в связке с первым принципом.
- Может в теории **снизить связность** кода.
- Помогает выстроить **правильную цепочку зависимостей**.

---

## Задача 2. Save / Load Utility

![Screenshots/1.png](https://github.com/vitstup/Octo-Games-/blob/master/Screenshots/1.png)

---

## Задача 3. Popup / UI System

![Screenshots/2.png](https://github.com/vitstup/Octo-Games-/blob/master/Screenshots/2.png)

![Screenshots/3.png](https://github.com/vitstup/Octo-Games-/blob/master/Screenshots/3.png)

### Подзадача 3.1
Можно использовать **Horizontal Layout Group**, **Vertical Layout Group**, **Content Size Fitter**.
Применяя их, мы можем:
- **Динамически** (в зависимости от объёма текста и количества кнопок) менять размер попапа.
- **Гибко позиционировать** элементы внутри него.

Также понятно, что для построения элементов можно применять стандартные UI-компоненты, такие как:
- `Button`
- `Image`
- `TextMeshProUGUI` (или другие для текста)

---

## Задача 4. UI Performance & Refactoring

![Screenshots/4.png](https://github.com/vitstup/Octo-Games-/blob/master/Screenshots/4.png)

---

## Задача 5. Gameplay / State Logic

### Прояснение логики
> Не совсем понял, что имелось в виду под *"entities being removed"*, так как до этого писалось про *"inactive"*, поэтому тут реализовал через метод *Unregister*.

**Моя реализация:**
- Мы можем **удалить** сущность из трекера, используя метод `Unregister`.
- Также можем **зарегистрировать** её обратно.
- Система **гибкая** — мы можем делать это в любой момент.

Если под *"remove"* подразумевалось что-то другое, можно использовать схожий **событийный подход**.

### Реализация

![Screenshots/5.png](https://github.com/vitstup/Octo-Games-/blob/master/Screenshots/5.png)

![Screenshots/6.png](https://github.com/vitstup/Octo-Games-/blob/master/Screenshots/6.png)

> **Примечание:** Здесь представлена довольно простая реализация. В продакшене правильнее будет применить **Event Bus** или, возможно, **UniRx**.
