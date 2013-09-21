using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace SilverlightTodo.UITests.Features
{
    public class when_starting_the_application : with_application_initialized, IDisposable
    {
        SilverlightChildWindow _addTaskWindow;

        public void Dispose()
        {
            if (_addTaskWindow != null)
            {
                _addTaskWindow.Close();
                Session.Document.WaitTill(() => _addTaskWindow.IsClosed);
            }
        }

        [Fact]
        public void then_I_should_see_the_new_task_button()
        {
            var button = Root.Get<Button>(":AddTask");
            Assert.NotNull(button);
        }

        [Fact]
        public void then_I_should_be_able_to_open_the_new_task_dialog()
        {
            // act
            Root.Get<Button>(":AddTask").Click();

            // assert
            _addTaskWindow = Root.Get<SilverlightChildWindow>(":AddTaskWindow");
        }
    }
}