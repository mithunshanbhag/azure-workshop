# BASIC CONCEPTS - TIMER AND HTTP TRIGGERS

## #1: Timer-triggered function app

Create & deploy a function app that triggers on the 15th and 45th second of every second minute.

[[SOLUTION]](../code-samples/function-app-timer-trigger/TimerTriggerFunction.cs)

-----

## #2: Http-triggered function app

Create & deploy a function app that processes a `POST` request as follows:

* Accepts a request for weather information of specified city (see format below):

    ```json
    {
        "city": "Bangalore"
    }
    ```

* Returns weather information for last 7 days for specified city (see format below):

    ```json
    {
        "city": "Bangalore",
        "dailyReport": [
            {
                "date": "2020-09-02T00:00:00+05:30",
                "celciusHigh": 40,
                "celciusLow": 30
            },
            {
                "date": "2020-09-01T00:00:00+05:30",
                "celciusHigh": 39,
                "temperatureLowCelcius": 28
            },
            {
                "date": "2020-08-31T00:00:00+05:30",
                "celciusHigh": 38,
                "temperatureLowCelcius": 27
            },
            {
                "date": "2020-08-30T00:00:00+05:30",
                "celciusHigh": 37,
                "temperatureLowCelcius": 26
            },
            {
                "date": "2020-08-29T00:00:00+05:30",
                "celciusHigh": 36,
                "temperatureLowCelcius": 25
            },
            {
                "date": "2020-08-28T00:00:00+05:30",
                "celciusHigh": 35,
                "temperatureLowCelcius": 24
            },
            {
                "date": "2020-08-27T00:00:00+05:30",
                "celciusHigh": 34,
                "temperatureLowCelcius": 23
            }
        ]
    }
    ```

[[SOLUTION]](../code-samples/function-app-http-trigger/HttpTriggerFunctionAdv.cs)

-----

## #3: Http-triggered function app (binding to route constraints)

[[SOLUTION]](../code-samples/function-app-http-trigger/HttpTriggerBindingExpressionFunction.cs)

-----

## #4: [Live Demo] Webhook to receive github notifications

-----
