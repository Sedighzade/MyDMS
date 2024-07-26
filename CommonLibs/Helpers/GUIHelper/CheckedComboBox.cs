using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace PNB.GUI.GUIHelper
{
    public class CheckedComboBox : ComboBox
    {
        private readonly Dropdown dropdown;

        // Event handler for when an item check state changes.
        public event ItemCheckEventHandler ItemCheck;
        internal class Dropdown : Form
        {
            private CheckedComboBox ccbParent;
            private string oldStrValue = "";
            // Array holding the checked states of the items. This will be used to reverse any changes if user cancels selection.
            bool[] checkedStateArr;
            // Whether the dropdown is closed.
            private bool dropdownClosed = true;

            internal class CCBoxEventArgs : EventArgs
            {
                public bool AssignValues
                {
                    get;
                    set;
                }
                public EventArgs EventArgs
                {
                    get;
                    set;
                }
                public CCBoxEventArgs(EventArgs e, bool assignValues) : base()
                {
                    this.EventArgs = e;
                    this.AssignValues = assignValues;
                }
            }
            internal class CustomCheckedListBox : CheckedListBox
            {
                private int curSelIndex = -1;

                public CustomCheckedListBox() : base()
                {
                    this.SelectionMode = SelectionMode.One;
                    this.HorizontalScrollbar = true;
                }

                protected override void OnKeyDown(KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        // Enact selection.
                        ((CheckedComboBox.Dropdown)Parent).OnDeactivate(new CCBoxEventArgs(null, true));
                        e.Handled = true;

                    }
                    else if (e.KeyCode == Keys.Escape)
                    {
                        // Cancel selection.
                        ((CheckedComboBox.Dropdown)Parent).OnDeactivate(new CCBoxEventArgs(null, false));
                        e.Handled = true;

                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        // Delete unckecks all, [Shift + Delete] checks all.
                        for (int i = 0; i < Items.Count; i++)
                        {
                            SetItemChecked(i, e.Shift);
                        }
                        e.Handled = true;
                    }
                    // If no Enter or Esc keys presses, let the base class handle it.
                    base.OnKeyDown(e);
                }

                protected override void OnMouseMove(MouseEventArgs e)
                {
                    base.OnMouseMove(e);
                    int index = IndexFromPoint(e.Location);
                    //Debug.WriteLine("Mouse over item: " + (index >= 0 ? GetItemText(Items[index]) : "None"));
                    if ((index >= 0) && (index != curSelIndex))
                    {
                        curSelIndex = index;
                        SetSelected(index, true);
                    }
                }

            }
            public bool ValueChanged
            {
                get
                {
                    string newStrValue = ccbParent.Text;
                    if ((oldStrValue.Length > 0) && (newStrValue.Length > 0))
                    {
                        return (oldStrValue.CompareTo(newStrValue) != 0);
                    }
                    else
                    {
                        return (oldStrValue.Length != newStrValue.Length);
                    }
                }
            }
            public CustomCheckedListBox List
            {
                get;
                set;
            }
            public Dropdown(CheckedComboBox ccbParent)
            {
                this.ccbParent = ccbParent;
                InitializeComponent();
                this.ShowInTaskbar = false;
                // Add a handler to notify our parent of ItemCheck events.
                this.List.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.List_ItemCheck);
            }
            private void InitializeComponent()
            {
                this.List = new CustomCheckedListBox();
                this.SuspendLayout();
                // 
                // List
                // 
                this.List.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.List.Dock = System.Windows.Forms.DockStyle.Fill;
                this.List.FormattingEnabled = true;
                this.List.Location = new System.Drawing.Point(0, 0);
                this.List.Name = "List";
                this.List.Size = new System.Drawing.Size(47, 15);
                this.List.TabIndex = 0;
                // 
                // Dropdown
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.SystemColors.Menu;
                this.ClientSize = new System.Drawing.Size(47, 16);
                this.ControlBox = false;
                this.Controls.Add(this.List);
                this.ForeColor = System.Drawing.SystemColors.ControlText;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.MinimizeBox = false;
                this.Name = "ccbParent";
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.ResumeLayout(false);
            }
            public string GetCheckedItemsStringValue()
            {
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < List.CheckedItems.Count; i++)
                {
                    sb.Append(List.GetItemText(List.CheckedItems[i])).Append(ccbParent.ValueSeparator);
                }
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - ccbParent.ValueSeparator.Length, ccbParent.ValueSeparator.Length);
                }
                return sb.ToString();
            }
            public void CloseDropdown(bool enactChanges)
            {
                if (dropdownClosed)
                {
                    return;
                }
                //Debug.WriteLine("CloseDropdown");
                // Perform the actual selection and display of checked items.
                if (enactChanges)
                {
                    ccbParent.SelectedIndex = -1;
                    // Set the text portion equal to the string comprising all checked items (if any, otherwise empty!).
                    ccbParent.Text = GetCheckedItemsStringValue();

                }
                else
                {
                    // Caller cancelled selection - need to restore the checked items to their original state.
                    for (int i = 0; i < List.Items.Count; i++)
                    {
                        List.SetItemChecked(i, checkedStateArr[i]);
                    }
                }
                // From now on the dropdown is considered closed. We set the flag here to prevent OnDeactivate() calling
                // this method once again after hiding this window.
                dropdownClosed = true;
                // Set the focus to our parent CheckedComboBox and hide the dropdown check list.
                ccbParent.Focus();
                //this.Hide();
                ccbParent.BeginInvoke((MethodInvoker)delegate { Hide(); });
                // Notify CheckedComboBox that its dropdown is closed. (NOTE: it does not matter which parameters we pass to
                // OnDropDownClosed() as long as the argument is CCBoxEventArgs so that the method knows the notification has
                // come from our code and not from the framework).
                ccbParent.OnDropDownClosed(new CCBoxEventArgs(null, false));
            }
            protected override void OnActivated(EventArgs e)
            {
                //Debug.WriteLine("OnActivated");
                base.OnActivated(e);
                dropdownClosed = false;
                // Assign the old string value to compare with the new value for any changes.
                oldStrValue = ccbParent.Text;
                // Make a copy of the checked state of each item, in cace caller cancels selection.
                checkedStateArr = new bool[List.Items.Count];
                for (int i = 0; i < List.Items.Count; i++)
                {
                    checkedStateArr[i] = List.GetItemChecked(i);
                }
            }
            protected override void OnDeactivate(EventArgs e)
            {
                //Debug.WriteLine("OnDeactivate");
                //base.OnDeactivate(e);
                CCBoxEventArgs ce = e as CCBoxEventArgs;
                if (ce != null)
                {
                    CloseDropdown(ce.AssignValues);
                }
                else
                {
                    // If not custom event arguments passed, means that this method was called from the
                    // framework. We assume that the checked values should be registered regardless.
                    CloseDropdown(true);
                }
            }
            private void List_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                ccbParent.ItemCheck?.Invoke(sender, e);
            }
        }


        public string ValueSeparator
        {
            get;
            set;
        }

        public bool CheckOnClick
        {
            get { return dropdown.List.CheckOnClick; }
            set { dropdown.List.CheckOnClick = value; }
        }

        public new string DisplayMember
        {
            get { return dropdown.List.DisplayMember; }
            set { dropdown.List.DisplayMember = value; }
        }

        public new CheckedListBox.ObjectCollection Items
        {
            get { return dropdown.List.Items; }
        }

        public CheckedListBox.CheckedItemCollection CheckedItems
        {
            get { return dropdown.List.CheckedItems; }
        }

        public CheckedListBox.CheckedIndexCollection CheckedIndices
        {
            get { return dropdown.List.CheckedIndices; }
        }

        public bool ValueChanged
        {
            get { return dropdown.ValueChanged; }
        }

        public CheckedComboBox() : base()
        {
            // We want to do the drawing of the dropdown.
            this.DrawMode = DrawMode.OwnerDrawVariable;
            // Default value separator.
            this.ValueSeparator = ", ";
            // This prevents the actual ComboBox dropdown to show, although it's not strickly-speaking necessary.
            // But including this remove a slight flickering just before our dropdown appears (which is caused by
            // the empty-dropdown list of the ComboBox which is displayed for fractions of a second).
            this.DropDownHeight = 1;
            // This is the default setting - text portion is editable and user must click the arrow button
            // to see the list portion. Although we don't want to allow the user to edit the text portion
            // the DropDownList style is not being used because for some reason it wouldn't allow the text
            // portion to be programmatically set. Hence we set it as editable but disable keyboard input (see below).
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.dropdown = new Dropdown(this);
            // CheckOnClick style for the dropdown (NOTE: must be set after dropdown is created).
            this.CheckOnClick = true;
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            DoDropDown();
        }

        private void DoDropDown()
        {
            if (!dropdown.Visible)
            {
                Rectangle rect = RectangleToScreen(this.ClientRectangle);
                dropdown.Location = new Point(rect.X, rect.Y + this.Size.Height);
                int count = dropdown.List.Items.Count;
                if (count > this.MaxDropDownItems)
                {
                    count = this.MaxDropDownItems;
                }
                else if (count == 0)
                {
                    count = 1;
                }
                dropdown.Size = new Size(this.Size.Width, 2 * (dropdown.List.ItemHeight) * count + 2);
                dropdown.Show(this);
            }
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            // Call the handlers for this event only if the call comes from our code - NOT the framework's!
            // NOTE: that is because the events were being fired in a wrong order, due to the actual dropdown list
            //       of the ComboBox which lies underneath our dropdown and gets involved every time.
            if (e is Dropdown.CCBoxEventArgs)
            {
                base.OnDropDownClosed(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Signal that the dropdown is "down". This is required so that the behaviour of the dropdown is the same
                // when it is a result of user pressing the Down_Arrow (which we handle and the framework wouldn't know that
                // the list portion is down unless we tell it so).
                // NOTE: all that so the DropDownClosed event fires correctly!                
                OnDropDown(null);
            }
            // Make sure that certain keys or combinations are not blocked.
            e.Handled = !e.Alt && !(e.KeyCode == Keys.Tab) &&
                !((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Home) || (e.KeyCode == Keys.End));

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            base.OnKeyPress(e);
        }

        public bool GetItemChecked(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                return dropdown.List.GetItemChecked(index);
            }
        }

        public void SetItemChecked(int index, bool isChecked)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                dropdown.List.SetItemChecked(index, isChecked);
                // Need to update the Text.
                this.Text = dropdown.GetCheckedItemsStringValue();
            }
        }

        public CheckState GetItemCheckState(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                return dropdown.List.GetItemCheckState(index);
            }
        }

        public void SetItemCheckState(int index, CheckState state)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                dropdown.List.SetItemCheckState(index, state);
                // Need to update the Text.
                this.Text = dropdown.GetCheckedItemsStringValue();
            }
        }

    }
}
