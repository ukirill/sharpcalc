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
- Cортировка по-умолчанию по ``Id``
- Поправлены баги с хранением ``double`` в БД

19.05

Workaround по проблеме миграции в ``EntityFramework``

1. Откатить классы описания сущностей ``Users.cs`` и ``OperationResult.cs`` к состоянию, соотвествующему структуре базы на данный момент.
То есть убрать новые ``virtual`` поля для связи таблиц.

2. Перенести ``OperationResult.cs`` в нормальный _namespace_ ``DBModel.Models`` (может быть и не нужно, я не проверял, но для порядка сделал)

3. Нужен единый контекст для работы с базой, без этого точно не заведется. У меня такой
```
namespace DBModel.Helpers
{
    public class CalcContext : DbContext
    {
        public CalcContext() : base("EFConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationResult> OperationResults { get; set; }
    }
}
```
Код _менеджеров_ переписать для работы с ним. Другие контексты грохнуть.
Теперь кодовая база готова к миграции.

4. В базе грохаем таблицу _MigrationHistory_ , если такая есть. В проекте удаляем папку _Migration_ , если есть такая

5. В консоли диспетчера пакетов в качестве проекта выбираем ``DBModel``

6. Вводим команду задающую автомиграцию __Enable-Migrations –EnableAutomaticMigrations__

7. Вводим команду задающую начальное состояние __Add-Migration InitialMigrations -IgnoreChanges__

8. Если все ок, меняем структуру объектов ``Users.cs`` и ``OperationResult.cs``, добавляя ``virtual`` поля для связи

9. Возвращаемся в консоль обновляем базу __Update-Database -verbose__

10. База обновилась, можем писать результаты вычислений с пользователем

