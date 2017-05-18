# sharpcalc

### Учебный проект для стажировки

Приложение-калькулятор с консольным и графическим интерфейсом

### Домашние задания

15.05

- Добавлена поддержка типа ``double`` во все операции
- Дополнены тесты

16.05

- Убраны дубликаты из списка операций
- Добавлена реализация ``Calc(IEnumerable <object> args)`` для всех внутренних операций 
- Перегружен метод ``Execute(IOperation oper, args[])``
- В списке операций ``ComboBox cbOper`` помечены красным операции не работающие с потоком аргументов
- Добавлен в конструктор ``Calc()`` фильтр дупликатов операций.

17.05

- Выпадающий список с операциями согласно заданию (отфильтрованный и именованный) в веб-форме

18.05

- Кнопка ``Forced Calc`` принудительно пересчитывает результат и добавляет/обновляет его в таблице
- Отдельная страница со списком истории операций из БД
- Cортировка по-умолчанию по Id
- Поправлены баги с хранением ``double`` в БД
