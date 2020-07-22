﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealPlanning {
    class EnhancedListView<T> : Panel
    {
        public List<T> Items { get; }

        private T _selectedItem;

        public T SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectable)
                {
                                        
                    if (_selectedItem != null)
                    {                        
                        Controls.Find(_selectedItem.ToString(), false).First().ForeColor = ForeColor;
                    }
                    if (value != null)
                    {                        
                        Controls.Find(value.ToString(), false).FirstOrDefault().ForeColor = SelectColor;
                    }
                    
                    SelectionChanged?.Invoke(_selectedItem, value);
                    _selectedItem = value;
                }
            }
        }

        public int VerticalPadding { get; set; } = 10;

        public int LeftMargin { get; set; } = 5;

        public Color HoverColor { get; set; } = Color.Blue;

        public Color SelectColor { get; set; } = Color.Blue;

        public delegate void SelectionChangedHandler(T oldItem, T newItem);

        public event SelectionChangedHandler SelectionChanged;

        private int _cursorY = 10;
        private bool _heightDirty = false;

        public string FilterText
        {
            set
            {
                Filter(i => i.ToString().ToLower().Contains(value.ToLower()));
            }
        }

        private bool _selectable = false;
        private bool _draggable = false;

        public EnhancedListView(bool selectable, bool draggable)
        {
            this.AutoScroll = false;
            Items = new List<T>();
            _draggable = draggable;
            _selectable = selectable;
        }


        public void Filter(Predicate<T> predicate)
        {
            AutoScrollPosition = new Point(0, 0);
            int lastLocation = VerticalPadding;
            foreach (Control c in Controls)
            {
                c.Visible = predicate(Items.Find(i => i.ToString() == c.Name));
                if (c.Visible)
                {
                    if (c.Location.Y != lastLocation)
                    {
                        c.Location = new Point(c.Location.X, lastLocation);
                    }
                    lastLocation += Font.Height + VerticalPadding;
                }
            }
            if (_selectedItem != null)
            {
                if (!Controls.Find(_selectedItem.ToString(), false).First().Visible)
                {
                    SelectedItem = default(T);
                }
            }
            RecalculateHeight();
        }

        public void Sort(Comparison<T> comparer) {
            this.AutoScrollPosition = new Point(0, 0);
            Items.Sort(comparer);
            int lastLocation = VerticalPadding;
            foreach (T item in Items) {
                Control c = Controls.Find(item.ToString(), false).FirstOrDefault();
                if (c != null) {
                    c.Location = new Point(LeftMargin, lastLocation);
                    lastLocation += Font.Height + VerticalPadding;
                }
            }
            
        }

        public void Add(T item)
        {            
            Items.Add(item);            

            Label l = CreateLabel(item, _cursorY);
            Controls.Add(l);
            _cursorY += l.Font.Height + VerticalPadding;
            if (!Visible) {
                _heightDirty = true;
            }
            else {
                RecalculateHeight();
            }
        }

        public void RecalculateHeight() {
            if (Controls.Count > 0) {
                Control c = null;
                for (int i = Controls.Count - 1; i >= 0; i--) {
                    if (Controls[i].Visible) {
                        c = Controls[i];
                        break;
                    }
                }
                if (c != null) {
                    int height = c.Location.Y
                        + Font.Height + VerticalPadding;
                    if (height > Parent.Height) {
                        Height = height;
                    }
                    else {
                        Height = Parent.Height;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (_heightDirty) {
                RecalculateHeight();
                _heightDirty = false;
            }
        }

        public void Clear()
        {
            Items.Clear();
            Controls.Clear();
            SelectedItem = default;
            _cursorY = VerticalPadding;
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
            {
                Control label = Controls.Find(item.ToString(), false).First();
                int position = label.Location.Y;
                _cursorY -= (label.Font.Height + VerticalPadding);
                
                foreach (Control c in Controls)
                {
                    if (c.Location.Y > position)
                    {
                        c.Location = new Point(LeftMargin, c.Location.Y - (VerticalPadding + Font.Height));
                    }
                }

                if (SelectedItem.Equals(item))
                {
                    SelectedItem = default;
                }
                Controls.Remove(label);
                Items.Remove(item);
                RecalculateHeight();
            }
        }

        private Label CreateLabel(T item, int y)
        {
            Label l = new Label()
            {
                Text = item.ToString(),
                Location = new Point(LeftMargin, _cursorY),
                Font = Font,
                ForeColor = ForeColor,
                Width = TextRenderer.MeasureText(item.ToString(), Font).Width,
                Name = item.ToString()
            };
            if (item.Equals(SelectedItem))
            {
                l.ForeColor = SelectColor;
            }
            else
            {
                l.MouseEnter += (sender, args) => {
                    l.ForeColor = HoverColor;
                };
                l.MouseLeave += (sender, args) => {
                    if (!item.Equals(SelectedItem))
                    {
                        l.ForeColor = ForeColor;
                    }
                    else
                    {
                        l.ForeColor = SelectColor;
                    }
                };
            }
            l.Click += (sender, args) => {
                SelectedItem = item;
            };
            l.MouseDown += (sender, args) => {
                if (_draggable)
                {
                    l.DoDragDrop(item.ToString(), DragDropEffects.Copy | DragDropEffects.Move);
                }
            };
            return l;
        }

        public void ResizeToParent()
        {
            this.Width = this.Parent.Width;
            this.Height = this.Parent.Height;
            this.Location = new Point(0, 0);
        }

        public void UpdateDisplayText(T item, string newName)
        {
            foreach (Control c in Controls)
            {
                if (c.Text == item.ToString())
                {
                    c.Text = newName;
                    c.Name = newName;
                    c.Width = TextRenderer.MeasureText(newName, Font).Width;
                }
            }
        }


        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);

        }

    }
}