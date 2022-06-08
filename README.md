# Games Storage

<br/> This a test app made by using .NET Core 6
<br/> Where Used ASP.NET Core and Entity FrameWork

<br/> This web app represents an API with Clean Architecture with Repository pattern and thin controllers
<br/> The App structure consists of three element contained in folders Core (Interactor), Persistent(Data) and Presentation (Controller)
<br/> For a data storage was used MYSQL and Code First approach.

<br/> Such implementation of Clean Architecture has few flaws
<br/> First, using Repository pattern with Unit Of Work elements and Entity FrameWork creates problems with processing complex data that requires use of multiple Join Tables
<br/> Second, In order to keep controllers thin was used AutoMapper and Services. This leeds to that Mapping and Dtos became responsibility of Core level and Presantaion level has to use Dtos directly from Core level.
<br/> Like all the problems there also can be solved, but it will lead to unnecessary complexity and loses in maintableity that could be as bad as a low scalability

<br/> There is also a demo UI with JQuery and a demo of integration testing on xUnit

<br/>Это тестовое приложение, созданное с использованием .NET Core 6.
<br/>Где используется ASP.NET Core и Entity Framework


<br/>Это веб-приложение представляет собой API с чистой архитектурой с шаблоном репозитория и тонкими контроллерами.
<br/>Структура приложения состоит из трех элементов, содержащихся в папках Core (Interactor), Persistent (Data) и Presentation (Controller).
<br/>Для хранения данных использовался MYSQL и Code First.

<br/>Такая реализация Чистой Архитектуры имеет несколько недостатков.
<br/>Во-первых, использование шаблона Repository с элементами Unit Of Work и Entity FrameworkWork создает проблемы с обработкой сложных данных, требующих использования нескольких таблиц соединений.
<br/>Во-вторых, для того, чтобы контроллеры были тонкими, использовались AutoMapper и Services. Это приводит к тому, что Mapping и Dtos стали обязанностью уровня Core, а уровень Presantaion должен использовать Dtos непосредственно с уровня Core.
<br/>Как и все проблемы там тоже можно решить, но это приведет к ненужной сложности и потерям в ремонтопригодности, что может быть так же плохо, как и низкая масштабируемость.

<br/> Также есть demo UI с JQuery и demo интеграционного тестирования на xUnit.
