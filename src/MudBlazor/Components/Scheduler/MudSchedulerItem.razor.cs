using System;
using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace MudBlazor
{
    /// <summary>
    /// ToDo:
    /// Represents an appointment item of a scheduler. To be used inside <see cref="MudScheduler"/>.
    /// </summary>
    public partial class MudSchedulerItem<T> : MudBaseSchedulerItem, IDisposable
    {
        protected string Classname =>
            new CssBuilder("mud-scheduler-item")
                .AddClass(Class)
                .Build();

        private IMudScheduler _parent;

        /// <summary>
        /// The parent scheduler component
        /// </summary>
        [CascadingParameter]
        internal IMudScheduler IMudScheduler
        {
            get => _parent;
            set
            {
                _parent = value;
                if (_parent == null)
                    return;
                _parent.CheckGenericTypeMatch(this);
                MudScheduler?.Add(this);
            }
        }

        internal MudScheduler<T> MudScheduler => (MudScheduler<T>)IMudScheduler;

        //ToDo: добавить различные параметры, которые будут храниться в элементе

        protected override void OnInitialized()
        {
            MudScheduler?.Add(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && MudScheduler != null)
            {
                try
                {
                    MudScheduler?.Remove(this);
                }
                catch (Exception) { /*ignore*/ }
            }
        }
    }
}
