using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using MudBlazor.Utilities.Exceptions;

namespace MudBlazor
{
    public partial class MudScheduler<TItem> : MudComponentBase, IMudScheduler, IDisposable
    {
        protected string Classname =>
            new CssBuilder("mud-scheduler")
                .AddClass(Class)
                .Build();

        /// <summary>
        /// If true, the Scheduler will be disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// Gets or Sets if 'Next' and 'Previous' arrows must be visible.
        /// </summary>
        [Parameter]
        public bool ShowArrows { get; set; } = true;

        /// <summary>
        /// Gets or Sets if 'Today' button must be visible.
        /// </summary>
        [Parameter]
        public bool ShowTodayButton { get; set; } = true;

        /// <summary>
        /// Gets or Sets 'Today' button text.
        /// </summary>
        [Parameter]
        public string TodayText { get; set; } = "Today";

        /// <summary>
        /// Gets or Sets if View Selector must be visible.
        /// </summary>
        [Parameter]
        public bool ShowViewSelector { get; set; } = true;

        /// <summary>
        /// Gets or Sets the Template for the Left Arrow.
        /// </summary>
        [Parameter]
        public RenderFragment LeftArrowTemplate { get; set; }

        /// <summary>
        /// Gets or Sets the Template for the Right Arrow.
        /// </summary>
        [Parameter]
        public RenderFragment RightArrowTemplate { get; set; }

        /// <summary>
        /// Gets or Sets the Template for the Date Range Picker.
        /// </summary>
        [Parameter]
        public RenderFragment DateRangePickerTemplate { get; set; }

        /// <summary>
        /// Child content of component.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected List<MudSchedulerItem<TItem>> _items = new List<MudSchedulerItem<TItem>>();

        [Parameter]
        public EventCallback<MudSchedulerItem<TItem>> SelectedItemChanged { get; set; }

        [Parameter]
        public EventCallback<int> SelectedSchedulerItemChanged { get; set; }

        internal void Add(MudSchedulerItem<TItem> item)
        {
            if (!Disabled)
                _items.Add(item);
        }

        internal void Remove(MudSchedulerItem<TItem> item)
        {
            if (!Disabled)
                _items.Remove(item);
        }

        public void CheckGenericTypeMatch(object select_item)
        {
            var itemT = select_item.GetType().GenericTypeArguments[0];
            if (itemT != typeof(TItem))
                throw new GenericTypeMismatchException("MudScheduler", "MudSchedulerItem", typeof(TItem), itemT);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    _items.Clear();
                }
                catch (Exception) { /*ignore*/ }
            }
        }
    }
}
