ENG
Front-End

The project file is located in the `Inforce.Core -> client` directory. You can run it the same way you did before or simply by pressing the "Run" button, if everything is configured correctly.

Back-End

We have 5 projects that are interconnected. The main project is `Inforce.Core`, which contains our controllers and the corresponding endpoints for the front-end. You need to run our main project, which is `Inforce.Core`. If you need to make any changes to the database, migrations should be applied in `Inforce.Persistence`. These are the key points. Next, familiarize yourself with the structure and take a look at my commits to understand exactly where and how things should be written.

DataBase



UAH

Front-End 

Файл проєкту знаходиться в проєкті Inforce.Core -> client. Запускати його так само, як ви робили раніше або ж просто через кпопку Run, якщо все гарно в ній налаштовано

Back-End 

У нас є 5 основних проєктів, які між собою пов'язані. Основий це Inforce.Core, у ньому будуть знаходитися наші котроллери та відповідно Endpoints до фронту. Запускати потрібно наш основний проєкт, тобто Inforce.Core. Якщо потрібно робити якісь зміни з БД то міграція повинна закидуватся в Inforce.Persistence. Це такі найосновніші моменти, далі просто ознайомлюєшся з структурою та в подальному можеш подивитися на мої комміти, щоб точно зрозуміти, як правильно і де що саме потрібно писати.

DataBase

Для бази данних потрібно створити клас у Entity та в подальшому зробити DbSet у файлі PlatformDbContext та потім за потреби сторюємо файл конфігурації для нашого класу. Потім обов'язково потрібно зробити міграцію та онвовити базу данних такими командами dotnet ef migrations add назва  та оновлення БД dotnet ef database update 
