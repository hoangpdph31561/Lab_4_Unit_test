using Code;

namespace TestLab
{
    public class Tests
    {
        ItemManager itemManager = new();
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddItem_WhenCalled_AddsItem()
        {
            var item = new Item(2, "Ho�ng");
            itemManager.AddItem(item);
            Assert.Contains(item, itemManager.items);
        }
        [Test]
        public void AddItem_IdLessThanZero_ThrowsArgumentException()
        {
            var item = new Item(-1, "Ho�ng");
            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }
        [Test]
        public void AddItem_ItemAlreadyExists_ThrowsArgumentException()
        {
            var item = new Item(100, "Quang");
            itemManager.AddItem(item);
            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }
        [Test]
        public void AddItem_NameIsNull_ThrowsArgumentException()
        {
            var item = new Item(10, null);
            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }
        [Test]
        public void AddItem_NameIsEmpty_ThrowsArgumentException()
        {
            var item = new Item(3, "");
            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }
        [Test]
        public void AddItem_NameIsLongerThan50Characters_ThrowsArgumentException()
        {
            var item = new Item(4, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }
        [Test]
        public void AddItem_NameContainsSpecialCharacters_ThrowsArgumentException()
        {
            var item = new Item(5, "Ho�ng@");
            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }
        [Test]
        public void AddItem_NameContainsOnlySpaces_ThrowsArgumentException()
        {
            var item = new Item(6, "    ");
            Assert.Throws<ArgumentException>(() => itemManager.AddItem(item));
        }
        [Test]
        public void AddItem_NameIsTrimmed_AddsItem()
        {
            var item = new Item(7, "  Ho�ng  ");
            itemManager.AddItem(item);
            Assert.Contains(item, itemManager.items);
        }
        [Test]
        public void AddItem_NameIsTrimmed_TrimsName()
        {
            var item = new Item(8, "  Ho�ng  ");
            itemManager.AddItem(item);
            Assert.AreEqual("Ho�ng", item.Name);
        }
        [Test]
        public void UpdateItem_WhenCalled_UpdatesItem()
        {
            itemManager.UpdateItem(1, "Quang");
            Assert.AreEqual("Quang", itemManager.items[0].Name);
        }
        [Test]
        public void UpdateItem_NameIsNull_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => itemManager.UpdateItem(100, null));
        }
        [Test]
        public void UpdateItem_NameIsEmpty_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => itemManager.UpdateItem(100, ""));
        }
        [Test]
        public void UpdateItem_NameIsLongerThan50Characters_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => itemManager.UpdateItem(100, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
        }
        [Test]
        public void UpdateItem_NameContainsSpecialCharacters_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => itemManager.UpdateItem(100, "Quang@"));
        }
        [Test]
        public void UpdateItem_NameContainsOnlySpaces_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => itemManager.UpdateItem(100, "    "));
        }
        [Test]
        public void UpdateItem_NameIsTrimmed_UpdatesItem()
        {
            itemManager.UpdateItem(1, "  C�a  ");
            Assert.AreEqual("C�a", itemManager.items[0].Name);
        }
        [Test]
        public void UpdateItem_IdNotFound_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => itemManager.UpdateItem(100, "Quang"));
        }
        [Test]
        public void UpdateItem_IdNegative_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => itemManager.UpdateItem(-1, "Quang"));
        }
        [Test]
        public void UpdateItem_IdZero_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => itemManager.UpdateItem(0, "Quang"));
        }
        [Test]
        public void DeleteItem_WhenCalled_DeletesItem()
        {
            itemManager.DeleteItem(1000);
            Assert.IsFalse(itemManager.items.Any(x => x.Id == 1000));
        }
        [Test]
        public void DeleteItem_IdNotFound_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => itemManager.DeleteItem(1001));
        }
        [Test]
        public void DeleteItem_IdNegative_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => itemManager.DeleteItem(-1));
        }
        [Test]
        public void DeleteItem_IdZero_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => itemManager.DeleteItem(0));
        }

    }
}