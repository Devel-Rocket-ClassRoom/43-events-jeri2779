using System;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

// README.md를 읽고 코드를 작성하세요.
{
    Console.WriteLine("## 1. 대리자 복습");
    Notify SayHello = () =>
    Console.WriteLine("안녕하세요");
    Notify SayGoodbye = () =>
    Console.WriteLine("안녕히 가세요!");

    SayHello();
    SayGoodbye();
}
Console.WriteLine();
{
    Console.WriteLine("## 2. 기본 이벤트 선언");



    Button button = new Button();

    button.Clicked += HangdleClick;
    button.Clicked += HandleClickAgain;

    button.OnClick();


    static void HangdleClick()
    {
        Console.WriteLine("버튼이 클릭되었습니다.");
    }

    static void HandleClickAgain()
    {
        Console.WriteLine("클릭 처리 완료.");
    }
}
Console.WriteLine();
{
    Console.WriteLine("## 3. 이벤트 구독");

    Player player = new Player();
    HealthBar healthBar = new HealthBar();
    SoundManager soundManager = new SoundManager();

    player.DamageTaken += healthBar.OnPlayerDamaged;
    player.DamageTaken += soundManager.OnPlayerDamaged;

    player.TakeDamage(30);
}
Console.WriteLine();
{
    Console.WriteLine("## 4. 이벤트 해제");

    Timer timer = new Timer();
    Logger logger = new Logger();

    timer.Tick += logger.OnTick;

    Console.WriteLine("===구독 상태===");
    timer.Start();

    timer.Tick -= logger.OnTick;

    Console.WriteLine("\n===구독 해제 후===");
    timer.Start();
}
Console.WriteLine();
{
    Console.WriteLine("## 5. 람다식 이벤트 핸들러");

    Sensor sensor = new Sensor();

    sensor.Alert += message =>
    {
        Console.WriteLine($"[경보]: {message}");
    };   
    sensor.Alert += message =>
    {
        Console.WriteLine($"[로그]: {DateTime.Now}: {message}");
    };

    sensor.Detect("움직임 감지됨");
    sensor.Detect("온도 상승");
}
Console.WriteLine();
{
    Console.WriteLine("## 6. Action 대리자 활용");

    GameCharacter hero = new GameCharacter("용사");
    hero.OnDeath += () =>
    Console.WriteLine("캐릭터가 사망했습니다.");

    hero.OnDamaged += health =>
    Console.WriteLine($"남은 체력: {health}");

    hero.OnAttack += (damage, target) =>
    Console.WriteLine($"{target}에게 {damage} 데미지!");

    hero.Attack(50, "슬라임");
    hero.TakeDamage(30);
    hero.TakeDamage(80);
}
Console.WriteLine();
{
    Console.WriteLine("## 7. 표준 이벤트 패턴 (EventArgs)");
    Stock msStock = new Stock("MSFT", 100.0m);

    msStock.PriceChanged += (sender, e) =>
    {
        Stock stock = (Stock)sender;
        Console.WriteLine($"{stock}");
        Console.WriteLine($"이전 가격: {e.OldPrice:C}");
        Console.WriteLine($"현재 가격: {e.NewPrice:C}");
        Console.WriteLine($"변동률: {e.ChangeAmount:F2}%");
    };

    msStock.Price = 110.0m;
    msStock.Price = 105.50m;
    msStock.Price = 120.00m;
}
Console.WriteLine();
{
    Console.WriteLine("# 8. 실전 예제 - 연료 경고 시스템");

    Car car = new Car(50);
    Dashboard dashboard = new Dashboard();

    dashboard.Subscribe(car);

    for (int i = 0; i < 7; i++)
    {
        car.Drive();
        Console.WriteLine();
    }

    dashboard.Unsubscribe(car);
}
Console.WriteLine();
{
    Console.WriteLine("## 9. 이벤트 접근자");
    SecurePublisher publisher = new SecurePublisher();
    publisher.MyEvent += Handler1;
    publisher.MyEvent += Handler2;

    Console.WriteLine("\n이벤트 발생:");
    publisher.RaiseEvent();

    Console.WriteLine();
    publisher.MyEvent -= Handler1;

    Console.WriteLine("\n이벤트 발생:");
    publisher.RaiseEvent();
    static void Handler1(object sender, EventArgs e)
    {
        Console.WriteLine("핸들러 1 실행됨");
    }
    static void Handler2(object sender, EventArgs e)
    {
        Console.WriteLine("핸들러 2 실행됨");
    }

}
Console.WriteLine();
{
    Console.WriteLine("## 10. static 이벤트");

    Module1 m1 = new Module1();
    Module2 m2 = new Module2();

    GlobalNotifier.SendMessage("시스템 시작");
        GlobalNotifier.SendMessage("데이터 로드 완료");
}
delegate void EventHandler1();   
delegate void Notify();   