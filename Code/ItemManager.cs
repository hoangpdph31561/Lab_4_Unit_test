using System.Text.RegularExpressions;

namespace Code
{
    public class ItemManager
    {
        public List<Item> items;
        public ItemManager()
        {
            items = new List<Item>()
            {
                new Item { Id = 1, Name = "Hoàng" },
                new Item { Id = 1000, Name = "Quang" }
            };
            items.Add(new Item { Id = 100, Name = "Huy" });
        }
        public void AddItem(Item item)
        {
            if (item.Id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0");
            }
            else if (items.Any(x => x.Id == item.Id))
            {
                throw new ArgumentException();
            }
            else if (item.Name == null)
            {
                throw new ArgumentException("Name cannot be null");
            }
            else if (item.Name.Length >= 50)
            {
                throw new ArgumentException("Name cannot be longer than 50 characters");
            }
            else if (!Regex.IsMatch(item.Name, @"^[\w\s]+$"))
            {
                throw new ArgumentException("Name can only contain letters and spaces");
            }
            else if (item.Name.Trim().Length == 0)
            {
                throw new ArgumentException("Name cannot be only spaces");
            }
            else
            {
                item.Name = item.Name.Trim();
                items.Add(item);
            }
        }
        public void UpdateItem(int id, string newName)
        {
            try
            {
                var item = items.FirstOrDefault(x => x.Id == id);
                if (newName.Length >= 50)
                {
                    throw new ArgumentException("Name cannot be longer than 50 characters");
                }
                else if (!Regex.IsMatch(newName, @"^[\w\s]+$"))
                {
                    throw new ArgumentException("Name can only contain letters and spaces");
                }
                else if (newName.Trim().Length == 0)
                {
                    throw new ArgumentException("Name cannot be only spaces");
                }
                else
                {
                    item!.Name = newName.Trim();
                }
            }
            catch (Exception)
            {

                throw new NullReferenceException("Item not found");
            }

        }
        public void DeleteItem(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new NullReferenceException("Id must be greater than 0");
                }
                else if (!items.Any(x => x.Id == id))
                {
                    throw new NullReferenceException("Item not found");
                }
                items.RemoveAll(x => x.Id == id);
            }
            catch (Exception)
            {

                throw new NullReferenceException("Item not found");
            }
        }
    }
}
