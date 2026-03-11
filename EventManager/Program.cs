using System;

// README.md를 읽고 코드를 작성하세요.

GameEventArgs e;
EventManager eventManager = new EventManager();
ScoreSystem scoreSystem = new ScoreSystem();
AchievementSystem achievementSystem = new AchievementSystem();
SoundSystem soundSystem = new SoundSystem();

eventManager.GameEvent += soundSystem.OnGameEvent;
eventManager.GameEvent += scoreSystem.OnGameEvent;
eventManager.GameEvent += achievementSystem.OnGameEvent;

eventManager.TriggerEvent("ScoreChanged", 100);
eventManager.TriggerEvent("Achievement", "첫 번째 적 처치");
eventManager.TriggerEvent("GameOver", null);


class GameEventArgs : EventArgs
{
    public string EventName { get; set; }
    public object Data { get; set; } = null;
}

class EventManager
{
    public event EventHandler<GameEventArgs> GameEvent;

    public void TriggerEvent(string eventName, object data)
    {
        GameEvent?.Invoke(this, new GameEventArgs { EventName = eventName, Data = data });
    }
}
class ScoreSystem
{
    public void OnGameEvent(object sender, GameEventArgs e)
    {
        if (e.EventName == "ScoreChanged")
        {
            Console.WriteLine($"점수 변경: {e.Data}점");
        }
    }
}

class AchievementSystem
{
    public void OnGameEvent(object sender, GameEventArgs e)
    {

        if (e.EventName == "Achievement")
        {
            Console.WriteLine($"업적 달성: {e.Data}");
        }

    }
}

class SoundSystem
{
    public void OnGameEvent(object sender, GameEventArgs e)
    {
            Console.WriteLine($"[Sound] 이벤트: {e.EventName}");
    }
}
//만약 EventName이 무수히 많아지면?
//EventName을 parameter로 받아서 출력하는 방식 으로 바꾸는게 좋아보임
//EventName이 많아지면 if문이 많아질 수 있음
