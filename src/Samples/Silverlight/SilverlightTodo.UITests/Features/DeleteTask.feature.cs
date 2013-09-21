using System.Linq;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;
using Xunit;

namespace SilverlightTodo.UITests.Features
{
    public class when_having_a_task : with_application_initialized
    {
        public override void before_each()
        {
            Root.Get<Button>(":AddTask").Click();

            var addTaskWindow = Root.Get<SilverlightChildWindow>(":AddTaskWindow");

            addTaskWindow.Get<TextBox>(":Title").Text = "Foo";
            addTaskWindow.Get<TextBox>(":Description").Text = "Bar Description";
            addTaskWindow.Get<Button>(":Create").Click();

            Root.WaitTill(() => addTaskWindow.IsClosed);
        }

        [Fact]
        public void then_I_should_be_able_to_create_the_new_task()
        {
            var listBox = Root.Get<ListBox>(":Tasks");
            var item = listBox.Items.Last();

            // act
            item.Get<Button>(":Delete").Click();

            // assert
            Assert.Equal(0, Root.Get<ListBox>(":Tasks").Items.Count);
        }
    }
}