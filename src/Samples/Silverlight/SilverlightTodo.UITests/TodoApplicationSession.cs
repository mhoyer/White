using System;
using System.IO;
using TestStack.White.WebBrowser.Silverlight;
using Xunit;

namespace SilverlightTodo.UITests
{
    public class TodoApplicationSession : SilverlightSession
    {
        public TodoApplicationSession()
        {
            var asmPath = Path.GetDirectoryName(GetType().Assembly.Location);
            var testPage = String.Format("{0}\\SilverlightTodo.html", asmPath);
            var windowTitle = "SilverlightTodo";
            
            Open(testPage, windowTitle); // will close automatically on Dispose()
        }
    }
    
    public class with_application_initialized : IUseFixture<TodoApplicationSession>, IDisposable
    {
        public TodoApplicationSession Session { get; set; }
        public SilverlightDocument Root { get; set; }

        public void SetFixture(TodoApplicationSession session)
        {
            Session = session;
            Root = session.Document;

            session.Initialize(before_all);
            before_each();
        }

        public void Dispose()
        {
            after_each();
        }

        public virtual void before_all() { /* NOOP */ }
        public virtual void before_each() { /* NOOP */ }
        public virtual void after_each() { /* NOOP */ }
    }
}