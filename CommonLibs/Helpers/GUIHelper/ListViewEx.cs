

////https://www.codeproject.com/Articles/6646/In-place-Editing-of-ListView-subitems
//// 1399.09.22    https://www.codeproject.com/Articles/11686/Printable-ListView

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PNB.GUI.GUIHelper
{

	///	<summary>
	///	Inherited ListView to allow in-place editing of subitems
	///	</summary>
	public class ListViewEx2 : System.Windows.Forms.ListView
	{
		#region Printable listview
		// Print fields
		private PrintDocument m_printDoc = new PrintDocument();
		private PageSetupDialog m_setupDlg = new PageSetupDialog();
		private PrintPreviewDialog m_previewDlg = new PrintPreviewDialog();
		private PrintDialog m_printDlg = new PrintDialog();

		private int m_nPageNumber = 1;
		private int m_nStartRow = 0;
		private int m_nStartCol = 0;

		private bool m_bPrintSel = false;

		private bool m_bFitToPage = false;

		private float m_fListWidth = 0.0f;
		private float[] m_arColsWidth;

		private float m_fDpi = 96.0f;

		private string m_strTitle = "";
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		#region Properties
		public Image Logo { set; get; }

		/// <summary>
		///		Gets or sets whether to fit the list width on a single page
		/// </summary>
		/// <value>
		///		<c>True</c> if you want to scale the list width so it will fit on a single page.
		/// </value>
		/// <remarks>
		///		If you choose false (the default value), and the list width exceeds the page width, the list
		///		will be broken in multiple page.
		/// </remarks>
		public bool FitToPage
		{
			get { return m_bFitToPage; }
			set { m_bFitToPage = value; }
		}

		/// <summary>
		///		Gets or sets the title to dispaly as page header in the printed list
		/// </summary>
		/// <value>
		///		A <see cref="string"/> the represents the title printed as page header.
		/// </value>
		public string Title
		{
			get { return m_strTitle; }
			set { m_strTitle = value; }
		}

		public Size PreviewSize { set { m_previewDlg.Size = value; } get { return m_previewDlg.Size; } }
		#endregion

		/// <summary>
		///		Show the standard page setup dialog box that lets the user specify
		///		margins, page orientation, page sources, and paper sizes.
		/// </summary>
		public void PageSetup()
		{
			m_setupDlg.ShowDialog();
		}

		/// <summary>
		///		Show the standard print preview dialog box.
		/// </summary>
		public void PrintPreview()
		{
			m_printDoc.DocumentName = "List View";

			m_nPageNumber = 1;
			m_bPrintSel = false;

			m_previewDlg.ShowDialog(this);
		}

		/// <summary>
		///		Start the print process.
		/// </summary>
		public void Print()
		{
			m_printDlg.AllowSelection = this.SelectedItems.Count > 0;

			// Show the standard print dialog box, that lets the user select a printer
			// and change the settings for that printer.
			if (m_printDlg.ShowDialog(this) == DialogResult.OK)
			{
				m_printDoc.DocumentName = m_strTitle;

				m_bPrintSel = m_printDlg.PrinterSettings.PrintRange == PrintRange.Selection;

				m_nPageNumber = 1;

				// Start print
				m_printDoc.Print();
			}
		}


		private int GetItemsCount()
		{
			return m_bPrintSel ? SelectedItems.Count : Items.Count;
		}

		private ListViewItem GetItem(int index)
		{
			return m_bPrintSel ? SelectedItems[index] : Items[index];
		}

		private void PreparePrint()
		{
			// Gets the list width and the columns width in units of hundredths of an inch.
			this.m_fListWidth = 0.0f;
			this.m_arColsWidth = new float[this.Columns.Count];

			Graphics g = CreateGraphics();
			m_fDpi = g.DpiX;
			g.Dispose();

			for (int i = 0; i < Columns.Count; i++)
			{
				ColumnHeader ch = Columns[i];
				float fWidth = ch.Width / m_fDpi * 100 + 1; // Column width + separator
				m_fListWidth += fWidth;
				m_arColsWidth[i] = fWidth;
			}
			m_fListWidth += 1; // separator
		}

		//public int x1;
		//public int y1;

		#region Events Handlers
		private void OnBeginPrint(object sender, PrintEventArgs e)
		{
			PreparePrint();
		}

		private void OnPrintPage(object sender, PrintPageEventArgs e)
		{
			int nNumItems = GetItemsCount();  // Number of items to print

			if (nNumItems == 0 || m_nStartRow >= nNumItems)
			{
				e.HasMorePages = false;
				return;
			}

			int nNextStartCol = 0;            // First column exeeding the page width
			float x = 0.0f;                   // Current horizontal coordinate
			float y = 0.0f;                   // Current vertical coordinate
			float cx = 4.0f;                  // The horizontal space, in hundredths of an inch,
											  // of the padding between items text and
											  // their cell boundaries.
			float fScale = 1.0f;              // Scale factor when fit to page is enabled
			float fRowHeight = 0.0f;          // The height of the current row
			float fColWidth = 0.0f;       // The width of the current column

			RectangleF rectFull;              // The full available space
			RectangleF rectBody;              // Area for the list items

			bool bUnprintable = false;

			Graphics g = e.Graphics;

			if (Logo != null)
			{
				//Point ulCorner = new Point(0, 0);
				//Point urCorner = new Point(32, 10);
				//Point llCorner = new Point(15, 25);
				//Point[] destPara = { ulCorner, urCorner, llCorner };
				Rectangle destPara = new Rectangle(80, 10, 100, 100);
				g.DrawRectangle(Pens.AliceBlue, destPara);

				// Create rectangle for source image.
				Rectangle srcRect = new Rectangle(0, 0, 100, 100);
				GraphicsUnit units = GraphicsUnit.Pixel;
				g.DrawImage(Logo, destPara, srcRect, units);
			}
			if (g.VisibleClipBounds.X < 0)  // Print preview
			{
				rectFull = e.MarginBounds;

				// Convert to hundredths of an inch
				rectFull = new RectangleF(rectFull.X / m_fDpi * 100.0f,
					rectFull.Y / m_fDpi * 100.0f,
					rectFull.Width / m_fDpi * 100.0f,
					rectFull.Height / m_fDpi * 100.0f);
			}
			else                            // Print
			{
				// Printable area (approximately) of the page, taking into account the user margins
				rectFull = new RectangleF(
					e.MarginBounds.Left - (e.PageBounds.Width - g.VisibleClipBounds.Width) / 2,
					e.MarginBounds.Top - (e.PageBounds.Height - g.VisibleClipBounds.Height) / 2,
					e.MarginBounds.Width,
					e.MarginBounds.Height);
			}

			rectBody = RectangleF.Inflate(rectFull, 0, -2 * Font.GetHeight(g));

			// Display title at top
			StringFormat sfmt = new StringFormat();
			sfmt.Alignment = StringAlignment.Center;
			g.DrawString(m_strTitle, Font, Brushes.Black, rectFull, sfmt);

			// Display page number at bottom
			sfmt.LineAlignment = StringAlignment.Far;
			g.DrawString("Page " + m_nPageNumber, Font, Brushes.Black, rectFull, sfmt);

			if (m_nStartCol == 0 && m_bFitToPage && m_fListWidth > rectBody.Width)
			{
				// Calculate scale factor
				fScale = rectBody.Width / m_fListWidth;
			}

			// Scale the printable area
			rectFull = new RectangleF(rectFull.X / fScale,
									rectFull.Y / fScale,
									rectFull.Width / fScale,
									rectFull.Height / fScale);

			rectBody = new RectangleF(rectBody.X / fScale,
									  rectBody.Y / fScale,
									  rectBody.Width / fScale,
									  rectBody.Height / fScale);

			// Setting scale factor and unit of measure
			g.ScaleTransform(fScale, fScale);
			g.PageUnit = GraphicsUnit.Inch;
			g.PageScale = 0.01f;

			// Start print
			nNextStartCol = 0;
			y = rectBody.Top;

			// Columns headers ----------------------------------------
			Brush brushHeader = new SolidBrush(Color.LightGray);
			Font fontHeader = new Font(this.Font, FontStyle.Bold);
			fRowHeight = fontHeader.GetHeight(g) * 3.0f;
			x = rectBody.Left;

			for (int i = m_nStartCol; i < Columns.Count; i++)
			{
				ColumnHeader ch = Columns[i];
				fColWidth = m_arColsWidth[i];

				if ((x + fColWidth) <= rectBody.Right)
				{
					// Rectangle
					g.FillRectangle(brushHeader, x, y, fColWidth, fRowHeight);
					g.DrawRectangle(Pens.Black, x, y, fColWidth, fRowHeight);

					// Text
					StringFormat sf = new StringFormat();
					if (ch.TextAlign == HorizontalAlignment.Left)
						sf.Alignment = StringAlignment.Near;
					else if (ch.TextAlign == HorizontalAlignment.Center)
						sf.Alignment = StringAlignment.Center;
					else
						sf.Alignment = StringAlignment.Far;

					sf.LineAlignment = StringAlignment.Center;
					sf.FormatFlags = StringFormatFlags.NoWrap;
					sf.Trimming = StringTrimming.EllipsisCharacter;

					RectangleF rectText = new RectangleF(x + cx, y, fColWidth - 1 - 2 * cx, fRowHeight);
					g.DrawString(ch.Text, fontHeader, Brushes.Black, rectText, sf);
					x += fColWidth;
				}
				else
				{
					if (i == m_nStartCol)
						bUnprintable = true;

					nNextStartCol = i;
					break;
				}
			}
			y += fRowHeight;

			// Rows ---------------------------------------------------
			int nRow = m_nStartRow;
			bool bEndOfPage = false;
			while (!bEndOfPage && nRow < nNumItems)
			{
				ListViewItem item = GetItem(nRow);

				fRowHeight = item.Bounds.Height / m_fDpi * 100.0f + 5.0f;

				if (y + fRowHeight > rectBody.Bottom)
				{
					bEndOfPage = true;
				}
				else
				{
					x = rectBody.Left;

					for (int i = m_nStartCol; i < Columns.Count; i++)
					{
						ColumnHeader ch = Columns[i];
						fColWidth = m_arColsWidth[i];

						if ((x + fColWidth) <= rectBody.Right)
						{
							// Rectangle
							g.DrawRectangle(Pens.Black, x, y, fColWidth, fRowHeight);

							// Text
							StringFormat sf = new StringFormat();
							if (ch.TextAlign == HorizontalAlignment.Left)
								sf.Alignment = StringAlignment.Near;
							else if (ch.TextAlign == HorizontalAlignment.Center)
								sf.Alignment = StringAlignment.Center;
							else
								sf.Alignment = StringAlignment.Far;

							sf.LineAlignment = StringAlignment.Center;
							sf.FormatFlags = StringFormatFlags.NoWrap;
							sf.Trimming = StringTrimming.EllipsisCharacter;

							// Text
							string strText = i == 0 ? item.Text : item.SubItems[i].Text;
							Font font = i == 0 ? item.Font : item.SubItems[i].Font;

							RectangleF rectText = new RectangleF(x + cx, y, fColWidth - 1 - 2 * cx, fRowHeight);
							g.DrawString(strText, font, Brushes.Black, rectText, sf);
							x += fColWidth;
						}
						else
						{
							nNextStartCol = i;
							break;
						}
					}

					y += fRowHeight;
					nRow++;
				}
			}

			if (nNextStartCol == 0)
				m_nStartRow = nRow;

			m_nStartCol = nNextStartCol;

			m_nPageNumber++;

			e.HasMorePages = (!bUnprintable && (m_nStartRow > 0 && m_nStartRow < nNumItems) || m_nStartCol > 0);

			if (!e.HasMorePages)
			{
				m_nPageNumber = 1;
				m_nStartRow = 0;
				m_nStartCol = 0;
			}

			brushHeader.Dispose();
		}
		#endregion

		#endregion


		/// <summary>
		/// Event Handler for SubItem events
		/// </summary>
		public delegate void SubItemEventHandler(object sender, SubItemEventArgs e);
		/// <summary>
		/// Event Handler for SubItemEndEditing events
		/// </summary>
		public delegate void SubItemEndEditingEventHandler(object sender, SubItemEndEditingEventArgs e);

		/// <summary>
		/// Event Args for SubItemClicked event
		/// </summary>
		public class SubItemEventArgs : EventArgs
		{
			public SubItemEventArgs(ListViewItem item, int subItem)
			{
				_subItemIndex = subItem;
				_item = item;
			}
			private int _subItemIndex = -1;
			private ListViewItem _item = null;
			public int SubItem
			{
				get { return _subItemIndex; }
			}
			public ListViewItem Item
			{
				get { return _item; }
			}

			public bool PreserveControlSize { set; get; }
		}


		/// <summary>
		/// Event Args for SubItemEndEditingClicked event
		/// </summary>
		public class SubItemEndEditingEventArgs : SubItemEventArgs
		{
			private string _text = string.Empty;
			private bool _cancel = true;

			public SubItemEndEditingEventArgs(ListViewItem item, int subItem, string display, bool cancel) :
				base(item, subItem)
			{
				_text = display;
				_cancel = cancel;
			}
			public string DisplayText
			{
				get { return _text; }
				set { _text = value; }
			}
			public bool Cancel
			{
				get { return _cancel; }
				set { _cancel = value; }
			}
		}


		#region Interop structs, imports and constants
		/// <summary>
		/// MessageHeader for WM_NOTIFY
		/// </summary>
		private struct NMHDR
		{
			public IntPtr hwndFrom;
			public Int32 idFrom;
			public Int32 code;
		}


		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wPar, IntPtr lPar);
		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int len, ref int[] order);

		// ListView messages
		private const int LVM_FIRST = 0x1000;
		private const int LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59);

		// Windows Messages that will abort editing
		private const int WM_HSCROLL = 0x114;
		private const int WM_VSCROLL = 0x115;
		private const int WM_SIZE = 0x05;
		private const int WM_NOTIFY = 0x4E;

		private const int HDN_FIRST = -300;
		private const int HDN_BEGINDRAG = (HDN_FIRST - 10);
		private const int HDN_ITEMCHANGINGA = (HDN_FIRST - 0);
		private const int HDN_ITEMCHANGINGW = (HDN_FIRST - 20);
		#endregion

		///	<summary>
		///	Required designer variable.
		///	</summary>
		private System.ComponentModel.Container components = null;

		public event SubItemEventHandler SubItemClicked;
		public event SubItemEventHandler SubItemBeginEditing;
		public event SubItemEndEditingEventHandler SubItemEndEditing;

		public ListViewEx2()
		{
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.AllPaintingInWmPaint, true);
			DoubleBuffered = true;

			// This	call is	required by	the	Windows.Forms Form Designer.
			InitializeComponent();

			base.FullRowSelect = true;
			base.View = View.Details;
			base.AllowColumnReorder = true;
			GridLines = true;


			#region Printable Listview

			m_previewDlg.Size = new Size(500, 500);
			m_previewDlg.UseAntiAlias = true;

			m_printDoc.BeginPrint += new PrintEventHandler(OnBeginPrint);
			m_printDoc.PrintPage += new PrintPageEventHandler(OnPrintPage);

			m_setupDlg.Document = m_printDoc;
			m_previewDlg.Document = m_printDoc;
			m_printDlg.Document = m_printDoc;

			m_printDlg.AllowSomePages = false;

			#endregion
		}

		///	<summary>
		///	Clean up any resources being used.
		///	</summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component	Designer generated code
		///	<summary>
		///	Required method	for	Designer support - do not modify 
		///	the	contents of	this method	with the code editor.
		///	</summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		private bool _doubleClickActivation = false;
		/// <summary>
		/// Is a double click required to start editing a cell?
		/// </summary>
		public bool DoubleClickActivation
		{
			get { return _doubleClickActivation; }
			set { _doubleClickActivation = value; }
		}


		/// <summary>
		/// Retrieve the order in which columns appear
		/// </summary>
		/// <returns>Current display order of column indices</returns>
		public int[] GetColumnOrder()
		{
			IntPtr lPar = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * Columns.Count);

			IntPtr res = SendMessage(Handle, LVM_GETCOLUMNORDERARRAY, new IntPtr(Columns.Count), lPar);
			if (res.ToInt32() == 0) // Something went wrong
			{
				Marshal.FreeHGlobal(lPar);
				return null;
			}

			int[] order = new int[Columns.Count];
			Marshal.Copy(lPar, order, 0, Columns.Count);

			Marshal.FreeHGlobal(lPar);

			return order;
		}


		/// <summary>
		/// Find ListViewItem and SubItem Index at position (x,y)
		/// </summary>
		/// <param name="x">relative to ListView</param>
		/// <param name="y">relative to ListView</param>
		/// <param name="item">Item at position (x,y)</param>
		/// <returns>SubItem index</returns>
		public int GetSubItemAt(int x, int y, out ListViewItem item)
		{
			item = this.GetItemAt(x, y);

			if (item != null)
			{
				int[] order = GetColumnOrder();
				Rectangle lviBounds;
				int subItemX;

				lviBounds = item.GetBounds(ItemBoundsPortion.Entire);
				subItemX = lviBounds.Left;
				for (int i = 0; i < order.Length; i++)
				{
					ColumnHeader h = this.Columns[order[i]];
					if (x < subItemX + h.Width)
					{
						return h.Index;
					}
					subItemX += h.Width;
				}
			}

			return -1;
		}


		/// <summary>
		/// Get bounds for a SubItem
		/// </summary>
		/// <param name="Item">Target ListViewItem</param>
		/// <param name="SubItem">Target SubItem index</param>
		/// <returns>Bounds of SubItem (relative to ListView)</returns>
		public Rectangle GetSubItemBounds(ListViewItem Item, int SubItem)
		{
			int[] order = GetColumnOrder();

			Rectangle subItemRect = Rectangle.Empty;
			if (SubItem >= order.Length)
				throw new IndexOutOfRangeException("SubItem " + SubItem + " out of range");

			if (Item == null)
				throw new ArgumentNullException("Item");

			Rectangle lviBounds = Item.GetBounds(ItemBoundsPortion.Entire);
			int subItemX = lviBounds.Left;

			ColumnHeader col;
			int i;
			for (i = 0; i < order.Length; i++)
			{
				col = this.Columns[order[i]];
				if (col.Index == SubItem)
					break;
				subItemX += col.Width;
			}
			subItemRect = new Rectangle(subItemX, lviBounds.Top, this.Columns[order[i]].Width, lviBounds.Height);
			return subItemRect;
		}


		protected override void WndProc(ref Message msg)
		{
			switch (msg.Msg)
			{
				// Look	for	WM_VSCROLL,WM_HSCROLL or WM_SIZE messages.
				case WM_VSCROLL:
				case WM_HSCROLL:
				case WM_SIZE:
					EndEditing(false);
					break;
				case WM_NOTIFY:
					// Look for WM_NOTIFY of events that might also change the
					// editor's position/size: Column reordering or resizing
					NMHDR h = (NMHDR)Marshal.PtrToStructure(msg.LParam, typeof(NMHDR));
					if (h.code == HDN_BEGINDRAG ||
						h.code == HDN_ITEMCHANGINGA ||
						h.code == HDN_ITEMCHANGINGW)
						EndEditing(false);
					break;
			}

			base.WndProc(ref msg);
		}

		#region Initialize editing depending of DoubleClickActivation property
		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (DoubleClickActivation)
			{
				return;
			}

			EditSubitemAt(new Point(e.X, e.Y));
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);

			if (!DoubleClickActivation)
			{
				return;
			}

			Point pt = this.PointToClient(Cursor.Position);

			EditSubitemAt(pt);
		}

		///<summary>
		/// Fire SubItemClicked
		///</summary>
		///<param name="p">Point of click/doubleclick</param>
		private void EditSubitemAt(Point p)
		{
			ListViewItem item;
			int idx = GetSubItemAt(p.X, p.Y, out item);
			if (idx >= 0)
			{
				OnSubItemClicked(new SubItemEventArgs(item, idx));
			}
		}

		#endregion

		#region In-place editing functions
		// The control performing the actual editing
		Control _editingControl;
		// The LVI being edited
		private ListViewItem _editItem;
		// The SubItem being edited
		private int _editSubItem;

		protected void OnSubItemBeginEditing(SubItemEventArgs e)
		{
			SubItemBeginEditing?.Invoke(this, e);
		}
		protected void OnSubItemEndEditing(SubItemEndEditingEventArgs e)
		{
			SubItemEndEditing?.Invoke(this, e);
		}
		protected void OnSubItemClicked(SubItemEventArgs e)
		{
			SubItemClicked?.Invoke(this, e);
		}

		/// <summary>
		/// Begin in-place editing of given cell
		/// </summary>
		/// <param name="ctrl">Control used as cell editor</param>
		/// <param name="Item">ListViewItem to edit</param>
		/// <param name="SubItem">SubItem index to edit</param>
		public void StartEditing(Control c, SubItemEventArgs e)
		{
			StartEditing(c, e.Item, e.SubItem, e.PreserveControlSize);
		}
		public void StartEditing(Control ctrl, ListViewItem Item, int SubItem, bool preserveControlSize)
		{
			OnSubItemBeginEditing(new SubItemEventArgs(Item, SubItem));

			Rectangle rcSubItem = GetSubItemBounds(Item, SubItem);

			if (rcSubItem.X < 0)
			{
				// Left edge of SubItem not visible - adjust rectangle position and width
				rcSubItem.Width += rcSubItem.X;
				rcSubItem.X = 0;
			}
			if (rcSubItem.X + rcSubItem.Width > this.Width)
			{
				// Right edge of SubItem not visible - adjust rectangle width
				rcSubItem.Width = this.Width - rcSubItem.Left;
			}

			// Subitem bounds are relative to the location of the ListView!
			rcSubItem.Offset(Left, Top);

			// In case the editing control and the listview are on different parents,
			// account for different origins
			Point origin = new Point(0, 0);
			Point lvOrigin = this.Parent.PointToScreen(origin);
			Point ctlOrigin = ctrl.Parent.PointToScreen(origin);

			rcSubItem.Offset(lvOrigin.X - ctlOrigin.X, lvOrigin.Y - ctlOrigin.Y);

			// Position and show editor
			Size s = ctrl.Size;
			ctrl.Bounds = rcSubItem;
			if (preserveControlSize)
				ctrl.Size = s;

			ctrl.Text = Item.SubItems[SubItem].Text;
			ctrl.Visible = true;
			ctrl.BringToFront();
			ctrl.Focus();

			_editingControl = ctrl;
			_editingControl.Leave -= new EventHandler(EditControl_Leave);
			_editingControl.KeyPress -= new KeyPressEventHandler(EditControl_KeyPress);
			_editingControl.Leave += new EventHandler(EditControl_Leave);
			_editingControl.KeyPress += new KeyPressEventHandler(EditControl_KeyPress);

			_editItem = Item;
			_editSubItem = SubItem;
		}


		private void EditControl_Leave(object sender, EventArgs e)
		{
			// cell editor losing focus
			EndEditing(true);
		}

		private void EditControl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case (char)(int)Keys.Escape:
					{
						EndEditing(false);
						break;
					}

				case (char)(int)Keys.Enter:
					{
						EndEditing(true);
						break;
					}
			}
		}

		/// <summary>
		/// Accept or discard current value of cell editor control
		/// </summary>
		/// <param name="AcceptChanges">Use the _editingControl's Text as new SubItem text or discard changes?</param>
		public void EndEditing(bool AcceptChanges)
		{
			if (_editingControl == null)
				return;

			SubItemEndEditingEventArgs e = new SubItemEndEditingEventArgs(
				_editItem,      // The item being edited
				_editSubItem,   // The subitem index being edited
				AcceptChanges ?
				_editingControl != null ? _editingControl.Text : string.Empty :  // Use editControl text if changes are accepted
					_editItem.SubItems[_editSubItem].Text,  // or the original subitem's text, if changes are discarded
				!AcceptChanges  // Cancel?
			);

			OnSubItemEndEditing(e);

			_editItem.SubItems[_editSubItem].Text = e.Cancel ? _editItem.SubItems[_editSubItem].Text : e.DisplayText;

			if (_editingControl != null)
			{
				_editingControl.Leave -= new EventHandler(EditControl_Leave);
				_editingControl.KeyPress -= new KeyPressEventHandler(EditControl_KeyPress);

				_editingControl.Visible = false;

				_editingControl = null;
			}

			_editItem = null;
			_editSubItem = -1;
		}
		#endregion
	}

	//public class ListViewEx2 : ListView
	//{
	//    public ListViewEx2()
	//    {
	//        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
	//    }
	//}
}
