namespace Code
{
    public class Item
    {
        private int id;
        private string name;
        public Item()
        {

        }

        public Item(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
