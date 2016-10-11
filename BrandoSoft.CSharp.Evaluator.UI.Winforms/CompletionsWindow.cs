using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
namespace BrandoSoft.CSharp.Evaluator.UI.Winforms
{
    using System.Linq;
    using System.Windows.Forms;

    public partial class CompletionsWindow 
        : UserControl, IList<string>
    {
        #region Subtypes
        private class LabelVisibility
        {
            public Label Label { get; }
            public bool ShouldDisplay { get; set; }

            public LabelVisibility(Label label, bool shouldDisplay)
            {
                this.Label = label;
                this.ShouldDisplay = shouldDisplay;
            }
        }
        #endregion


        #region Events

        /// <summary>
        /// The event signature for when a user clicks a completion in the window.
        /// </summary>
        public event Action< CompletionsWindow, string > ItemClicked;

        #endregion
        #region Variables

        /// <summary>
        /// Our internal list of items. The key is the string completion and the value describes the label itself and whether or not we should dispaly it.
        /// </summary>
        private SortedDictionary< string, LabelVisibility> _items;

        /// <summary>
        /// Backing field for ItemBackColor
        /// </summary>
        private Color _itemBackColor;

        /// <summary>
        /// Backing field for ItemColor
        /// </summary>
        private Color _itemForeColor;

        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the background color of the control
        /// </summary>
        [Browsable(true)]
        public new Color BackColor
        {
            get { return this.flpContainer.BackColor; }
            set { this.flpContainer.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the background color of each of the items in the control.
        /// </summary>
        [Browsable(true)]
        public Color ItemBackColor
        {
            get { return this._itemBackColor; }
            set
            {
                foreach (var label in this._items.Values.Select(v => v.Label))
                {
                    label.BackColor = value;
                }
                this._itemBackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of each of the items in the control.
        /// </summary>
        [Browsable(true)]
        public Color ItemForeColor
        {
            get { return this._itemForeColor; }
            set
            {
                foreach (var label in this._items.Values.Select(v => v.Label))
                {
                    label.ForeColor = value;
                }
                this._itemForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the border color of the control
        /// </summary>
        [Browsable(true)]
        public Color BorderColor
        {
            get { return this.pnlBorder.BackColor; } 
            set { this.pnlBorder.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the size in pixels of the border of the control
        /// </summary>
        [Browsable(true)]
        public int BorderWidth
        {
            get { return this.pnlBorder.Padding.All; }
            set { this.pnlBorder.Padding = new Padding(value); }
        }

        /// <summary>
        /// Gets or sets the background color of a completion item when the mouse is hovering it.
        /// </summary>
        [Browsable(true)]
        public Color ItemHighlightBackColor { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of a completion item when the mouse is hovering it.
        /// </summary>
        [Browsable(true)]
        public Color ItemHighlightForeColor { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Construct a code completions window.
        /// </summary>
        public CompletionsWindow()
        {
            this.InitializeComponent();
            this._items = new SortedDictionary< string, LabelVisibility>();

            this.BackColor              = ColorTranslator.FromHtml("#000");
            this.ItemBackColor          = ColorTranslator.FromHtml("#000");
            this.ItemForeColor          = ColorTranslator.FromHtml("#fff");
            this.ItemHighlightBackColor = ColorTranslator.FromHtml("#111");
            this.ItemHighlightBackColor = ColorTranslator.FromHtml("#eee");
            this.BorderColor            = ColorTranslator.FromHtml("#efefef");
            this.BorderWidth            = 1;
        }
        #endregion


        #region Methods

        private void UpdateVisual()
        {
            var totalHeight = 0;
            var widestLabel = 0;

            this.flpContainer.Controls.Clear();

            foreach ( var label in this.GetLabels(true) )
            {
                widestLabel = Math.Max((int)label.CreateGraphics().MeasureString(label.Text, label.Font).Width, widestLabel);
                totalHeight += label.Height;
                this.flpContainer.Controls.Add(label);
            }
            this.Height = totalHeight;
            this.Width = widestLabel;
        }

        private LabelVisibility CreateNewCompletionLabel(string completion)
        {
            var label = new Label
            {
                Text = completion,
                BackColor = this._itemBackColor,
                ForeColor = this._itemForeColor,
                Margin = new Padding(0),
            };

            label.Click += this.CompletionClicked;

            label.MouseEnter += this.CompletionMouseEntered;
            label.MouseLeave += this.CompletionMouseLeave;
            
            return new LabelVisibility(label, true);
        }

        private KeyValuePair<string, LabelVisibility> ItemAt(int index)
        {
            int i = 0;
            foreach (var item in this._items)
            {
                if (i == index)
                {
                    return item;
                }
                i++;
            }
            throw new IndexOutOfRangeException($"Index was outside of the bounds of the collection. Parameter name={nameof(index)}");
        }

        /// <summary>
        /// This is just a convenience method to get our labels from our internal list.
        /// </summary>
        /// <returns></returns>
        /// <param name="visible">Return labels based on the ShouldDisplay value, null to return all.</param>
        private IEnumerable< Label > GetLabels(bool? visible = null)
        {
            return this._items.Where(l => !visible.HasValue || l.Value.ShouldDisplay == visible.Value)
                              .Select(l => l.Value.Label);
        }
        #endregion

        #region Control Events
        private void CompletionsWindow_Resize(object sender, EventArgs e)
        {
            foreach ( var label in this._items.Values.Select(v => v.Label) )
            {
                label.Width = this.Width;
            }
        }

        private void CompletionClicked(object sender, EventArgs e)
        {
            //This prevents null refs if someone unsubscribes from our event between the null check 
            // and the event invocation.
            var completionClicked = this.ItemClicked;

            completionClicked?.Invoke(this, ((Label)sender).Text);
        }

        private void CompletionMouseEntered(object sender, EventArgs e)
        {
            var label = (Label) sender;
            label.BackColor = this.ItemHighlightBackColor;
            label.ForeColor = this.ItemHighlightForeColor;
            this.Cursor = Cursors.Hand;
        }
        private void CompletionMouseLeave(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.BackColor = this.ItemBackColor;
            label.ForeColor = this.ItemForeColor;
            this.Cursor = Cursors.Default;

        }
        #endregion
        #region IList<string> Implementation

        public IEnumerator<string> GetEnumerator()
        {
            return this._items.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(string item)
        {
            if ( this._items.ContainsKey(item) )
            {
                this._items[item].ShouldDisplay = true;
            }
            else
            {
                this._items.Add(item, this.CreateNewCompletionLabel(item));
            }
            
            this.UpdateVisual();
        }

        public void Clear()
        {
            foreach ( var label in this._items.Values.Where(l => l.ShouldDisplay) )
            {
                label.ShouldDisplay = false;
            }
            this.UpdateVisual();
        }

        public bool Contains(string item)
        {
            return this._items.Keys.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            this._items.Keys.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            if ( this._items.ContainsKey(item) )
            {
                this._items[item].ShouldDisplay = false;
                return true;
            }
            this.UpdateVisual();
            return false;
        }

        [Browsable(false)]
        public int Count => this._items.Count;

        [Browsable(false)]
        public bool IsReadOnly => false;

        public int IndexOf(string item)
        {
            return this._items.Keys.ToList().IndexOf(item);
        }

        public void Insert(int index, string item)
        {
            this.Add(item);
        }

        public void RemoveAt(int index)
        {
            var item = this.ItemAt(index);

            item.Value.ShouldDisplay = false;

            this.UpdateVisual();
        }

        [Browsable(false)]
        public string this[int index]
        {
            get
            {
                return this.ItemAt(index).Key;
            }
            set
            {
                var current = this.ItemAt(index);

                if ( current.Key != value )
                {
                    current.Value.ShouldDisplay = false;
                    this.Add(value);
                }
            }
        }

        #endregion

    }
}
