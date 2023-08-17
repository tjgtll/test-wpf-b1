## Задание 1

создание бд
файл task1/task1-init

    create database tase

    use tase

    create table random_date(
        DateTimeRandom datetime,
        LatinRandom NVARCHAR (11),
        RussianRandom NVARCHAR (255),
        IntRandom int,
        DoubleRandom decimal(18, 8)
    );

1.  Сгенерировать 100 текстовых файлов со следующей структурой, каждый из которых содержит
    100 000 строк

        случайная дата за последние 5 лет || случайный набор 10 латинских символов ||
        случайный набор 10 русских символов || случайное положительное четное
        целочисленное число в диапазоне от 1 до 100 000 000 || случайное положительное
        число с 8 знаками после запятой в диапазоне от 1 до 20

        Пример вывода:
        03.03.2015||ZAwRbpGUiK||мДМЮаНкуКД||14152932||7,87742021||
        23.01.2015||vgHKThbgrP||ЛДКХысХшЗЦ||35085588||8,49822372||
        17.10.2017||AuTVNvaGRB||мЧепрИецрА||34259646||17,7248118||
        24.09.2014||ArIAASwOnE||ЧпЙМдШлыфУ||23252734||14,6239438||
        16.10.2017||eUkiAhUWmZ||ЗэЖЫзЯШАэШ||27831190||8,10838026||

![Текст с описанием картинки](/img/1-3.png)

Созданные файлы

![Текст с описанием картинки](/img/1-1.png)

![Текст с описанием картинки](/img/1-2.png)

2.  Реализовать объединение файлов в один. При объединении должна быть возможность
    удалить из всех файлов строки с заданным сочетанием символов, например, «abc» с выводом
    информации о количестве удаленных строк

![Текст с описанием картинки](/img/1-4.png)

3.  Создать процедуру импорта файлов с таким набором полей в таблицу в СУБД. При импорте
    должен выводится ход процесса (сколько строк импортировано, сколько осталось)

![Текст с описанием картинки](/img/1-5.png)

![Текст с описанием картинки](/img/1-6.png)

![Текст с описанием картинки](/img/1-7.png)

4.  Реализовать хранимую процедуру в БД (или скрипт с внешним sql-запросом), который считает
    сумму всех целых чисел и медиану всех дробных чисел
    Все скрипты/процедуры/запросы из пунктов 2-3-4 должны быть повторяемыми.
    В качестве вывода/взаимодействия с пользователем можно ограничиться консольным
    приложением. Десктоп версия опциональна.

файл task1-4.sql

    use tase

    DECLARE @SumInt BIGINT;
    SELECT @SumInt = SUM(CAST(IntRandom AS BIGINT)) FROM random_date;

    DECLARE @MedianDouble FLOAT;
    SELECT @MedianDouble = PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY DoubleRandom) OVER() FROM random_date;

    SELECT @SumInt AS TotalSumIntegers, @MedianDouble AS MedianDoubles;

![Текст с описанием картинки](/img/1-8.png)

## Задание 2

Для Updates-database default project b1-task2.DAL. b1-task2.DAL/DataDbContext/DesignDbContextFactory.cs

1.  Проанализировать структуру excel-файла «ОСВ для тренинга». Разработать схему (несколько
    таблиц) в СУБД, в которой наиболее удобно будет хранить данные из файлов такого
    формата

2.  С помощью Десктоп приложения реализовать
    a. Загрузку данных из excel-файла такого формата в СУБД

![Текст с описанием картинки](/img/2-2.png)

![Текст с описанием картинки](/img/2-1.png)

![Текст с описанием картинки](/img/2-3.png)

    b. Просмотр списка загруженных файлов

![Текст с описанием картинки](/img/2-2.png)

    c. Отображение данных из СУБД по визуальной аналогии с exсel-файлом для каждого
    из загруженных файлов

![Текст с описанием картинки](/img/2-4.png)

## Общие требования

После выполнения задания предоставить:

1.  код с комментариями;
2.  скринкаст с выполнением кода для каждого задания;
3.  если в проектах использовались библиотеки, не входящие в стандартный набор
    использованного вами ЯП, необходимо приложить и их;
4.  по возможности, приложить сгенерированные исполняемые файлы проектов (зависит от
    используемого ЯП)