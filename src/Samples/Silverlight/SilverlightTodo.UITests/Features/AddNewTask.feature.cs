using System.Linq;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace SilverlightTodo.UITests.Features
{
    public class when_creating_a_new_task : with_application_initialized
    {
        SilverlightChildWindow _addTaskWindow;

        public override void before_each()
        {
            var button = Root.Get<Button>(":AddTask");
            button.Click();
            _addTaskWindow = Root.Get<SilverlightChildWindow>(":AddTaskWindow");
        }

        public override void after_each()
        {
            if (_addTaskWindow == null || _addTaskWindow.IsClosed) return;

            _addTaskWindow.Close();
            Root.WaitTill(() => _addTaskWindow.IsClosed);
        }

        [Fact] public void then_I_should_see_the_title_field_in_add_task_dialog()
        {
            // assert
            var title = _addTaskWindow.Get<TextBox>(":Title");
            title.Text = "Foo";
        }

        [Fact] public void then_I_should_see_the_description_field_in_add_task_dialog()
        {
            // assert
            var description = _addTaskWindow.Get<TextBox>(":Description");
            description.Text = "Bar Description";
        }

        [Fact] public void then_I_should_be_able_to_cancel_the_dialog()
        {
            // arrange
            var title = _addTaskWindow.Get<TextBox>(":Title");
            title.Text = "Foo";
            var description = _addTaskWindow.Get<TextBox>(":Description");
            description.Text = "Bar Description";

            // act
            _addTaskWindow.Get<Button>(":Cancel").Click();

            // assert
            Root.WaitTill(() => _addTaskWindow.IsClosed);
        }

        [Fact] public void then_I_should_be_able_to_create_the_new_task()
        {
            // arrange
            _addTaskWindow.Get<TextBox>(":Title").Text = "Foo";
            _addTaskWindow.Get<TextBox>(":Description").Text = "Bar Description";

            // act
            _addTaskWindow.Get<Button>(":Create").Click();
            Root.WaitTill(() => _addTaskWindow.IsClosed);

            // assert
            Assert.Equal(1, Root.Get<ListBox>(":Tasks").Items.Count);

            var listBox = Root.Get<ListBox>(":Tasks");
            var item = listBox.Items.Last();

            Assert.Equal("Foo - Bar Description", item.Name);
        }
    }
}