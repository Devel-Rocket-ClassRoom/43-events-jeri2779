using System;
using System.Collections.Generic;
using System.Threading.Channels;

// README.md를 읽고 아래에 코드를 작성하세요.
 
Inventory inventory = new Inventory();
InventoryUI ui = new InventoryUI();
AutoBuyer autoBuyer = new AutoBuyer();
inventory.ItemChanged += ui.OnInventoryChanged;
inventory.ItemChanged += autoBuyer.OnInventoryChanged;
inventory.AddItem("포션", 5);
inventory.AddItem("화살", 10);
inventory.AddItem("포션", 3);
inventory.RemoveItem("화살", 7);
inventory.RemoveItem("화살", 5);

class Inventory
{
    
    public event Action<string, int, int> ItemChanged;
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string name, int count)
    {
       int oldCount = items.ContainsKey(name) ? items[name] : 0;
       items[name] = oldCount + count;
        ItemChanged?.Invoke(name, oldCount, items[name]);
    }
    public void RemoveItem(string name, int count)
    {
        int oldCount = items.ContainsKey(name) ? items[name] : 0;
        items[name] = Math.Max(oldCount - count, 0);
        ItemChanged?.Invoke(name, oldCount, items[name]);
    }
}
class InventoryUI
{
    public void OnInventoryChanged(string name, int oldCount, int newCount)
    {
        Console.WriteLine($"[UI] {name}: {oldCount} → {newCount}");
    }
}
class AutoBuyer
{
    public void OnInventoryChanged(string name, int oldCount, int newCount)
    {
        if(newCount <= 0)
        {
            Console.WriteLine($"[자동구매] {name} 재고 소진! 자동 구매 요청");
        }
    }
}
 