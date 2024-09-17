## Подлючение консьюмеров

Консьюмеры подключаются с помощью метода расширения ```services.AddKafkaConsumer```
<br>У этого метода 2 обязательных параметра и 1 необязательный:
* ```ConsumerGroupId``` - используется, чтобы разные инстансы сервиса работали совместно.
* ```configureConsumers``` - делегат, в котором размещается подключение консьюмеров по типам событий
* ```deserializers``` - необязательный параметр, список десериализаторов, которые могут быть использованы для десериализации сообщений. 
Какой из десериализаторов будет использован, определяется с помощью хедеров сообщения. По умолчанию используется JsonUtf8Serializer

Воще в целом тут гдето рассказ про общуюю сборку событиия

Рассмотрим подробнее делегат configureConsumers. В нем добавляются консьюмеры по типам событий, в параметрах нужно указать топик и можно переопределить некоторые конфиги. 
Так же в дженерик типах прокидывается тип события и класс консьюмера. При этом класс консьюмера должен быть зарегестрирован в DI ранее 

```csharp
// Классы консьюмеров регистрируются в DI отдельно
builder.Services.AddSingleton<CountryConsumer>();
builder.Services.AddSingleton<EventConsumer>();

// Использование и настройка консьюмеров происходит с помощью методов расширения 
builder.Services.AddKafkaConsumer(ConsumerGroupId, c =>
{
    c.AddConsumer<Country, CountryConsumer>("countrytopic");
    c.AddConsumer<Event, EventConsumer>("testtopic", c =>
    {
        c.ConsumerConfig.AutoOffsetReset = AutoOffsetReset.Latest;
        c.RetriesBeforeError = 5;
        c.TransientBackoff = new ExponentialBackoff(TimeSpan.FromSeconds(1));
    });
});
```