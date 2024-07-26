using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PNB.GUI.GUIHelper
{
    #region CheckedListBoxEditor
    /// <summary>
	///The control displayed in the property grid
	///</summary>
	///<remarks></remarks>
    class CheckedListBoxEditor
    {
        private string _strValue = "(Collection)";

        [Description("This property contains the checked listbox collection.")]
        [Editor(typeof(CheckedListBoxUITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string CheckedListBoxCollectionProperty
        {
            get
            {
                return _strValue;
            }
            set
            {
                _strValue = "(Collection)";
            }
        }

    }
    #endregion

    public class CheckedListBoxUITypeEditor : UITypeEditor
    {
        IWindowsFormsEditorService es;
        CheckedListBox _cbx;
        List<string> lst;

        public virtual CheckedListBox cbx
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbx;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbx != null)
                {
                    _cbx.Leave -= bx_Leave;
                }

                _cbx = value;
                if (_cbx != null)
                {
                    _cbx.Leave += bx_Leave;
                }
            }
        }


        public CheckedListBoxUITypeEditor()
        {
            cbx = new CheckedListBox();
        }

        /// <summary>
		/// Override the UITypeEditorEditStyle to return the editor style: drop-down, modal, or none
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		/// <remarks></remarks>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // returns the editor style:  drop-down, modal, or none
            return System.Drawing.Design.UITypeEditorEditStyle.DropDown;
        }

        public override bool IsDropDownResizable
        {
            get
            {
                // if set to true, adds a grip to the lower-left portion of the listbox,
                // which makes the listbox resizeable as run time
                return true;

            }
        }

        /// <summary>
		/// Override the default method for editing values in the listbox
		/// </summary>
		/// <param name="context"></param>
		/// <param name="provider"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks></remarks>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // instantiate the custom property editor service provider
            es = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (es != null)
            {
                // load the listbox items
                LoadListBoxItems();

                // sort the items
                cbx.Sorted = true;

                // show the control
                es.DropDownControl(cbx);
            }

            // ensure function returns a value on all code paths
            return null;
        }

        /// <summary>
		/// Save the listbox key/value pairs to My.Settings.UrlList
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks></remarks>
        private void bx_Leave(object sender, EventArgs e)
        {
            // clear the old list
            //My.Settings.UrlsList.Clear();
            lst.Clear();

            var withBlock = cbx;
            // load the listbox key/value pairs
            for (int i = 0, loopTo = withBlock.Items.Count - 1; i <= loopTo; i++)
            {
                string txt = withBlock.Items[i].ToString();
                string chk = withBlock.GetItemChecked(i).ToString();

                // concatenate the key/value pair
                string combined = txt.ToLower() + "," + chk.ToLower();

                if (!object.ReferenceEquals(withBlock.Items[i].ToString(), ""))
                {
                    // add the concatenated string to the "UrlsList" string collection
                    //My.Settings.UrlsList.Add(combined);
                    lst.Add(combined);
                }
            }

            // save the config file
            //My.Settings.Save();
        }

        /// <summary>
		/// Loads My.Settings.UrlList comma-delimited string collection into the custom collection editor.
		/// </summary>
		/// <remarks></remarks>
        private void LoadListBoxItems()
        {
            // create an array list
            //var a = new ArrayList();

            //// load the config file "UrlsList" string collection into the array
            //foreach (string s in My.Settings.UrlsList)

            //    // split the url from the checked value

            //    a.Add(Strings.Split(s, ","));

            //// create a hashtable, so we can refer to the items in a key/value pair format
            //var h = new Hashtable();

            //// load the array into the hashtable
            //for (int i = 0, loopTo = a.Count - 1; i <= loopTo; i++)

            //    // add the first array item as the key, the second as the value

            //    h.Add(((Array)a[i]).GetValue(0).ToString(), ((Array)a[i]).GetValue(1).ToString());

            //// dispose of the array list
            //a = null;

            //// clear the listbox items
            //cbx.Items.Clear();

            //// index the hashtable
            //foreach (DictionaryEntry de in h)

            //    // add the key/value pairs to the listbox

            //    cbx.Items.Add(de.Key, Conversions.ToBoolean(de.Value));

            //// dispose of the collection
            //h = null;
        }
    }
}